<?php
/**
 * Created by PhpStorm.
 * User: Ilya
 * Date: 15.04.2017
 * Time: 0:58
 */
class controller_main extends Controller
{
    function action_index($parameters)
    {
        var_dump($parameters);
        $this->view->generate();
    }
}