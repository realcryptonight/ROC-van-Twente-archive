<?php
	require(__DIR__ . "/../login/authenticate.php");
	
	// For this page you need to be logged in.
	if(authenticate()["success"] != "true"){
		header('Location: ../login/');
	}
	
	// Check if the templete page file exists and get its contents if it does.
	if(file_exists(__DIR__ . "/pages/index.html")){
		// The templete file exists. So we can load it in.
		$page = file_get_contents(__DIR__ . "/pages/index.html");
	} else {
		// The templete files does not exists. We cannot continue. So just die.
		die("Sorry but we cannot display you account page at the moment. Please try again later.");
	}
	
	// Check if the user wants to change his username.
	if(isset($_POST["newusername"])){
		// Since the function can deal with NULL we do not need to filter for that.
		// The function itself deals with safety of the data passed to it. So we do not need to deal with it.
		$result = updateUsername($_POST["username"], $_POST["password"]);
		$page = str_replace("[logindata]", "Logged in as: " . getUsername()["message"] . " <a href=\"../login/logout.php\">Logout</a>", $page);
		echo str_replace("<div class=\"usernamemessage\"></div>", "<div class=\"usernamemessage\">" . $result["message"] . "</div>", $page);
	} else {
		$page = str_replace("[logindata]", "Logged in as: " . getUsername()["message"] . " <a href=\"../login/logout.php\">Logout</a>", $page);
		// Check if the user wants to change his password.
		if(isset($_POST["newpassword"])){
			// Since the function can deal with NULL we do not need to filter for that.
			// The function itself deals with safety of the data passed to it. So we do not need to deal with it.
			$result = updatePassword($_POST["oldpassword"], $_POST["password"], $_POST["cpassword"]);
			echo str_replace("<div class=\"passwordmessage\"></div>", "<div class=\"passwordmessage\">" . $result["message"] . "</div>", $page);
		} else {
			echo $page;
		}
	}
?>