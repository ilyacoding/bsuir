<?php
/**
 * Created by PhpStorm.
 * User: Ilya
 * Date: 15.04.2017
 * Time: 0:49
 */
class controller_404 extends Controller
{
    function __construct()
    {
        $this->model = new Model_item();
        $this->view = new item_View();
    }

    function action_index($parameters)
    {
        $this->view->generate();
    }
}