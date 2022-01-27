<?php

	require(__DIR__ . "/../config/connection.php");
	
	// Start a session.
	session_start();
	
	/*
	This will create a new user in the database if its possible.
	@param username The username for in the database.
	@param password The password of the new user.
	@param cpassword Same as password for correct typing check.
	@return An result array.
	*/
	function createUser($username = null, $password = null, $cpassword = null){
		global $conn;
		
		// Make sure that the given variables cannot contain unsafe HTML code.
		$username = htmlspecialchars($username, ENT_QUOTES);
		$password = htmlspecialchars($password, ENT_QUOTES);
		$cpassword = htmlspecialchars($cpassword, ENT_QUOTES);
		
		if(!empty($username) && !empty($password) && !empty($cpassword)){
			if($password == $cpassword){
				if(strlen($username) < 51){
					if(strlen($password) > 5 && strlen($password) < 31){
						if($stmt = $conn->prepare("SELECT id FROM `Users` WHERE `username` = ?")){
							$stmt->bind_param("s", $username);
							$stmt->execute();
							$stmt->bind_result($mysqlid);
							$stmt->fetch();
							$stmt->close();
							if($mysqlid == null){
								if($stmt = $conn->prepare("INSERT INTO `Users`(`username`, `password`) VALUES (?,?)")){
									$tmppwd = password_hash($password, PASSWORD_BCRYPT, array("salt" => "eqwty43b5vw46b!(&*^&fw3twertwqr"));
									$stmt->bind_param("ss", $username,$tmppwd);
									$stmt->execute();
									$stmt->close();
									return array("success" => "true", "message" => "You are now registered.");
								} else {
									die("Something went wrong. Please try again later. (Error: 3-2)");
								}
							} else {
								return array("success" => "false", "message" => "The username is already taken.");
							}
						} else {
							die("Something went wrong. Please try again later. (Error: 3-1)");
						}
					} else {
						return array("success" => "false", "message" => "Your password needs to be between 6 and 30 charakters long.");
					}
				} else {
					return array("success" => "false", "message" => "Your username is too long. Max 50 charakters.");
				}
			} else {
				return array("success" => "false", "message" => "No matching passwords given.");
			}
		} else {
			if(empty($username)){
				return array("success" => "false", "message" => "No username given.");
			}
			if(empty($password)){
				return array("success" => "false", "message" => "No password given.");
			} else {
				return array("success" => "false", "message" => "No password repeat given.");
			}
		}
	}
	
	/*
	Main entry for authenticating an user.
	Please note that session authentication is prefered if possible.
	@param username The username of the user.
	@param password The password of that user.
	@return An result array.
	*/
	function authenticate($username = null, $password = null) {
		if(isset($_SESSION["session_id"])){
			return authenticateSession();
		} else {
			return authenticateUsernameAndPassword($username, $password);
		}
	}
	
	/*
	Allows an user to be authenticated with a session.
	Please do NOT use this function but use authenticate() instead.
	*/
	function authenticateSession(){
		global $conn;
		
		// Make sure that the given variables cannot contain unsafe HTML code.
		$session_randomid = htmlspecialchars($_SESSION["session_id"], ENT_QUOTES);
		
		if(!empty($session_randomid)){
			if($stmt = $conn->prepare("SELECT id FROM `Users` WHERE `session_id` = ?")){
				$stmt->bind_param("s", $session_randomid);
				$stmt->execute();
				$stmt->bind_result($mysqlid);
				$stmt->fetch();
				$stmt->close();
				if($mysqlid != null){
						return array("success" => "true", "message" => "User is logged in.");
				} else {
					session_destroy();
					session_start();
					return array("success" => "false", "message" => "Session does not match.");
				}
			} else {
				die("Something went wrong. Please try again later. (Error: 3-3)");
			}
		} else {
			return array("success" => "false", "message" => "No session id found.");
		}
	}
	
	/*
	Allows an user to be authenticated with a username and password.
	Please do NOT use this function but use authenticate() instead.
	*/
	function authenticateUsernameAndPassword($username = null, $password = null){
		global $conn;
		
		// Make sure that the given variables cannot contain unsafe HTML code.
		$username = htmlspecialchars($username, ENT_QUOTES);
		$password = htmlspecialchars($password, ENT_QUOTES);
		
		if(!empty($username) && !empty($password)){
			if($stmt = $conn->prepare("SELECT id FROM `Users` WHERE `username` = ? AND `password` = ?")){
				$encryptedpassword = password_hash($password, PASSWORD_BCRYPT, array("salt" => "eqwty43b5vw46b!(&*^&fw3twertwqr"));
				$stmt->bind_param("ss", $username, $encryptedpassword);
				$stmt->execute();
				$stmt->bind_result($mysqlid);
				$stmt->fetch();
				$stmt->close();
				if($mysqlid != null){
					if($stmt = $conn->prepare("UPDATE `Users` SET `session_id` = ? WHERE `id` = ? AND `username` = ?")){
						$session_randomid = generateRandomString() . $mysqlid . generateRandomString();
						$stmt->bind_param("sss", $session_randomid, $mysqlid, $username);
						$stmt->execute();
						$stmt->close();
						$_SESSION["session_id"] = $session_randomid;
						return array("success" => "true", "message" => "User is logged in.");
					} else {
						die("Something went wrong. Please try again later. (Error: 3-5)");
					}
				} else {
					return array("success" => "false", "message" => "Username or password incorrect.");
				}
			} else {
				die("Something went wrong. Please try again later. (Error: 3-4)");
			}
		} else {
			if(empty($username)){
				return array("success" => "false", "message" => "No username given.");
			} else {
				return array("success" => "false", "message" => "No password given.");
			}
		}
	}
	
	/*
	Get the username that belongs to the session_id.
	@param $_SESSION["session_id"] The session id itself.
	@return result array.
	*/
	function getUsername() {
		global $conn;
		
		// Make sure that the given variables cannot contain unsafe HTML code.
		$session_randomid = htmlspecialchars($_SESSION["session_id"], ENT_QUOTES);
		
		if(!empty($session_randomid)){
			if($stmt = $conn->prepare("SELECT id,username FROM `Users` WHERE `session_id` = ?")){
				$stmt->bind_param("s", $session_randomid);
				$stmt->execute();
				$stmt->bind_result($mysqlid, $mysqlusername);
				$stmt->fetch();
				$stmt->close();
				if($mysqlid != null){
					return array("success" => "true", "message" => $mysqlusername);
				} else {
					session_destroy();
					session_start();
					return array("success" => "false", "message" => "Session does not match.");
				}
			} else {
				die("Something went wrong. Please try again later. (Error: 3-6)");
			}
		} else {
			return array("success" => "false", "message" => "No session id found.");
		}
	}
	
	/*
	Change the username of an existing user.
	@param $_SESSION["session_id"] The session id of the user.
	@param newusername The new username for the existing user.
	@param password The password of the existing user for validation.
	@return Result array.
	*/
	function updateUsername($newusername = null, $password = null) {
		global $conn;
		
		// Make sure that the given variables cannot contain unsafe HTML code.
		$newusername = htmlspecialchars($newusername, ENT_QUOTES);
		$password = htmlspecialchars($password, ENT_QUOTES);
		$session_randomid = htmlspecialchars($_SESSION["session_id"], ENT_QUOTES);
		
		if(!empty($session_randomid) && !empty($newusername) && !empty($password)){
			if(strlen($newusername) < 51){
				if($stmt = $conn->prepare("SELECT id FROM `Users` WHERE `session_id` = ?")){
					$stmt->bind_param("s", $session_randomid);
					$stmt->execute();
					$stmt->bind_result($mysqlid);
					$stmt->fetch();
					$stmt->close();
					if($mysqlid != null){
						// I do not like that I need to query the database 2 times to check if the user is really the user.
						// But otherwise I cannot tell if its due to the session or invalid password. :(
						if($stmt = $conn->prepare("SELECT id FROM `Users` WHERE `session_id` = ? AND `password` = ?")){
							$encryptedpassword = password_hash($password, PASSWORD_BCRYPT, array("salt" => "eqwty43b5vw46b!(&*^&fw3twertwqr"));
							$stmt->bind_param("ss", $session_randomid, $encryptedpassword);
							$stmt->execute();
							$stmt->bind_result($mysqlid2);
							$stmt->fetch();
							$stmt->close();
							if($mysqlid2 != null){
								if($stmt = $conn->prepare("SELECT id FROM `Users` WHERE `username` = ?")){
									$stmt->bind_param("s", $newusername);
									$stmt->execute();
									$stmt->bind_result($mysqlid3);
									$stmt->fetch();
									$stmt->close();
									if($mysqlid3 == null){
										if($stmt = $conn->prepare("UPDATE `users` SET `username`= ? WHERE `id` = ?")){
											$stmt->bind_param("ss", $newusername, $mysqlid2);
											$stmt->execute();
											$stmt->close();
											return array("success" => "true", "message" => "The username is changed.");
										} else {
											die("Something went wrong. Please try again later. (Error: 3-10)");
										}
									} else {
										return array("success" => "false", "message" => "The username is already taken.");
									}
								} else {
									die("Something went wrong. Please try again later. (Error: 3-9)");
								}
							} else {
								return array("success" => "false", "message" => "Password incorrect.");
							}
						} else {
							die("Something went wrong. Please try again later. (Error: 3-8)");
						}
					} else {
						session_destroy();
						session_start();
						return array("success" => "false", "message" => "Session does not match.");
					}
				} else {
					die("Something went wrong. Please try again later. (Error: 3-7)");
				}
			} else {
				return array("success" => "false", "message" => "Your username is too long. Max 50 charakters.");
			}
		} else {
			if(empty($_SESSION["session_id"])){
				return array("success" => "false", "message" => "No session id found.");
			}
			if(empty($newusername)){
				return array("success" => "false", "message" => "No new username given.");
			} else {
				return array("success" => "false", "message" => "No password given.");
			}
		}
	}
	
	/*
	Update the password of a user.
	@param $_SESSION["session_id"] The session id of the user.
	@param oldpassword The old password of the user.
	@param newpassword The new passsword for the user.
	@param cnewpassword An repeat of the newpassword.
	*/
	function updatePassword($oldpassword = null, $newpassword = null, $cnewpassword = null) {
		global $conn;
		
		// Make sure that the given variables cannot contain unsafe HTML code.
		$oldpassword = htmlspecialchars($oldpassword, ENT_QUOTES);
		$newpassword = htmlspecialchars($newpassword, ENT_QUOTES);
		$cnewpassword = htmlspecialchars($cnewpassword, ENT_QUOTES);
		$session_randomid = htmlspecialchars($_SESSION["session_id"], ENT_QUOTES);
		
		if(!empty($session_randomid) && !empty($oldpassword) && !empty($newpassword) && !empty($cnewpassword)){
			if($newpassword == $cnewpassword){
				if(strlen($newpassword) > 5 && strlen($newpassword) < 31){
					if($stmt = $conn->prepare("SELECT id FROM `Users` WHERE `session_id` = ?")){
						$stmt->bind_param("s", $session_randomid);
						$stmt->execute();
						$stmt->bind_result($mysqlid);
						$stmt->fetch();
						$stmt->close();
						if($mysqlid != null){
							if($stmt = $conn->prepare("UPDATE `users` SET `password` = ? WHERE `id` = ?")){
								$tmppwd = password_hash($newpassword, PASSWORD_BCRYPT, array("salt" => "eqwty43b5vw46b!(&*^&fw3twertwqr"));
								$stmt->bind_param("ss", $tmppwd, $mysqlid);
								$stmt->execute();
								$stmt->close();
								return array("success" => "true", "message" => "The password is changed.");
							} else {
								die("Something went wrong. Please try again later. (Error: 3-12)");
							}
						} else {
							session_destroy();
							session_start();
							return array("success" => "false", "message" => "Session does not match.");
						}
					} else {
						die("Something went wrong. Please try again later. (Error: 3-11)");
					}
				} else {
					return array("success" => "false", "message" => "Your password needs to be between 6 and 30 charakters long.");
				}
			} else {
				return array("success" => "false", "message" => "No matching passwords given.");
			}
		} else {
			if(empty($_SESSION["session_id"])){
				return array("success" => "false", "message" => "No session id found.");
			}
			if(empty($oldpassword)){
				return array("success" => "false", "message" => "No password given.");
			}
			if(empty($newpassword)){
				return array("success" => "false", "message" => "No new password given.");
			} else {
				return array("success" => "false", "message" => "No new repeat password given.");
			}
		}
	}
	
	/* This will generate a random string of chars and numbers.
	 * @param length The amount of random chars/letters. (Default is 10.)
	 * @return A random string.
	*/
	function generateRandomString($length = 10) {
		return substr(str_shuffle(str_repeat($x='0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ', ceil($length/strlen($x)) )),1,$length);
	}
?>