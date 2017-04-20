<?php
/**
 * Created by PhpStorm.
 * User: Ilya
 * Date: 20.04.2017
 * Time: 13:04
 */
class Model_feedback_send extends Model
{
    function send_data($parameters)
    {
        require 'application/libs/config.php';
        require 'application/libs/functions.php';

        if (!empty($_REQUEST['name']) && !empty($_REQUEST['recid']) && !empty($_REQUEST['subject']) && !empty($_REQUEST['message']))
        {
            $conn = mysqli_connect($db_host, $db_user, $db_pass, $db_name);
            $q = "SELECT `email` FROM $table_users WHERE `id` = " . $_REQUEST['recid'];

            $result = mysqli_query($conn, $q);

            if (!($result->num_rows > 0))
            {
                throw_error("Не кому писать письма.", $site_title);
            }

            $row = mysqli_fetch_array($result);
            $to = $row['email'];

            $subject = $_REQUEST['subject'];
            $message = $_REQUEST['message'];
            $headers = 'Content-Type: text/html; charset=utf-8'."\r\n" .
                'From: mil-time-ovh@yandex.ru' . "\r\n" .
                'Reply-To: mil-time-ovh@yandex.ru' . "\r\n" .
                'X-Mailer: PHP/' . phpversion();

            mail($to, $subject, $message, $headers);
        }
        else
        {
            throw_error("Неверные параметры.", $site_title);
        }

        $data = array();
        $data[0] = "";
        $data[1] = $site_title;
        $data[2] = get_banners();
        $data[3] = get_calendar();
        $data[4] = get_login();
        return $data;
    }
}