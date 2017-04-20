<?php
/**
 * Created by PhpStorm.
 * User: Ilya
 * Date: 16.04.2017
 * Time: 14:25
 */
class Model_auth_register extends Model
{
    function get_data($parameters)
    {
        require 'application/libs/config.php';
        require 'application/libs/functions.php';
        add_page();

        $login = $_REQUEST['login'] ?? "";
        $password = $_REQUEST['password'] ?? "";
        $email = $_REQUEST['email'] ?? "";

        $conn = mysqli_connect($db_host, $db_user, $db_pass, $db_name);
        $result = mysqli_query($conn, "SELECT * FROM $table_users WHERE `login` = '$login'");

        if ($result->num_rows == 1)
        {
            throw_error("Такой пользователь уже существует.", $site_title);
        }

        $q = "INSERT INTO $table_users (`login`, `password`, `email`) VALUES ('".mysqli_real_escape_string($conn, $login)."', '".hash('sha512', $password)."', '".mysqli_real_escape_string($conn, $email)."')";
        mysqli_query($conn, $q);

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