<?php
/**
 * Created by PhpStorm.
 * User: Ilya
 * Date: 16.04.2017
 * Time: 17:34
 */
class Model_history extends Model
{
    function get_data($parameters)
    {
        require 'application/libs/config.php';
        require 'application/libs/functions.php';

        $conn = mysqli_connect($db_host, $db_user, $db_pass, $db_name);
        $q = "SELECT * FROM $table_history i WHERE `session_id` = '".session_id()."'";

        $result = mysqli_query($conn, $q);

        if (!($result->num_rows > 0))
        {
            throw_error("Нет истории посещения сайта.", $site_title);
        }

        $mysql_row = array();
        while ($row = mysqli_fetch_array($result)) {
            $mysql_row[] = $row;
        }

        mysqli_close($conn);

        $data = array();
        $data[0] = $mysql_row;
        $data[1] = $site_title;
        $data[2] = get_banners();
        $data[3] = get_calendar($_SESSION['month'], $_SESSION['year']);
        $data[4] = get_login();
        return $data;
    }
}