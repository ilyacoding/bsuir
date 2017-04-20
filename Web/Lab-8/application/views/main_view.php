<?php

class main_View extends View
{
    function generate($data = null)
    {
        $host = 'http://'.$_SERVER['HTTP_HOST'].'/';
        header('HTTP/1.1 301 Redirect');
        header('Location:'.$host.'category/id/0');
    }
}
