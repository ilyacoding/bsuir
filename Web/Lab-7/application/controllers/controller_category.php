<?php
/**
 * Created by PhpStorm.
 * User: Ilya
 * Date: 15.04.2017
 * Time: 22:56
 */
class controller_category extends Controller
{
    function __construct()
    {
        require_once 'application/views/category_view.php';
        $this->model = new Model_category();
        $this->view = new category_View();
    }

    function action_id($parameters)
    {
        $data = $this->model->get_data($parameters);
        $this->view->generate($data);
    }
}