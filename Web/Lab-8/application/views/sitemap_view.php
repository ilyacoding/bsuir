<?php
/**
 * Created by PhpStorm.
 * User: Ilya
 * Date: 16.04.2017
 * Time: 0:30
 */
class sitemap_View extends View
{
    function generate($data = null)
    {
        require 'application/libs/functions.php';
        echo get_sitemap();
    }
}