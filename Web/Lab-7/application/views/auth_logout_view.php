<?php
/**
 * Created by PhpStorm.
 * User: Ilya
 * Date: 16.04.2017
 * Time: 17:01
 */

class auth_logout_View extends View
{
    function generate($data = null)
    {
        $_SESSION['logged'] = false;
        $host = 'http://'.$_SERVER['HTTP_HOST'].'/';
        header('HTTP/1.1 301 Redirect');
        header('Location:'.$host);
    }
}