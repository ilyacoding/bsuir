<?php
/**
 * Created by PhpStorm.
 * User: Ilya
 * Date: 16.04.2017
 * Time: 0:30
 */
class controller_sitemap extends Controller
{
    function __construct()
    {
        require_once 'application/views/sitemap_view.php';
        $this->view = new sitemap_View();
    }

    function action_xml($parameters)
    {
        $this->view->generate();
    }
}