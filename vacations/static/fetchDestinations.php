<?php
require 'constants.php';
if (isset($_POST["start"], $_POST["end"])) {
    $start_index = $_POST["start"];

    $end_index = $_POST["end"];

    // Create connection
    $conn = new mysqli(servername, username, password, dbname);
    // Check connection
    if ($conn->connect_error) {
        die("Connection failed: " . $conn->connect_error);
    }

    $sql_cmd = "SELECT * FROM `destination` ORDER BY destinationId  LIMIT " . $start_index . "," . $end_index;
    $result = $conn->query($sql_cmd);

    if ($result->num_rows == 0){

    }
    ?>
    <table class="table table-dark table-hover items-table mt-5 mx-1 items-table">
        <thead>
        <tr>
            <th>Id</th>
            <th>Location</th>
            <th>Country</th>
            <th>Description</th>
            <th>Daily   Cost</th>
        </tr>
        </thead>
        <tbody>
    <?php


    if ($result->num_rows > 0) {
        // output data of each row
        while ($row = $result->fetch_assoc()) {
            echo "<tr>";
            echo "<td>".$row["destinationId"] ."</td>";
            echo "<td>".$row["locationName"] ."</td>";
            echo "<td>".$row["countryName"] ."</td>";
            echo "<td>".$row["description"] ."</td>";
            echo "<td>".$row["costPerDay"] ."</td>";
            echo "</tr>";

        }
    } else {
        echo "0 results";
    }
    ?>

        </tbody>
    </table>
    <?php


    $conn->close();
}