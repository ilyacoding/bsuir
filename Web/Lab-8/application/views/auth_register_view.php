<?php
/**
 * Created by PhpStorm.
 * User: Ilya
 * Date: 16.04.2017
 * Time: 14:26
 */
class auth_register_View extends View
{
    function generate($data = null)
    {
        $host = 'http://'.$_SERVER['HTTP_HOST'].'/';
        header('HTTP/1.1 301 Redirect');
        header('Location:'.$host);
    }
}