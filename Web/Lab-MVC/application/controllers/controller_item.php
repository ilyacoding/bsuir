<?php
/**
 * Created by PhpStorm.
 * User: Ilya
 * Date: 15.04.2017
 * Time: 0:50
 */
class controller_item extends Controller
{
    function __construct()
    {
        require_once 'application/views/item_view.php';
        $this->model = new Model_item();
        $this->view = new item_view();
    }

    function action_id($parameters)
    {
        $data = $this->model->get_data($parameters);
        $this->view->generate($data);
    }
}