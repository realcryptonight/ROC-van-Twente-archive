<?php
	require(__DIR__ . "/authenticate.php");
	// If the user filled in the form then try to create that user.
	if(isset($_POST["username"]) && isset($_POST["password"]) && isset($_POST["cpassword"])){
		// Check if the templete page file exists and get its contents if it does.
		if(file_exists(__DIR__ . "/pages/register.html")){
			$result = createUser($_POST["username"], $_POST["password"], $_POST["cpassword"]);
			// The templete file exists. So we can load it in and display.
			$page = file_get_contents(__DIR__ . "/pages/register.html");
			echo str_replace("<div class=\"errormessage\"></div>", "<div class=\"errormessage\">" . $result["message"] . "</div>", $page);
		} else {
			// The templete files does not exists. We cannot continue. So just die.
			die("Sorry but we cannot display the register page at the moment. Please try again later.");
		}
	} else {
		// Check if the templete page file exists and get its contents if it does.
		if(file_exists(__DIR__ . "/pages/register.html")){
			// The templete file exists. So we can load it in and display.
			echo file_get_contents(__DIR__ . "/pages/register.html");
		} else {
			// The templete files does not exists. We cannot continue. So just die.
			die("Sorry but we cannot display the register page at the moment. Please try again later.");
		}
	}
?>