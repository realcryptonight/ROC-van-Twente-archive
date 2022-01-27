<?php
	require(__DIR__ . "/authenticate.php");
	
	// If the user filled in the form or if its already logged in then try to authenticate.
	if(isset($_POST["username"]) && isset($_POST["password"]) || isset($_SESSION["session_id"])){
		$result = authenticate($_POST["username"], $_POST["password"]);
		// Check if the user successfully authenticated.
		if($result["success"] == "true"){
			// Redirect to the home page.
			header('Location: ../');
		} else {
			// Display the error message.
			// Check if the templete page file exists and get its contents if it does.
			if(file_exists(__DIR__ . "/pages/login.html")){
				// The templete file exists. So we can load it in.
				$page = file_get_contents(__DIR__ . "/pages/login.html");
				echo str_replace("<div class=\"errormessage\"></div>", "<div class=\"errormessage\">" . $result["message"] . "</div>", $page);
			} else {
				// The templete files does not exists. We cannot continue. So just die.
				die("Sorry but we cannot display the login page at the moment. Please try again later.");
			}
		}
	} else {
		// Check if the templete page file exists and get its contents if it does.
		if(file_exists(__DIR__ . "/pages/login.html")){
			// The templete file exists. So we can load it in and display.
			echo file_get_contents(__DIR__ . "/pages/login.html");
		} else {
			// The templete files does not exists. We cannot continue. So just die.
			die("Sorry but we cannot display the login page at the moment. Please try again later.");
		}
	}
?>