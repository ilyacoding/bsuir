<?php
/**
 * Created by PhpStorm.
 * User: Ilya
 * Date: 15.04.2017
 * Time: 23:47
 */
class controller_calendar extends Controller
{
    function __construct()
    {
        require_once 'application/views/calendar_view.php';
        $this->view = new calendar_View();
    }

    function action_set($parameters)
    {
        $this->view->generate($parameters);
    }
}