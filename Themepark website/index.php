<?php
	// Require the authenticate.php to use parts of it on the page.
	require(__DIR__ . "/login/authenticate.php");
?>

<html>
	<head>
		<title>Themepark database</title>
	</head>
	<body>
		<header>
          <?php
		    // Check in the user is logged in.
			if(authenticate()["success"] == "true"){
				// The user is logged in so display some information about the user.
				echo "Logged in as: " . getUsername()["message"] . " <a href=\"./login/logout.php\">Logout</a> <a href=\"./account/\">Account</a>";
			} else {
				// The user is not logged in so display some login/register options.
				echo "<p><a href=\"./login/\">Login</a> / <a href=\"./login/register.php\">Register</a></p>";
			}
		  ?>
		</header>
		<h1>Themepark database</h1>
		<p>Find all the information on parks and coaster.</p>
		<a href="./parks/">Find parks.</a>
		<br>
		<a href="./coasters/">Find coasters.<a>
	</body>
</html>