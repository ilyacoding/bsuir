<?php
/**
 * Created by PhpStorm.
 * User: Ilya
 * Date: 16.04.2017
 * Time: 14:13
 */
class Model_register extends Model
{
    function get_data($parameters)
    {
        require 'application/libs/config.php';
        require 'application/libs/functions.php';
        add_page();

        $data = array();
        $data[0] = '';
        $data[1] = $site_title;
        $data[2] = get_banners();
        $data[3] = get_calendar($_SESSION['month'], $_SESSION['year']);
        $data[4] = get_login();
        return $data;
    }
}