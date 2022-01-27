<?php
	require(__DIR__ . "/../login/authenticate.php");
	require(__DIR__ . "/backend/proccessor.php");
	
	// Check if the user is logged in.
	// If not then redirect to the login page.
	if(authenticate()["success"] != "true"){
		header('Location: /login/');
	}
	
	// Check if an coaster get parameter is given.
	// If not then redirect to the index.php
	if(empty($_GET["coaster"])){
		header('Location: ./index.php');
	}
	
	// Check if the templete page file exists and get its contents if it does.
	if(file_exists(__DIR__ . "/pages/changecoaster.html")){
		// The templete file exists. So we can load it in.
		$page = file_get_contents(__DIR__ . "/pages/changecoaster.html");
	} else {
		// The templete files does not exists. We cannot continue. So just die.
		die("Sorry but we cannot display the edit coaster page at the moment. Please try again later.");
	}
	// Display some user info since we know that there is an logged in user.
	$page = str_replace("[logindata]", "Logged in as: " . getUsername()["message"] . " <a href=\"/login/logout.php\">Logout</a> <a href=\"/account/\">Account</a>", $page);
	
	// If the update button is clicked then try to update the data in the database.
	// Or this goes well or it will fail but that does not need extra handling.
	if(isset($_POST["Update"])){
		$result = updateCoaster($_POST["coasterid"], $_POST["coastername"], $_POST["coasterpark"], $_POST["buildyear"], $_POST["manufacturer"], $_POST["coastertype"], $_POST["coasterheight"], $_POST["coasterspeed"], $_POST["coastergforce"]);
		$page = str_replace("<div class=\"message\"></div>", "<div class=\"message\">" . $result["message"] . "</div>", $page);
	}
	
	// Now get the coaster information that is given.
	$coasterid = htmlspecialchars($_GET["coaster"], ENT_QUOTES);
	$coasterdetails = getSpecificCoaster($coasterid);
	// If it fails then redirect to the index.php
	if(empty($coasterdetails)){
		header('Location: ./index.php');
	}
	
	// Prefill the form with the current values from the database.
	$page = str_replace("<input type=\"hidden\" id=\"coasterid\" name=\"coasterid\">", "<input type=\"hidden\" id=\"coasterid\" name=\"coasterid\" value=\"" . $coasterid . "\">", $page);
	$page = str_replace("<input type=\"text\" id=\"coastername\" name=\"coastername\">", "<input type=\"text\" id=\"coastername\" name=\"coastername\" value=\"" . $coasterdetails[0]["name"] . "\">", $page);
	$page = str_replace("<input type=\"date\" id=\"buildyear\" name=\"buildyear\">", "<input type=\"date\" id=\"buildyear\" name=\"buildyear\" value=\"" . $coasterdetails[0]["build_year"] . "\">", $page);
	$page = str_replace("<input type=\"number\" step=\"0.01\" id=\"coasterheight\" name=\"coasterheight\">", "<input type=\"number\" step=\"0.01\" id=\"coasterheight\" name=\"coasterheight\" value=\"" . $coasterdetails[0]["height"] . "\">", $page);
	$page = str_replace("<input type=\"number\" step=\"0.01\" id=\"coasterspeed\" name=\"coasterspeed\">", "<input type=\"number\" step=\"0.01\" id=\"coasterspeed\" name=\"coasterspeed\" value=\"" . $coasterdetails[0]["speed"] . "\">", $page);
	$page = str_replace("<input type=\"number\" step=\"0.01\" id=\"coastergforce\" name=\"coastergforce\">", "<input type=\"number\" step=\"0.01\" id=\"coastergforce\" name=\"coastergforce\" value=\"" . $coasterdetails[0]["gforce"] . "\">", $page);
	
	// Couple of handlers for getting all the required data from the database.
	// This will ensure that the data will be link correct when inserted.
	$parks = getAllParksForCoasters();
		
	$parkoptions = "";
	foreach($parks as $park){
		if($park["name"] == $coasterdetails[0]["park_name"]){
			$parkoptions .= "<option value=\"". $park["id"] . "\" selected>" . $park["id"] . " " . $park["name"] . "</option>";
		} else {
			$parkoptions .= "<option value=\"". $park["id"] . "\">" . $park["id"] . " " . $park["name"] . "</option>";
		}
	}
	$page = str_replace("[parkoptions]", $parkoptions,$page);
	
	$manufacturers = getAllManufacturers();
		
	$manufactureroptions = "";
	foreach($manufacturers as $manufacturer){
		if($manufacturer["name"] == $coasterdetails[0]["manufacturer"]){
			$manufactureroptions .= "<option value=\"". $manufacturer["id"] . "\" selected>" . $manufacturer["id"] . " " . $manufacturer["name"] . "</option>";
		} else {
			$manufactureroptions .= "<option value=\"". $manufacturer["id"] . "\">" . $manufacturer["id"] . " " . $manufacturer["name"] . "</option>";
		}
	}
	$page = str_replace("[manufactureroptions]", $manufactureroptions,$page);
	
	$coastertypes = getAllCoasterTypes();
		
	$coastertypeoptions = "";
	foreach($coastertypes as $coastertype){
		if($coastertype["type"] == $coasterdetails[0]["type"]){
			$coastertypeoptions .= "<option value=\"". $coastertype["id"] . "\" selected>" . $coastertype["id"] . " " . $coastertype["type"] . "</option>";
		} else {
			$coastertypeoptions .= "<option value=\"". $coastertype["id"] . "\">" . $coastertype["id"] . " " . $coastertype["type"] . "</option>";
		}
	}
	$page = str_replace("[coastertypeoptions]", $coastertypeoptions,$page);
	echo $page;
?>