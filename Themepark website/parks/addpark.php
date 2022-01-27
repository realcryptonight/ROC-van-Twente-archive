<?php
	require(__DIR__ . "/../login/authenticate.php");
	require(__DIR__ . "/backend/proccessor.php");
	
	// Check if the user is logged in.
	// If not then redirect to the login page.
	if(authenticate()["success"] != "true"){
		header('Location: /login/');
	}
	
	// Check if the templete page file exists and get its contents if it does.
	if(file_exists(__DIR__ . "/pages/addpark.html")){
		// The templete file exists. So we can load it in.
		$page = file_get_contents(__DIR__ . "/pages/addpark.html");
	} else {
		// The templete files does not exists. We cannot continue. So just die.
		die("Sorry but we cannot display the add park page at the moment. Please try again later.");
	}
	// Display some user info since we know that there is an logged in user.
	$page = str_replace("[logindata]", "Logged in as: " . getUsername()["message"] . " <a href=\"/login/logout.php\">Logout</a> <a href=\"/account/\">Account</a>", $page);
	
	// Couple of handlers for getting all the required data from the database.
	// This will ensure that the data will be link correct when inserted.
	$countries = getAllCountries();
		
	$countryoptions = "";
	foreach($countries as $country){
		$countryoptions .= "<option value=\"". $country["id"] . "\">" . $country["id"] . " " . $country["name"] . "</option>";
	}
	$page = str_replace("[countryoptions]", $countryoptions,$page);
	
	// If the add button is clicked then try to add the data to the database.
	// Or this goes well or it will fail but that does not need extra handling.
	if(isset($_POST["Add"])){
		$result = createPark($_POST["parkname"], $_POST["opensince"], $_POST["parkowner"], $_POST["country"], $_POST["parkaddress"]);
		$page = str_replace("<div class=\"message\"></div>", "<div class=\"message\">" . $result["message"] . "</div>", $page);
	}
	echo $page;
?>