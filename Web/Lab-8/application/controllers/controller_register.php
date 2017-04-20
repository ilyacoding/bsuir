<?php
/**
 * Created by PhpStorm.
 * User: Ilya
 * Date: 16.04.2017
 * Time: 13:32
 */
class controller_register extends Controller
{
    function __construct()
    {
        require_once 'application/views/register_view.php';
        $this->model = new Model_register();
        $this->view = new register_View();
    }

    function action_index($parameters)
    {
        $data = $this->model->get_data($parameters);
        $this->view->generate($data);
    }
}