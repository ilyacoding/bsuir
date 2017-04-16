<?php
/**
 * Created by PhpStorm.
 * User: Ilya
 * Date: 15.04.2017
 * Time: 23:53
 */

class calendar_View extends View
{
    function generate($data = null)
    {
        if (!empty($data[0]) && !empty($data[1]))
        {
            $_SESSION['month'] = $data[0];
            $_SESSION['year'] = $data[1];
        }
        $host = 'http://'.$_SERVER['HTTP_HOST'].'/';
        header('HTTP/1.1 301 Redirect');
        header('Location:'.$host);
    }
}