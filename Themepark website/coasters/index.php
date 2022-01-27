<?php
	require(__DIR__ . "/../login/authenticate.php");
	require(__DIR__ . "/backend/proccessor.php");

	// Check if we need to display all the coasters or one coaster.
	$displaycoasters = (empty($_GET["coaster"]) ? true : false);
	
	// Grab the correct template.
	if($displaycoasters){
		// Check if the templete page file exists and get its contents if it does.
		if(file_exists(__DIR__ . "/pages/coasters.html")){
			// The templete file exists. So we can load it in.
			$page = file_get_contents(__DIR__ . "/pages/coasters.html");
		} else {
			// The templete files does not exists. We cannot continue. So just die.
			die("Sorry but we cannot display the coasters page at the moment. Please try again later.");
		}
	} else {
		// Check if the templete page file exists and get its contents if it does.
		if(file_exists(__DIR__ . "/pages/coaster.html")){
			// The templete file exists. So we can load it in.
			$page = file_get_contents(__DIR__ . "/pages/coaster.html");
		} else {
			// The templete files does not exists. We cannot continue. So just die.
			die("Sorry but we cannot display the coaster page at the moment. Please try again later.");
		}
	}
	
	// Check if the user is logged in and add the correct data to the header.
	if(authenticate()["success"] == "true"){
		$page = str_replace("[logindata]", "Logged in as: " . getUsername()["message"] . " <a href=\"/login/logout.php\">Logout</a> <a href=\"/account/\">Account</a>", $page);
	} else {
		$page = str_replace("[logindata]", "<p><a href=\"/login/\">Login</a> / <a href=\"/login/register.php\">Register</a></p>", $page);
	}
	
	$coastersresult = "<br>";
	// Check if we need to get all the coasters from the database or just one.
	$coasters = ($displaycoasters ? getAllCoasters() : getSpecificCoaster($_GET["coaster"]));
	
	// Fill the template with the coasters or just one coaster.
	// Depending on weather the user has given an pecific coaster or not.
	if(!empty($coasters)){
		foreach($coasters as $coaster){
			if($displaycoasters){
				$coastersresult .= "<p>Name: <a href=\"./?coaster=" . $coaster["id"] . "\">" . $coaster["name"] . "</a></p>";
			} else {
				$coastersresult .= "<p>Name: " . $coaster["name"] . "</p>";
			}
			$coastersresult .= "<p>Build date: " . $coaster["build_year"] . "</p>";
			$coastersresult .= "<p>Manufacturer: " . $coaster["manufacturer"] . "</p>";
			$coastersresult .= "<p>Type: " . $coaster["type"] . "</p>";
			$coastersresult .= "<p>Height: " . $coaster["height"] . "</p>";
			$coastersresult .= "<p>Speed: " . $coaster["speed"] . "</p>";
			$coastersresult .= "<p>G-Force: " . $coaster["gforce"] . "</p>";
			$coastersresult .= "<p>Park: <a href=\"../parks/?park=" . $coaster["park_id"] . "\">" . $coaster["park_name"] . "</a></p>";
			$coastersresult .= "<br>";
		}
		if(!$displaycoasters){
			$page = str_replace("[coastername]", $coasters[0]["name"], $page);
			$page = str_replace("[options]", (authenticate()["success"] == "true" ? "<a href=\"./editcoaster.php?coaster=" . htmlspecialchars($_GET["coaster"], ENT_QUOTES) . "\">Edit coaster</a>" : ""), $page);
		} else {
			// Display the add coaster text if there is an logged in user.
			$page = str_replace("[options]", (authenticate()["success"] == "true" ? "<a href=\"./addcoaster.php\">Add coaster</a>" : ""), $page);
		}
		echo str_replace("[coasterslist]", $coastersresult, $page);
	} else {
		if(!$displaycoasters){
			$page = str_replace("[coastername]", "n/a", $page);
			$coastersresult .= "<p>Name: n/a</p>";
			$coastersresult .= "<p>Build date: n/a</p>";
			$coastersresult .= "<p>Manufacturer: n/a</p>";
			$coastersresult .= "<p>Type: n/a</p>";
			$coastersresult .= "<p>Height: n/a</p>";
			$coastersresult .= "<p>Speed: n/a</p>";
			$coastersresult .= "<p>G-Force: n/a</p>";
			$coastersresult .= "<p>Park: n/a</p>";
			$coastersresult .= "<br>";
		} else {
			$coastersresult = "No coasters where found.";
		}
		// Display the add coaster text if there is an logged in user.
		$page = str_replace("[options]", (authenticate()["success"] == "true" ? "<a href=\"./addcoaster.php\">Add coaster</a>" : ""), $page);
		echo str_replace("[coasterslist]", $coastersresult, $page);
	}
?>