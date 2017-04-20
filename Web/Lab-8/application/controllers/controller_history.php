<?php
/**
 * Created by PhpStorm.
 * User: Ilya
 * Date: 16.04.2017
 * Time: 17:34
 */
class controller_history extends Controller
{
    function __construct()
    {
        require_once 'application/views/history_view.php';
        $this->model = new Model_history();
        $this->view = new history_View();
    }

    function action_index($parameters)
    {
        $data = $this->model->get_data($parameters);
        $this->view->generate($data);
    }
}