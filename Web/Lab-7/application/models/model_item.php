<?php
/**
 * Created by PhpStorm.
 * User: Ilya
 * Date: 15.04.2017
 * Time: 1:05
 */

class Model_item extends Model
{
    function get_data($parameters)
    {
        require 'application/libs/config.php';
        require 'application/libs/functions.php';
        add_page();

        $p_id = abs(intval($parameters[0]));
        $conn = mysqli_connect($db_host, $db_user, $db_pass, $db_name);
        $result = mysqli_query($conn, "SELECT * FROM $table_items i JOIN $table_cats c ON c.cat_id = i.cat_id WHERE i.id = $p_id LIMIT 1");

        if (!($result->num_rows == 1))
        {
            throw_error("Нет такой новости.", $site_title);
        }

        $row = mysqli_fetch_array($result);

        mysqli_close($conn);

        $data = array();
        $data[0] = $row;
        $data[1] = $site_title;
        $data[2] = get_banners();
        $data[3] = get_calendar($_SESSION['month'], $_SESSION['year']);
        $data[4] = get_login();
        return $data;
    }
}