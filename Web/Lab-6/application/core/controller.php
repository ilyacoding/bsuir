<?php

/**
 * Created by PhpStorm.
 * User: Ilya
 * Date: 15.04.2017
 * Time: 0:10
 */
class Controller
{
    public $model;
    public $view;

    function __construct()
    {
        $this->view = new View();
    }

    function action_index($parameters)
    {
    }
}