<?php
	// Require some php files for testing them.
	require(__DIR__ . "/login/authenticate.php");
	require(__DIR__ . "/parks/backend/proccessor.php");
	require(__DIR__ . "/coasters/backend/proccessor.php");
	
	// These variables store the correct data for after the register test.
	$useusername = "Daniel";
	$usepassword = "AnPassword";
	$anusernamethatexists = "DanielMarkink";
	
	/*
	Print any array in an human friendly way to the browser.
	@param array The array that needs to be printed human friendly.
	*/
	function printArrayHumanReadible($array) {
		echo "<pre>";
		print_r($array);
		echo "</pre>";
	}
	
	/*
	Test if the user registeration work as expected in the backend.
	*/
	function registerUserTest(){
		global $useusername, $usepassword, $anusernamethatexists;
		$test1 = createUser();
		if($test1["success"] != "false" || $test1["message"] != "No username given."){
			return array("success" => "false", "message" => "Failed the test1 test.");
		}
		
		$test2 = createUser($useusername);
		if($test2["success"] != "false" || $test2["message"] != "No password given."){
			return array("success" => "false", "message" => "Failed the test2 test.");
		}
		
		$test3 = createUser($useusername, $usepassword);
		if($test3["success"] != "false" || $test3["message"] != "No password repeat given."){
			return array("success" => "false", "message" => "Failed the test3 test.");
		}
		
		$test4 = createUser($useusername, $usepassword, "AnotherPassword");
		if($test4["success"] != "false" || $test4["message"] != "No matching passwords given."){
			return array("success" => "false", "message" => "Failed the test4 test.");
		}
		
		$test5 = createUser("DanielMarkink12345678912345678912345678912345678912", $usepassword, $usepassword);
		if($test5["success"] != "false" || $test5["message"] != "Your username is too long. Max 50 charakters."){
			return array("success" => "false", "message" => "Failed the test5 test.");
		}
		
		$test6 = createUser($useusername, "An", "An");
		if($test6["success"] != "false" || $test6["message"] != "Your password needs to be between 6 and 30 charakters long."){
			return array("success" => "false", "message" => "Failed the test6 test.");
		}
		
		$test7 = createUser($useusername, "AnPasswordpasswordmartgdwg45th1", "AnPasswordpasswordmartgdwg45th1");
		if($test7["success"] != "false" || $test7["message"] != "Your password needs to be between 6 and 30 charakters long."){
			return array("success" => "false", "message" => "Failed the test7 test.");
		}
		
		$test8 = createUser("DanielMarkink", $usepassword, $usepassword);
		if($test8["success"] != "false" || $test8["message"] != "The username is already taken."){
			return array("success" => "false", "message" => "Failed the test8 test.");
		}
		
		$test9 = createUser($useusername, $usepassword, $usepassword);
		if($test9["success"] != "true" || $test9["message"] != "You are now registered."){
			return array("success" => "false", "message" => "Failed the test9 test.");
		}
		
		return array("success" => "true", "message" => "All testRegister() tests where successfull.");
	}
	
	/*
	Test if the user login part work as expected in the backend.
	*/
	function loginUserTest() {
		global $useusername, $usepassword;
		
		$test1 = authenticate();
		if($test1["success"] != "false" || $test1["message"] != "No username given."){
			return array("success" => "false", "message" => "Failed the test1 test.");
		}
		
		$test2 = authenticate($useusername);
		if($test2["success"] != "false" || $test2["message"] != "No password given."){
			return array("success" => "false", "message" => "Failed the test2 test.");
		}
		
		$test3 = authenticate("Danieldsds", $usepassword);
		if($test3["success"] != "false" || $test3["message"] != "Username or password incorrect."){
			return array("success" => "false", "message" => "Failed the test3 test.");
		}
		
		$test4 = authenticate($useusername, "APassword");
		if($test4["success"] != "false" || $test4["message"] != "Username or password incorrect."){
			return array("success" => "false", "message" => "Failed the test4 test.");
		}
		
		$test5 = authenticate($useusername, $usepassword);
		if($test5["success"] != "true" || $test5["message"] != "User is logged in."){
			return array("success" => "false", "message" => "Failed the test5 test.");
		}
		
		$test6 = authenticate();
		if($test6["success"] != "true" || $test6["message"] != "User is logged in."){
			return array("success" => "false", "message" => "Failed the test6 test.");
		}
		
		$_SESSION["session_id"] = "ItWillNotWork.";
		$test7 = authenticate();
		if($test7["success"] != "false" || $test7["message"] != "Session does not match."){
			return array("success" => "false", "message" => "Failed the test7 test.");
		}
		
		$_SESSION["session_id"] = null;
		
		// We cannot call the authenticate() for trying to authenticate an non existing session.
		// So we need to force it.
		$test8 = authenticateSession();
		if($test8["success"] != "false" || $test8["message"] != "No session id found."){
			return array("success" => "false", "message" => "Failed the test8 test.");
		}
		
		$test9 = authenticate($useusername, $usepassword);
		if($test9["success"] != "true" || $test9["message"] != "User is logged in."){
			return array("success" => "false", "message" => "Failed the test9 test.");
		}
		
		return array("success" => "true", "message" => "All loginUserTest() tests where successfull.");
	}
	
	/*
	Test if the getUsername function works as expected.
	*/
	function getUsernameTest() {
		global $useusername, $usepassword;
		
		$test1 = getUsername();
		if($test1["success"] != "true" || $test1["message"] != $useusername){
			return array("success" => "false", "message" => "Failed the test1 test.");
		}
		
		$_SESSION["session_id"] = "ItWillNotWork.";
		$test2 = getUsername();
		if($test2["success"] != "false" || $test2["message"] != "Session does not match."){
			return array("success" => "false", "message" => "Failed the test2 test.");
		}
		
		$_SESSION["session_id"] = null;
		$test3 = getUsername();
		if($test3["success"] != "false" || $test3["message"] != "No session id found."){
			return array("success" => "false", "message" => "Failed the test3 test.");
		}
		
		// Reauthenticate the user since we removed the session_id.
		authenticate($useusername, $usepassword);
		return array("success" => "true", "message" => "All getUsernameTest() tests where successfull.");
	}
	
	/*
	Test if the updateUsername function works as expected.
	*/
	function updateUsernameTest() {
		global $useusername, $usepassword, $anusernamethatexists;
		
		$_SESSION["session_id"] = null;
		$test1 = updateUsername();
		if($test1["success"] != "false" || $test1["message"] != "No session id found."){
			return array("success" => "false", "message" => "Failed the test1 test.");
		}
		
		// Reauthenticate the user since we removed the session_id.
		authenticate($useusername, $usepassword);
		
		$test2 = updateUsername();
		if($test2["success"] != "false" || $test2["message"] != "No new username given."){
			return array("success" => "false", "message" => "Failed the test2 test.");
		}
		
		$test3 = updateUsername("Daniel1");
		if($test3["success"] != "false" || $test3["message"] != "No password given."){
			return array("success" => "false", "message" => "Failed the test3 test.");
		}
		
		$_SESSION["session_id"] = "fsdggergwegs";
		$test4 = updateUsername("Daniel1" , $usepassword);
		if($test4["success"] != "false" || $test4["message"] != "Session does not match."){
			return array("success" => "false", "message" => "Failed the test4 test.");
		}
		
		// Reauthenticate the user since we invalidated the session_id.
		authenticate($useusername, $usepassword);
		
		$test5 = updateUsername($anusernamethatexists , $usepassword);
		if($test5["success"] != "false" || $test5["message"] != "The username is already taken."){
			return array("success" => "false", "message" => "Failed the test5 test.");
		}
		
		$test6 = updateUsername("DanielMarkink12345678912345678912345678912345678912", $usepassword);
		if($test6["success"] != "false" || $test6["message"] != "Your username is too long. Max 50 charakters."){
			return array("success" => "false", "message" => "Failed the test6 test.");
		}
		
		$test7 = updateUsername("Daniel1" , $usepassword);
		if($test7["success"] != "true" || $test7["message"] != "The username is changed."){
			return array("success" => "false", "message" => "Failed the test7 test.");
		}
		
		$useusername = "Daniel1";
		return array("success" => "true", "message" => "All updateUsernameTest() tests where successfull.");
	}
	
	/*
	Test if the updatePassword function works as expected.
	*/
	function updatePasswordTest() {
		global $useusername, $usepassword;
		
		$_SESSION["session_id"] = null;
		$test1 = updatePassword();
		if($test1["success"] != "false" || $test1["message"] != "No session id found."){
			return array("success" => "false", "message" => "Failed the test1 test.");
		}
		
		// Reauthenticate the user since we removed the session_id.
		authenticate($useusername, $usepassword);
		
		$test2 = updatePassword();
		if($test2["success"] != "false" || $test2["message"] != "No password given."){
			return array("success" => "false", "message" => "Failed the test2 test.");
		}
		
		$test3 = updatePassword($usepassword);
		if($test3["success"] != "false" || $test3["message"] != "No new password given."){
			return array("success" => "false", "message" => "Failed the test3 test.");
		}
		
		$test4 = updatePassword($usepassword, "fdsghergergs");
		if($test4["success"] != "false" || $test4["message"] != "No new repeat password given."){
			return array("success" => "false", "message" => "Failed the test4 test.");
		}
		
		$test5 = updatePassword($usepassword, "fdsghergergs", "sagfds");
		if($test5["success"] != "false" || $test5["message"] != "No matching passwords given."){
			return array("success" => "false", "message" => "Failed the test5 test.");
		}
		
		$test6 = updatePassword($usepassword, "dsg", "dsg");
		if($test6["success"] != "false" || $test6["message"] != "Your password needs to be between 6 and 30 charakters long."){
			return array("success" => "false", "message" => "Failed the test6 test.");
		}
		
		$test7 = updatePassword($usepassword, "dsgsgsrjdj7edfhkjfjhrehjrtehderth", "dsgsgsrjdj7edfhkjfjhrehjrtehderth");
		if($test7["success"] != "false" || $test7["message"] != "Your password needs to be between 6 and 30 charakters long."){
			printArrayHumanReadible($test7);
			return array("success" => "false", "message" => "Failed the test7 test.");
		}
		
		$_SESSION["session_id"] = "fsdggergwegs";
		$test8 = updatePassword($usepassword, "APassword", "APassword");
		if($test8["success"] != "false" || $test8["message"] != "Session does not match."){
			return array("success" => "false", "message" => "Failed the test8 test.");
		}

		// Reauthenticate the user since we invalidated the session_id.
		authenticate($useusername, $usepassword);
		
		$test9 = updatePassword($usepassword, "APassword", "APassword");
		if($test9["success"] != "true" || $test9["message"] != "The password is changed."){
			return array("success" => "false", "message" => "Failed the test9 test.");
		}
		
		$usepassword = "APassword";
		
		$test10 = authenticate($useusername, $usepassword);
		if($test10["success"] != "true" || $test10["message"] != "User is logged in."){
			return array("success" => "false", "message" => "Failed the test10 test.");
		}
		
		return array("success" => "true", "message" => "All updatePasswordTest() tests where successfull.");
	}
	
	/*
	Test if the addPark function works as expected.
	*/
	function createParkTest() {
		$test1 = createPark();
		if($test1["success"] != "false" || $test1["message"] != "No park name given."){
			return array("success" => "false", "message" => "Failed the test1 test.");
		}
		$test2 = createPark("Daniels");
		if($test2["success"] != "false" || $test2["message"] != "No park opening date given."){
			return array("success" => "false", "message" => "Failed the test2 test.");
		}
		$test3 = createPark("Daniels", "2002-4-2");
		if($test3["success"] != "false" || $test3["message"] != "No park owner given."){
			return array("success" => "false", "message" => "Failed the test3 test.");
		}
		$test4 = createPark("Daniels", "2002-4-2", "Daniel Markink");
		if($test4["success"] != "false" || $test4["message"] != "No park country given."){
			return array("success" => "false", "message" => "Failed the test4 test.");
		}
		$test5 = createPark("Daniels", "2002-4-2", "Daniel Markink", 34);
		if($test5["success"] != "false" || $test5["message"] != "No park address given."){
			return array("success" => "false", "message" => "Failed the test5 test.");
		}
		$test6 = createPark("Daniels", "notavaliddate", "Daniel Markink", 34, "My home");
		if($test6["success"] != "false" || $test6["message"] != "No valid opening date given."){
			return array("success" => "false", "message" => "Failed the test6 test.");
		}
		$test7 = createPark("Daniels", "2002-4-2", "Daniel Markink", 34, "My home");
		if($test7["success"] != "false" || $test7["message"] != "No valid country given."){
			return array("success" => "false", "message" => "Failed the test7 test.");
		}
		$test8 = createPark("Daniels", "2002-4-2", "Daniel Markink", 2, "My home");
		if($test8["success"] != "true" || $test8["message"] != "The park is created."){
			return array("success" => "false", "message" => "Failed the test8 test.");
		}
		
		return array("success" => "true", "message" => "All addParkTest() tests where successfull.");
	}
	
	/*
	Test if the updatePark function works as expected.
	*/
	function updateParkTest() {
		$test1 = updatePark();
		if($test1["success"] != "false" || $test1["message"] != "No park id given."){
			return array("success" => "false", "message" => "Failed the test1 test.");
		}
		$test2 = updatePark(3);
		if($test2["success"] != "false" || $test2["message"] != "No park name given."){
			return array("success" => "false", "message" => "Failed the test2 test.");
		}
		$test3 = updatePark(3, "Daniels");
		if($test3["success"] != "false" || $test3["message"] != "No park opening date given."){
			return array("success" => "false", "message" => "Failed the test3 test.");
		}
		$test4 = updatePark(3, "Daniels", "2002-4-2");
		if($test4["success"] != "false" || $test4["message"] != "No park owner given."){
			return array("success" => "false", "message" => "Failed the test4 test.");
		}
		$test5 = updatePark(3, "Daniels", "2002-4-2", "Daniel Markink");
		if($test5["success"] != "false" || $test5["message"] != "No park country given."){
			return array("success" => "false", "message" => "Failed the test5 test.");
		}
		$test6 = updatePark(3, "Daniels", "2002-4-2", "Daniel Markink", 34);
		if($test6["success"] != "false" || $test6["message"] != "No park address given."){
			return array("success" => "false", "message" => "Failed the test6 test.");
		}
		$test7 = updatePark(3, "Daniels", "notavaliddate", "Daniel Markink", 34, "My home");
		if($test7["success"] != "false" || $test7["message"] != "No valid opening date given."){
			return array("success" => "false", "message" => "Failed the test7 test.");
		}
		$test8 = updatePark(34264356436, "Daniels", "2002-4-2", "Daniel Markink", 34, "My home");
		if($test8["success"] != "false" || $test8["message"] != "No valid park id given."){
			return array("success" => "false", "message" => "Failed the test8 test.");
		}
		$test9 = updatePark(3, "Daniels", "2002-4-2", "Daniel Markink", 34, "My home");
		if($test9["success"] != "false" || $test9["message"] != "No valid country given."){
			printArrayHumanReadible($test9);
			return array("success" => "false", "message" => "Failed the test9 test.");
		}
		$test10 = updatePark(3, "Daniels", "2002-4-2", "Daniel Markink", 2, "Not my home");
		if($test10["success"] != "true" || $test10["message"] != "The park is updated."){
			return array("success" => "false", "message" => "Failed the test10 test.");
		}
		return array("success" => "true", "message" => "All updateParkTest() tests where successfull.");
	}
	
	/*
	Test if the createCoaster function works as expected.
	*/
	function createCoasterTest() {
		$test1 = createCoaster();
		if($test1["success"] != "false" || $test1["message"] != "No coaster name given."){
			return array("success" => "false", "message" => "Failed the test1 test.");
		}
		$test2 = createCoaster("Untamed");
		if($test2["success"] != "false" || $test2["message"] != "No park id given."){
			return array("success" => "false", "message" => "Failed the test2 test.");
		}
		$test3 = createCoaster("Untamed", 1);
		if($test3["success"] != "false" || $test3["message"] != "No build year given."){
			return array("success" => "false", "message" => "Failed the test3 test.");
		}
		$test4 = createCoaster("Untamed", 1, "2018-6-19");
		if($test4["success"] != "false" || $test4["message"] != "No manufacturer id given."){
			return array("success" => "false", "message" => "Failed the test4 test.");
		}
		$test5 = createCoaster("Untamed", 1, "2018-6-19", 1);
		if($test5["success"] != "false" || $test5["message"] != "No coaster type id given."){
			return array("success" => "false", "message" => "Failed the test5 test.");
		}
		$test6 = createCoaster("Untamed", 1, "2018-6-19", 1, 1);
		if($test6["success"] != "false" || $test6["message"] != "No coaster height given."){
			return array("success" => "false", "message" => "Failed the test6 test.");
		}
		$test7 = createCoaster("Untamed", 1, "2018-6-19", 1, 1, 100.5);
		if($test7["success"] != "false" || $test7["message"] != "No coaster speed given."){
			return array("success" => "false", "message" => "Failed the test7 test.");
		}
		$test8 = createCoaster("Untamed", 1, "2018-6-19", 1, 1, 100.4, 90.5);
		if($test8["success"] != "false" || $test8["message"] != "No coaster G-Force given."){
			return array("success" => "false", "message" => "Failed the test8 test.");
		}
		$test9 = createCoaster("Untamed", 999999999, "2018-6-19", 1, 1, 100.4, 90.5, -1);
		if($test9["success"] != "false" || $test9["message"] != "No valid park id given."){
			return array("success" => "false", "message" => "Failed the test9 test.");
		}
		$test10 = createCoaster("Untamed", 1, "2018-6-19", 9999999, 1, 100.4, 90.5, -1);
		if($test10["success"] != "false" || $test10["message"] != "No valid manufacturer id given."){
			return array("success" => "false", "message" => "Failed the test10 test.");
		}
		$test11 = createCoaster("Untamed", 1, "2018-6-19", 1, 99999999, 100.4, 90.5, -1);
		if($test11["success"] != "false" || $test11["message"] != "No valid coaster type id given."){
			return array("success" => "false", "message" => "Failed the test11 test.");
		}
		$test12 = createCoaster("Untamed", 1, "notavaliddate", 1, 99999999, 100.4, 90.5, -1);
		if($test12["success"] != "false" || $test12["message"] != "No valid build date given."){
			return array("success" => "false", "message" => "Failed the test12 test.");
		}
		$test13 = createCoaster("Untamed", 1, "2018-6-19", 1, 1, 100.4, 90.5, -1);
		if($test13["success"] != "true" || $test13["message"] != "The coaster is created."){
			return array("success" => "false", "message" => "Failed the test13 test.");
		}
		
		return array("success" => "true", "message" => "All addParkTest() tests where successfull.");
	}
	
	/*
	Test if the createCoaster function works as expected.
	*/
	function editCoasterTest() {
		$test1 = updateCoaster();
		if($test1["success"] != "false" || $test1["message"] != "No coaster id given."){
			return array("success" => "false", "message" => "Failed the test1 test.");
		}
		$test2 = updateCoaster(3);
		if($test2["success"] != "false" || $test2["message"] != "No coaster name given."){
			return array("success" => "false", "message" => "Failed the test2 test.");
		}
		$test3 = updateCoaster(3, "Untamed");
		if($test3["success"] != "false" || $test3["message"] != "No park id given."){
			return array("success" => "false", "message" => "Failed the test3 test.");
		}
		$test4 = updateCoaster(3, "Untamed", 1);
		if($test4["success"] != "false" || $test4["message"] != "No build year given."){
			return array("success" => "false", "message" => "Failed the test4 test.");
		}
		$test5 = updateCoaster(3, "Untamed", 1, "2018-6-19");
		if($test5["success"] != "false" || $test5["message"] != "No manufacturer id given."){
			return array("success" => "false", "message" => "Failed the test5 test.");
		}
		$test6 = updateCoaster(3, "Untamed", 1, "2018-6-19", 1);
		if($test6["success"] != "false" || $test6["message"] != "No coaster type id given."){
			return array("success" => "false", "message" => "Failed the test6 test.");
		}
		$test7 = updateCoaster(3, "Untamed", 1, "2018-6-19", 1, 1);
		if($test7["success"] != "false" || $test7["message"] != "No coaster height given."){
			return array("success" => "false", "message" => "Failed the test7 test.");
		}
		$test8 = updateCoaster(3, "Untamed", 1, "2018-6-19", 1, 1, 100.5);
		if($test8["success"] != "false" || $test8["message"] != "No coaster speed given."){
			return array("success" => "false", "message" => "Failed the test8 test.");
		}
		$test9 = updateCoaster(3, "Untamed", 1, "2018-6-19", 1, 1, 100.4, 90.5);
		if($test9["success"] != "false" || $test9["message"] != "No coaster G-Force given."){
			return array("success" => "false", "message" => "Failed the test9 test.");
		}
		$test10 = updateCoaster(999999999, "Untamed", 1, "2018-6-19", 1, 1, 100.4, 90.5, 3.4);
		if($test10["success"] != "false" || $test10["message"] != "No valid coaster id given."){
			return array("success" => "false", "message" => "Failed the test10 test.");
		}
		$test11 = updateCoaster(3, "Untamed", 999999999, "2018-6-19", 1, 1, 100.4, 90.5, -1);
		if($test11["success"] != "false" || $test11["message"] != "No valid park id given."){
			return array("success" => "false", "message" => "Failed the test11 test.");
		}
		$test12 = updateCoaster(3, "Untamed", 1, "2018-6-19", 9999999, 1, 100.4, 90.5, -1);
		if($test12["success"] != "false" || $test12["message"] != "No valid manufacturer id given."){
			return array("success" => "false", "message" => "Failed the test12 test.");
		}
		$test13 = updateCoaster(3, "Untamed", 1, "2018-6-19", 1, 99999999, 100.4, 90.5, -1);
		if($test13["success"] != "false" || $test13["message"] != "No valid coaster type id given."){
			return array("success" => "false", "message" => "Failed the test13 test.");
		}
		$test14 = updateCoaster(3, "Untamed", 1, "notavaliddate", 1, 99999999, 100.4, 90.5, -1);
		if($test14["success"] != "false" || $test14["message"] != "No valid build date given."){
			return array("success" => "false", "message" => "Failed the test14 test.");
		}
		$test15 = updateCoaster(3, "Untamed", 1, "2018-6-19", 1, 1, 100.4, 90.5, -1);
		if($test15["success"] != "true" || $test15["message"] != "The coaster is updated."){
			return array("success" => "false", "message" => "Failed the test15 test.");
		}
		
		return array("success" => "true", "message" => "All updateParkTest() tests where successfull.");
	}
	
	/*
	Clean up everthing the test has created.
	*/
	function cleanUp() {
		global $conn, $useusername;
		if($stmt = $conn->prepare("DELETE FROM `Users` WHERE `username` = ?")){
			$stmt->bind_param("s", $useusername);
			$stmt->execute();
			$stmt->close();
		}
		session_destroy();
		session_start();
	}
	
	// Clean the session. Just to be safe :)
	session_destroy();
	session_start();
	
	// Test the user registration.
	$createUserTest = registerUserTest();
	if($createUserTest["success"] == "false"){
		die(printArrayHumanReadible($createUserTest));
	} else {
		echo "Registeration tests where successfull.<br>";
	}
	
	// Test the user login.
	$loginUserTest = loginUserTest();
	if($loginUserTest["success"] == "false"){
		die(printArrayHumanReadible($loginUserTest));
	} else {
		echo "Login tests where successfull.<br>";
	}
	
	// Test the getUsername function.
	$getusername = getUsernameTest();
	if($getusername["success"] == "false"){
		die(printArrayHumanReadible($getusername));
	} else {
		echo "Get username tests where successfull.<br>";
	}
	
	// Test the update username function.
	$updateusername = updateUsernameTest();
	if($updateusername["success"] == "false"){
		die(printArrayHumanReadible($updateusername));
	} else {
		echo "Update username tests where successfull.<br>";
		
	}
	
	// Test the update password function.
	$updatepassword = updatePasswordTest();
	if($updatepassword["success"] == "false"){
		die(printArrayHumanReadible($updatepassword));
	} else {
		echo "Update password tests where successfull.<br>";
	}
	
	// Test the add park function.
	$createpark = createParkTest();
	if($createpark["success"] == "false"){
		die(printArrayHumanReadible($createpark));
	} else {
		echo "Add park tests where successfull.<br>";
	}
	
	// Test the update park function.
	$updatepark = updateParkTest();
	if($updatepark["success"] == "false"){
		die(printArrayHumanReadible($updatepark));
	} else {
		echo "Update park tests where successfull.<br>";
	}
	// Test the create coaster function.
	$createcoaster = createCoasterTest();
	if($createcoaster["success"] == "false"){
		die(printArrayHumanReadible($createcoaster));
	} else {
		echo "Create coaster tests where successfull.<br>";
	}
	
	// Test the edit coaster function.
	$editcoaster = editCoasterTest();
	if($editcoaster["success"] == "false"){
		die(printArrayHumanReadible($editcoaster));
	} else {
		echo "Edit coaster tests where successfull.<br>";
	}
	
	cleanUp();
	echo "All test where successfull.<br>";
?>