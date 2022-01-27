<?php
	require(__DIR__ . "/../../config/connection.php");
	
	/*
	This will give all the parks that are in the database.
	@return The parks. (In an array.)
	*/
	function getAllCoasters() {
		global $conn;
		
		if($result = $conn->query("SELECT `coasters`.`id`, `coasters`.`name`, `parks`.`name` as `park_name`, `parks`.`id` as `park_id`, `build_year`,`manufacturer`.`name` as `manufacturer`, `coastertypes`.`type` as `type`, `height`, `speed`, `gforce` FROM `coasters`,`parks`,`manufacturer`,`coastertypes` WHERE `coasters`.`park` = `parks`.`id` AND `coasters`.`manufacturer` = `manufacturer`.`id` AND `coasters`.`type` = `coastertypes`.`id`")){
			$rows = resultToArrayForCoasters($result);
			$result->close();
		} else {
			die("Something went wrong. Please try again later. (Error: 1-1)");
		}
		return $rows;
	}
	
	/*
	This will give the specific data of a park that is in the database.
	@return The park. (In an array.)
	*/
	function getSpecificCoaster($coasterid){
		global $conn;
		
		// Make sure that the given variables cannot contain unsafe HTML code.
		$safecoasterid = htmlspecialchars($coasterid, ENT_QUOTES);
		
		if($stmt = $conn->prepare("SELECT `coasters`.`id`, `coasters`.`name`, `parks`.`name` as `park_name`, `parks`.`id` as `park_id`, `build_year`,`manufacturer`.`name` as `manufacturer`, `coastertypes`.`type` as `type`, `height`, `speed`, `gforce` FROM `coasters`,`parks`,`manufacturer`,`coastertypes` WHERE `coasters`.`park` = `parks`.`id` AND `coasters`.`manufacturer` = `manufacturer`.`id` AND `coasters`.`type` = `coastertypes`.`id` AND `coasters`.`id` = ?")){
			$stmt->bind_param("s", $safecoasterid);
			$stmt->execute();
			$result = $stmt->get_result();
			$rows = resultToArrayForCoasters($result);
			$stmt->close();
			return $rows;
		} else {
			die("Something went wrong. Please try again later. (Error: 1-2)");
		}
	}
	
	/*
	This will allow you to add a coaster to the database.
	@param coastername The name of the coaster.
	@param parkid The ID of the park the coaster is in.
	@param buildyear The date the coaster was build.
	@param manufacturerid The ID of the coaster manufacturer.
	@param coastertypeid The ID of the coaster type.
	@param coasterheigt The height of the coaster.
	@param coasterspeed The speed of the coaster.
	@param coastergforce The G-Force of the coaster.
	@return Success or failure. (In an array.)
	*/
	function createCoaster($coastername = null, $parkid = null, $buildyear = null, $manufacturerid = null, $coastertypeid = null, $coasterheigt = null, $coasterspeed = null, $coastergforce = null) {
		global $conn;
		
		// Make sure that the given variables cannot contain unsafe HTML code.
		$safecoastername = htmlspecialchars($coastername, ENT_QUOTES);
		$safeparkid = htmlspecialchars($parkid, ENT_QUOTES);
		$safebuildyear = htmlspecialchars($buildyear, ENT_QUOTES);
		$safemanufacturerid = htmlspecialchars($manufacturerid, ENT_QUOTES);
		$safecoastertypeid = htmlspecialchars($coastertypeid, ENT_QUOTES);
		$safecoasterheight = htmlspecialchars($coasterheigt, ENT_QUOTES);
		$safecoasterspeed = htmlspecialchars($coasterspeed, ENT_QUOTES);
		$safecoastergforce = htmlspecialchars($coastergforce, ENT_QUOTES);
		
		if(!empty($safecoastername) && !empty($safeparkid) && !empty($safebuildyear) && !empty($safemanufacturerid) && !empty($safecoastertypeid) && !empty($safecoasterheight) && !empty($safecoasterspeed) && !empty($safecoastergforce)){
			if(DateTime::createFromFormat('Y-m-d', $safebuildyear) !== false) {
				if($stmt = $conn->prepare("SELECT id FROM `parks` WHERE `id` = ?")){
					$stmt->bind_param("s", $safeparkid);
					$stmt->execute();
					$stmt->bind_result($mysqlparkid);
					$stmt->fetch();
					$stmt->close();
					if($mysqlparkid != null){
						if($stmt = $conn->prepare("SELECT id FROM `manufacturer` WHERE `id` = ?")){
							$stmt->bind_param("s", $safemanufacturerid);
							$stmt->execute();
							$stmt->bind_result($mysqlmanufacturerid);
							$stmt->fetch();
							$stmt->close();
							if($mysqlmanufacturerid != null){
								if($stmt = $conn->prepare("SELECT id FROM `coastertypes` WHERE `id` = ?")){
									$stmt->bind_param("s", $safecoastertypeid);
									$stmt->execute();
									$stmt->bind_result($mysqlcoastertypeid);
									$stmt->fetch();
									$stmt->close();
									if($mysqlcoastertypeid != null){
										if($stmt = $conn->prepare("INSERT INTO `coasters`(`name`, `park`, `build_year`, `manufacturer`, `type`, `height`, `speed`, `gforce`) VALUES (?,?,?,?,?,?,?,?)")){
											$stmt->bind_param("ssssssss", $safecoastername, $mysqlparkid, $safebuildyear, $mysqlmanufacturerid, $mysqlcoastertypeid, $safecoasterheight, $safecoasterspeed, $safecoastergforce);
											$stmt->execute();
											$stmt->close();
											return array("success" => "true", "message" => "The coaster is created.");
										} else {
											die("Something went wrong. Please try again later. (Error: 1-6)");
										}
									} else {
										return array("success" => "false", "message" => "No valid coaster type id given.");
									}
								} else {
									die("Something went wrong. Please try again later. (Error: 1-5)");
								}
							} else {
								return array("success" => "false", "message" => "No valid manufacturer id given.");
							}
						} else {
							die("Something went wrong. Please try again later. (Error: 1-4)");
						}
					} else {
						return array("success" => "false", "message" => "No valid park id given.");
					}
				} else {
					die("Something went wrong. Please try again later. (Error: 1-3)");
				}
			} else {
				return array("success" => "false", "message" => "No valid build date given.");
			}
		} else {
			if(empty($safecoastername)){
				return array("success" => "false", "message" => "No coaster name given.");
			}
			if(empty($safeparkid)){
				return array("success" => "false", "message" => "No park id given.");
			}
			if(empty($safebuildyear)){
				return array("success" => "false", "message" => "No build year given.");
			}
			if(empty($safemanufacturerid)){
				return array("success" => "false", "message" => "No manufacturer id given.");
			}
			if(empty($safecoastertypeid)){
				return array("success" => "false", "message" => "No coaster type id given.");
			}
			if(empty($safecoasterheight)){
				return array("success" => "false", "message" => "No coaster height given.");
			}
			if(empty($safecoasterspeed)){
				return array("success" => "false", "message" => "No coaster speed given.");
			} else {
				return array("success" => "false", "message" => "No coaster G-Force given.");
			}
		}
	}
	
		/*
	This will allow you to add a coaster to the database.
	@param coastername The name of the coaster.
	@param parkid The ID of the park the coaster is in.
	@param buildyear The date the coaster was build.
	@param manufacturerid The ID of the coaster manufacturer.
	@param coastertypeid The ID of the coaster type.
	@param coasterheigt The height of the coaster.
	@param coasterspeed The speed of the coaster.
	@param coastergforce The G-Force of the coaster.
	@return Success or failure. (In an array.)
	*/
	function updateCoaster($coasterid = null, $coastername = null, $parkid = null, $buildyear = null, $manufacturerid = null, $coastertypeid = null, $coasterheigt = null, $coasterspeed = null, $coastergforce = null) {
		global $conn;
		
		// Make sure that the given variables cannot contain unsafe HTML code.
		$safecoasterid = htmlspecialchars($coasterid, ENT_QUOTES);
		$safecoastername = htmlspecialchars($coastername, ENT_QUOTES);
		$safeparkid = htmlspecialchars($parkid, ENT_QUOTES);
		$safebuildyear = htmlspecialchars($buildyear, ENT_QUOTES);
		$safemanufacturerid = htmlspecialchars($manufacturerid, ENT_QUOTES);
		$safecoastertypeid = htmlspecialchars($coastertypeid, ENT_QUOTES);
		$safecoasterheight = htmlspecialchars($coasterheigt, ENT_QUOTES);
		$safecoasterspeed = htmlspecialchars($coasterspeed, ENT_QUOTES);
		$safecoastergforce = htmlspecialchars($coastergforce, ENT_QUOTES);
		
		if(!empty($safecoasterid) && !empty($safecoastername) && !empty($safeparkid) && !empty($safebuildyear) && !empty($safemanufacturerid) && !empty($safecoastertypeid) && !empty($safecoasterheight) && !empty($safecoasterspeed) && !empty($safecoastergforce)){
			if(DateTime::createFromFormat('Y-m-d', $safebuildyear) !== false) {
				if($stmt = $conn->prepare("SELECT id FROM `coasters` WHERE `id` = ?")){
					$stmt->bind_param("s", $safecoasterid);
					$stmt->execute();
					$stmt->bind_result($mysqlcoasterid);
					$stmt->fetch();
					$stmt->close();
					if($mysqlcoasterid != null){
						if($stmt = $conn->prepare("SELECT id FROM `parks` WHERE `id` = ?")){
							$stmt->bind_param("s", $safeparkid);
							$stmt->execute();
							$stmt->bind_result($mysqlparkid);
							$stmt->fetch();
							$stmt->close();
							if($mysqlparkid != null){
								if($stmt = $conn->prepare("SELECT id FROM `manufacturer` WHERE `id` = ?")){
									$stmt->bind_param("s", $safemanufacturerid);
									$stmt->execute();
									$stmt->bind_result($mysqlmanufacturerid);
									$stmt->fetch();
									$stmt->close();
									if($mysqlmanufacturerid != null){
										if($stmt = $conn->prepare("SELECT id FROM `coastertypes` WHERE `id` = ?")){
											$stmt->bind_param("s", $safecoastertypeid);
											$stmt->execute();
											$stmt->bind_result($mysqlcoastertypeid);
											$stmt->fetch();
											$stmt->close();
											if($mysqlcoastertypeid != null){
												if($stmt = $conn->prepare("UPDATE `coasters` SET `name`= ?, `park`= ?, `build_year`= ?, `manufacturer`= ?, `type`= ?, `height`= ?, `speed`= ?, `gforce`= ? WHERE `id` = ?")){
													$stmt->bind_param("sssssssss", $safecoastername, $mysqlparkid, $safebuildyear, $mysqlmanufacturerid, $mysqlcoastertypeid, $safecoasterheight, $safecoasterspeed, $safecoastergforce, $mysqlcoasterid);
													$stmt->execute();
													$stmt->close();
													return array("success" => "true", "message" => "The coaster is updated.");
												} else {
													die("Something went wrong. Please try again later. (Error: 1-11)");
												}
											} else {
												return array("success" => "false", "message" => "No valid coaster type id given.");
											}
										} else {
											die("Something went wrong. Please try again later. (Error: 1-10)");
										}
									} else {
										return array("success" => "false", "message" => "No valid manufacturer id given.");
									}
								} else {
									die("Something went wrong. Please try again later. (Error: 1-9)");
								}
							} else {
								return array("success" => "false", "message" => "No valid park id given.");
							}
						} else {
							die("Something went wrong. Please try again later. (Error: 1-8)");
						}
					} else {
						return array("success" => "false", "message" => "No valid coaster id given.");
					}
				} else {
					die("Something went wrong. Please try again later. (Error: 1-7)");
				}
			} else {
				return array("success" => "false", "message" => "No valid build date given.");
			}
		} else {
			if(empty($safecoasterid)){
				return array("success" => "false", "message" => "No coaster id given.");
			}
			if(empty($safecoastername)){
				return array("success" => "false", "message" => "No coaster name given.");
			}
			if(empty($safeparkid)){
				return array("success" => "false", "message" => "No park id given.");
			}
			if(empty($safebuildyear)){
				return array("success" => "false", "message" => "No build year given.");
			}
			if(empty($safemanufacturerid)){
				return array("success" => "false", "message" => "No manufacturer id given.");
			}
			if(empty($safecoastertypeid)){
				return array("success" => "false", "message" => "No coaster type id given.");
			}
			if(empty($safecoasterheight)){
				return array("success" => "false", "message" => "No coaster height given.");
			}
			if(empty($safecoasterspeed)){
				return array("success" => "false", "message" => "No coaster speed given.");
			} else {
				return array("success" => "false", "message" => "No coaster G-Force given.");
			}
		}
	}
	
	/*
	This will give all the parks that are in the database.
	@return The parks. (In an array.)
	*/
	function getAllParksForCoasters() {
		global $conn;
		
		if($result = $conn->query("SELECT `id`, `name` FROM `parks`")){
			$rows = resultToArrayForCoasters($result);
			$result->close();
		} else {
			die("Something went wrong. Please try again later. (Error: 1-12)");
		}
		
		return $rows;
	}
	
	/*
	This will give all the manufacturers that are in the database.
	@return The manufacturers. (In an array.)
	*/
	function getAllManufacturers() {
		global $conn;
		
		if($result = $conn->query("SELECT `id`, `name` FROM `manufacturer`")){
			$rows = resultToArrayForCoasters($result);
			$result->close();
		} else {
			die("Something went wrong. Please try again later. (Error: 1-13)");
		}
		
		return $rows;
	}
	
	/*
	This will give all the manufacturers that are in the database.
	@return The manufacturers. (In an array.)
	*/
	function getAllCoasterTypes() {
		global $conn;
		
		if($result = $conn->query("SELECT `id`, `type` FROM `coastertypes`")){
			$rows = resultToArrayForCoasters($result);
			$result->close();
		} else {
			die("Something went wrong. Please try again later. (Error: 1-14)");
		}
		
		return $rows;
	}
	
	/*
	Put the multiple records that it got from the database into an array.
	@param result The result of the database query that contains the records.
	@return An array with the records from the result.
	*/
	function resultToArrayForCoasters($result) {
		$rows = array();
		while($row = $result->fetch_assoc()) {
			$rows[] = $row;
		}
		return $rows;
	}
?>