<?php
/**
 * Created by PhpStorm.
 * User: Ilya
 * Date: 16.04.2017
 * Time: 1:36
 */

class controller_auth extends Controller
{
    function action_login($parameters)
    {
        require_once 'application/views/auth_login_view.php';
        require_once 'application/models/model_auth_login.php';
        $this->model = new Model_auth_login();
        $this->view = new auth_login_View();

        $data = $this->model->get_data($parameters);
        $this->view->generate($data);
    }

    function action_register($parameters)
    {
        require_once 'application/views/auth_register_view.php';
        require_once 'application/models/model_auth_register.php';
        $this->model = new Model_auth_register();
        $this->view = new auth_register_View();

        $data = $this->model->get_data($parameters);
        $this->view->generate($data);
    }

    function action_logout($parameters)
    {
        require_once 'application/views/auth_logout_view.php';

        $this->view = new auth_logout_View();

        $this->view->generate();
    }
}