<?php
	require(__DIR__ . "/../login/authenticate.php");
	require(__DIR__ . "/backend/proccessor.php");

	// Check if we need to display all the parks or one park.
	$displayparks = (empty($_GET["park"]) ? true : false);
	
	// Grab the correct template.
	if($displayparks){
		// Check if the templete page file exists and get its contents if it does.
		if(file_exists(__DIR__ . "/pages/parks.html")){
			// The templete file exists. So we can load it in.
			$page = file_get_contents(__DIR__ . "/pages/parks.html");
		} else {
			// The templete files does not exists. We cannot continue. So just die.
			die("Sorry but we cannot display the parks page at the moment. Please try again later.");
		}
	} else {
		// Check if the templete page file exists and get its contents if it does.
		if(file_exists(__DIR__ . "/pages/park.html")){
			// The templete file exists. So we can load it in.
			$page = file_get_contents(__DIR__ . "/pages/park.html");
		} else {
			// The templete files does not exists. We cannot continue. So just die.
			die("Sorry but we cannot display the park page at the moment. Please try again later.");
		}
	}
	
	// Check if the user is logged in and add the correct data to the header.
	if(authenticate()["success"] == "true"){
		$page = str_replace("[logindata]", "Logged in as: " . getUsername()["message"] . " <a href=\"/login/logout.php\">Logout</a> <a href=\"/account/\">Account</a>", $page);
	} else {
		$page = str_replace("[logindata]", "<p><a href=\"/login/\">Login</a> / <a href=\"/login/register.php\">Register</a></p>", $page);
	}
	$parksresult = "<br>";
	
	// Check if we need to get all the parks from the database or just one.
	$parks = ($displayparks ? getAllParks() : getSpecificPark($_GET["park"]));
	// Check if there are parks returned.
	if(!empty($parks)){
		// Loop trough the data and add html code for it.
		foreach($parks as $park){
			if($displayparks){
				$parksresult .= "<p>Name: <a href=\"./?park=" . $park["id"] . "\">" . $park["name"] . "</a></p>";
			} else {
				$parksresult .= "<p>Name: " . $park["name"] . "</p>";
			}
			$parksresult .= "<p>Open Since: " . $park["open_since"] . "</p>";
			$parksresult .= "<p>Owner: " . $park["owner"] . "</p>";
			$parksresult .= "<p>Country: " . $park["country"] . "</p>";
			$parksresult .= "<p>Address: " . $park["address"] . "</p>";
			$parksresult .= "<br>";
		}
		// Check if its only one parks that is getting displayed.
		if(!$displayparks){
			// Add the park name to the top of the page.
			$page = str_replace("[parkname]", $parks[0]["name"], $page);
			// Show the edit park text if the user is logged in.
			$page = str_replace("[options]", (authenticate()["success"] == "true" ? "<a href=\"./editpark.php?park=" . htmlspecialchars($_GET["park"], ENT_QUOTES) . "\">Edit park</a>" : ""), $page);
		}
		// Add the park(s) to the page.
		$page = str_replace("[parkslist]", $parksresult, $page);
		// Show the edit park text if the user is logged in.
		echo str_replace("[options]", (authenticate()["success"] == "true" ? "<a href=\"./addpark.php\">Add park</a>" : ""), $page);
	} else {
		// Check if its only one parks that is getting displayed.
		if(!$displayparks){
			// If its only one park then display the park not found data.
			$page = str_replace("[parkname]", "n/a", $page);
			$parksresult .= "<p>Name: n/a</p>";
			$parksresult .= "<p>Open Since: n/a</p>";
			$parksresult .= "<p>Owner: n/a</p>";
			$parksresult .= "<p>Country: n/a</p>";
			$parksresult .= "<p>Address: n/a</p>";
			$parksresult .= "<br>";
		} else {
			// If its all the parks then display an no parks found message.
			$parksresult = "No parks where found.";
		}
		$page = str_replace("[parkslist]", $parksresult, $page);
		// Show the add park text if the user is logged in.
		echo str_replace("[options]", (authenticate()["success"] == "true" ? "<a href=\"./addpark.php\">Add park</a>" : ""), $page);
	}
?>