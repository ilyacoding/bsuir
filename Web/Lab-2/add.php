<form action="" method="post">
    <?php
    include("./config.php");
    include("./include/Template.php");

    $conn = mysqli_connect($db_host, $db_user, $db_pass, $db_name);

    if (isset($_REQUEST['id']))
    {
        $q = "INSERT INTO `mil_news`(`cat`, `title`, `date`, `img`, `short_desc`, `full_desc`, `tank_mass`, `tank_crew`, `length`, `width`, `gun`, `gun_type`, `gun_speed`, `gun_load`, `gun_ammunation`, `gun_ammunation_type`, `gun_penetration`, `gun_stabilizer`, `gun_coupled`, `gun_antiaircraft`, `gun_controlled`, `firecontrol_rangefinder`, `firecontrol_measurement`, `protection_type`, `protection_smoke`, `protection_optoelectronics`, `engine`, `engine_type`, `engine_cooling`, `engine_power`, `engine_temperature_range`, `mobility_transmission`, `mobility_suspension`, `mobility_absorbers`) VALUES (";
        $first = true;
        unset($_POST['id']);
        foreach ($_POST as $key => $value)
        {
            if ($first)
            {
                $q = $q . "'" . $value . "'";
                $first = false;
                continue;
            }
            $q = $q . ", '" . $value . "'";
        }
        $q = $q . ")";
        echo $q;
        $result = mysqli_query($conn, $q);
    }


    $result = mysqli_query($conn, "SELECT * FROM $table_news LIMIT 1");


    while($row = mysqli_fetch_array($result))
    {
        foreach ($row as $key => $value) {
            if (!is_numeric($key))
                echo "<p>$key: <input name=\"$key\" width='500' required></p>";
        }
    }
    ?>
    <p><input type="submit" value="Отправить"></p>
</form>