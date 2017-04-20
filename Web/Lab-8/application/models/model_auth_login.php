<?php
/**
 * Created by PhpStorm.
 * User: Ilya
 * Date: 16.04.2017
 * Time: 14:26
 */

class Model_auth_login extends Model
{
    function get_data($parameters)
    {
        require 'application/libs/config.php';
        require 'application/libs/functions.php';
        add_page();
        $login = $_REQUEST['login'] ?? "";
        $password = $_REQUEST['password'] ?? "";

        $conn = mysqli_connect($db_host, $db_user, $db_pass, $db_name);
        $result = mysqli_query($conn, "SELECT * FROM $table_users WHERE `login` = '$login' AND `password` = '".hash('sha512', $password)."'");

        if ($result->num_rows != 1)
        {
            $_SESSION['logged'] = false;
            throw_error("Данные для авторизации неверные.", $site_title);
        }

        $row = mysqli_fetch_array($result);

        $_SESSION['logged'] = true;
        $_SESSION['id'] = $row['id'];
        $_SESSION['login'] = $row['login'];

        mysqli_close($conn);

        $data = array();
        $data[0] = '';
        $data[1] = $site_title;
        $data[2] = get_banners();
        $data[3] = get_calendar();
        $data[4] = get_login();
        return $data;
    }
}