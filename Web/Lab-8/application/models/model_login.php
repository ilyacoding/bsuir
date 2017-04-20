<?php
/**
 * Created by PhpStorm.
 * User: Ilya
 * Date: 16.04.2017
 * Time: 13:55
 */
class Model_login extends Model
{
    function get_data($parameters)
    {
        require 'application/libs/config.php';
        require 'application/libs/functions.php';
        add_page();

        if (empty($_SESSION['logged']))
        {
            $_SESSION['logged'] = false;
        }

        $data = array();
        $data[0] = '';
        $data[1] = $site_title;
        $data[2] = get_banners();
        $data[3] = get_calendar();
        $data[4] = get_login();
        return $data;
    }
}