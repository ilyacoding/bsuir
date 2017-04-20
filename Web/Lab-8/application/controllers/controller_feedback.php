<?php
/**
 * Created by PhpStorm.
 * User: Ilya
 * Date: 20.04.2017
 * Time: 12:10
 */
class controller_feedback extends Controller
{
    function __construct()
    {
        require_once 'application/views/feedback_view.php';
        require_once 'application/models/model_feedback_index.php';
        require_once 'application/models/model_feedback_send.php';
    }

    function action_index($parameters)
    {
        $this->model = new Model_feedback_index();
        $this->view = new feedback_View();

        $data = $this->model->get_data($parameters);
        $this->view->generate($data);
    }

    function action_send($parameters)
    {
        $this->model = new Model_feedback_send();
        $this->view = new feedback_View();

        $this->model->send_data($parameters);

        $host = 'http://'.$_SERVER['HTTP_HOST'].'/';
        header('HTTP/1.1 301 Redirect');
        header('Location:'.$host);
    }
}