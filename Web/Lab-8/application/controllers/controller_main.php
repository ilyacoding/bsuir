<?php
/**
 * Created by PhpStorm.
 * User: Ilya
 * Date: 15.04.2017
 * Time: 0:58
 */
class controller_main extends Controller
{
    function __construct()
    {
        require_once 'application/views/main_view.php';
        $this->view = new main_View();
    }

    function action_index($parameters)
    {
        $this->view->generate();
    }
}