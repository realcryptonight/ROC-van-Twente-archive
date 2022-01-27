<?php
	// Version 1
	// Created by Daniel Markink.

	$HOSTNAME = "localhost";
	$PORT = "3306";
	$USERNAME = "root";
	$PASSWORD = "";
	$DATABASE = "themepark";

	$conn = new mysqli($HOSTNAME, $USERNAME, $PASSWORD, $DATABASE, $PORT);

	if ($conn->connect_error) {
		die("Connection failed: " . $conn->connect_error);
	}
?>