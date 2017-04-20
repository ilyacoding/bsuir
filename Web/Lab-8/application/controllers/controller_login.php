<?php
/**
 * Created by PhpStorm.
 * User: Ilya
 * Date: 16.04.2017
 * Time: 13:32
 */
class controller_login extends Controller
{
    function __construct()
    {
        require_once 'application/views/login_view.php';
        $this->model = new Model_login();
        $this->view = new login_View();
    }

    function action_index($parameters)
    {
        $data = $this->model->get_data($parameters);
        $this->view->generate($data);
    }
}