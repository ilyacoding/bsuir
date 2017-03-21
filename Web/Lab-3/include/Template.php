<?php

class Template
{
    public $template;
    public static $tpl_path;
    private $vars = array();

    public function get_tpl($tpl_name)
    {
        $tpl_name = Template::$tpl_path . $tpl_name;
        if(empty($tpl_name) || !file_exists($tpl_name))
        {
            return false;
        }
        else
        {
            $this->template  = file_get_contents($tpl_name);
        }
    }
    public function set_var($key, $var)
    {
        $this->vars[$key] = $var;
    }

    public function set_array($array)
    {
        foreach($array as $key => $value)
        {
            $this->vars[$key] = $value;
        }
    }

    public function tpl_parse()
    {
        foreach($this->vars as $key => $value)
        {
            $this->template = str_replace("{" . strtoupper($key) . "}", $value, $this->template);
        }
    }
}