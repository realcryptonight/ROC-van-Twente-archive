<?php
	require(__DIR__ . "/../../config/connection.php");
	
	/*
	This will give all the parks that are in the database.
	@return The parks. (In an array.)
	*/
	function getAllParks() {
		global $conn;
		
		if($result = $conn->query("SELECT `parks`.`id`, `parks`.`name`, `open_since`, `owner`, `countries`.`name` as `country`, `address` FROM `parks`, `countries` WHERE `parks`.`country` = `countries`.`id`")){
			$rows = resultToArrayForParks($result);
			$result->close();
		} else {
			die("Something went wrong. Please try again later. (Error: 2-1)");
		}
		
		return $rows;
	}
	
	/*
	This will give all the parks that are in the database.
	@return The parks. (In an array.)
	*/
	function getAllCountries() {
		global $conn;
		
		if($result = $conn->query("SELECT `id`, `name` FROM `countries`")){
			$rows = resultToArrayForParks($result);
			$result->close();
		} else {
			die("Something went wrong. Please try again later. (Error: 2-2)");
		}
		
		return $rows;
	}
	
	/*
	This will give the specific data of a park that is in the database.
	@return The park. (In an array.)
	*/
	function getSpecificPark($parkid){
		global $conn;
		
		// Make sure that the given variables cannot contain unsafe HTML code.
		$safeparkid = htmlspecialchars($parkid, ENT_QUOTES);
		
		if($stmt = $conn->prepare("SELECT `parks`.`id`, `parks`.`name`, `open_since`, `owner`, `countries`.`name` as `country`, `address` FROM `parks`, `countries` WHERE `parks`.`country` = `countries`.`id` AND `parks`.`id` = ?")){
			$stmt->bind_param("s", $safeparkid);
			$stmt->execute();
			$result = $stmt->get_result();
			$rows = resultToArrayForParks($result);
			$stmt->close();
			return $rows;
		} else {
			die("Something went wrong. Please try again later. (Error: 2-3)");
		}
	}
	
	/*
	This will allow you to add a park to the database.
	@param parkname The name of the park.
	@param opensince When the park first opened.
	@param parkowner The owner of the park.
	@param country The country that the park is located in.
	@param parkaddress The address of the park.
	@return Success or failure. (In an array.)
	*/
	function createPark($parkname = null, $opensince = null, $parkowner = null, $country = null, $parkaddress = null) {
		global $conn;
		
		// Make sure that the given variables cannot contain unsafe HTML code.
		$safeparkname = htmlspecialchars($parkname, ENT_QUOTES);
		$safeopensince = htmlspecialchars($opensince, ENT_QUOTES);
		$safeparkowner = htmlspecialchars($parkowner, ENT_QUOTES);
		$safecountry = htmlspecialchars($country, ENT_QUOTES);
		$safeparkaddress = htmlspecialchars($parkaddress, ENT_QUOTES);
		
		if(!empty($safeparkname) && !empty($safeopensince) && !empty($safeparkowner) && !empty($safecountry) && !empty($safeparkaddress)){
			if(DateTime::createFromFormat('Y-m-d', $safeopensince) !== false) {
				if($stmt = $conn->prepare("SELECT id FROM `countries` WHERE `id` = ?")){
					$stmt->bind_param("s", $safecountry);
					$stmt->execute();
					$stmt->bind_result($mysqlid);
					$stmt->fetch();
					$stmt->close();
					if($mysqlid != null){
						if($stmt = $conn->prepare("INSERT INTO `parks`(`name`, `open_since`, `owner`, `country`, `address`) VALUES (?,?,?,?,?)")){
							$stmt->bind_param("sssss", $safeparkname, $safeopensince, $safeparkowner, $safecountry, $safeparkaddress);
							$stmt->execute();
							$stmt->close();
							return array("success" => "true", "message" => "The park is created.");
						} else {
							die("Something went wrong. Please try again later. (Error: 2-5)");
						}
					} else {
						return array("success" => "false", "message" => "No valid country given.");
					}
				} else {
					die("Something went wrong. Please try again later. (Error: 2-4)");
				}
			} else {
				return array("success" => "false", "message" => "No valid opening date given.");
			}
		} else {
			if(empty($safeparkname)){
				return array("success" => "false", "message" => "No park name given.");
			}
			if(empty($safeopensince)){
				return array("success" => "false", "message" => "No park opening date given.");
			}
			if(empty($safeparkowner)){
				return array("success" => "false", "message" => "No park owner given.");
			}
			if(empty($safecountry)){
				return array("success" => "false", "message" => "No park country given.");
			} else {
				return array("success" => "false", "message" => "No park address given.");
			}
		}
	}
	
	/*
	This will allow you to update a park in the database.
	@param parkid The id of the park.
	@param parkname The name of the park.
	@param opensince When the park first opened.
	@param parkowner The owner of the park.
	@param country The country that the park is located in.
	@param parkaddress The address of the park.
	@return Success or failure. (In an array.)
	*/
	function updatePark($parkid = null, $parkname = null, $opensince = null, $parkowner = null, $country = null, $parkaddress = null) {
		global $conn;
		
		// Make sure that the given variables cannot contain unsafe HTML code.
		$safeparkid = htmlspecialchars($parkid, ENT_QUOTES);
		$safeparkname = htmlspecialchars($parkname, ENT_QUOTES);
		$safeopensince = htmlspecialchars($opensince, ENT_QUOTES);
		$safeparkowner = htmlspecialchars($parkowner, ENT_QUOTES);
		$safecountry = htmlspecialchars($country, ENT_QUOTES);
		$safeparkaddress = htmlspecialchars($parkaddress, ENT_QUOTES);
		
		if(!empty($safeparkid) && !empty($safeparkname) && !empty($safeopensince) && !empty($safeparkowner) && !empty($safecountry) && !empty($safeparkaddress)){
			if(DateTime::createFromFormat('Y-m-d', $safeopensince) !== false) {
				if($stmt = $conn->prepare("SELECT id FROM `parks` WHERE `id` = ?")){
					$stmt->bind_param("s", $safeparkid);
					$stmt->execute();
					$stmt->bind_result($mysqlparkid);
					$stmt->fetch();
					$stmt->close();
					if($mysqlparkid != null){
						if($stmt = $conn->prepare("SELECT id FROM `countries` WHERE `id` = ?")){
							$stmt->bind_param("s", $safecountry);
							$stmt->execute();
							$stmt->bind_result($mysqlcountryid);
							$stmt->fetch();
							$stmt->close();
							if($mysqlcountryid != null){
								if($stmt = $conn->prepare("UPDATE `parks` SET `name`= ?, `open_since`= ?,`owner`= ?,`country`= ?,`address`= ? WHERE `id` = ?")){
									$stmt->bind_param("ssssss", $safeparkname, $safeopensince, $safeparkowner, $safecountry, $safeparkaddress, $mysqlparkid);
									$stmt->execute();
									$stmt->close();
									return array("success" => "true", "message" => "The park is updated.");
								} else {
									die("Something went wrong. Please try again later. (Error: 2-8)");
								}
							} else {
								return array("success" => "false", "message" => "No valid country given.");
							}
						} else {
							die("Something went wrong. Please try again later. (Error: 2-7)");
						}
					} else {
						return array("success" => "false", "message" => "No valid park id given.");
					}
				} else {
					die("Something went wrong. Please try again later. (Error: 2-6)");
				}
			} else {
				return array("success" => "false", "message" => "No valid opening date given.");
			}
		} else {
			if(empty($safeparkid)){
				return array("success" => "false", "message" => "No park id given.");
			}
			if(empty($safeparkname)){
				return array("success" => "false", "message" => "No park name given.");
			}
			if(empty($safeopensince)){
				return array("success" => "false", "message" => "No park opening date given.");
			}
			if(empty($safeparkowner)){
				return array("success" => "false", "message" => "No park owner given.");
			}
			if(empty($safecountry)){
				return array("success" => "false", "message" => "No park country given.");
			} else {
				return array("success" => "false", "message" => "No park address given.");
			}
		}
	}
	
	/*
	Put the multiple records that it got from the database into an array.
	@param result The result of the database query that contains the records.
	@return An array with the records from the result.
	*/
	function resultToArrayForParks($result) {
		$rows = array();
		while($row = $result->fetch_assoc()) {
			$rows[] = $row;
		}
		return $rows;
	}
?>