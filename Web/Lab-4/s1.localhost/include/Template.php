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

    private static function load_file($matches)
    {
        return @file_get_contents(Template::$tpl_path . $matches[2]);
    }

    public function get_db_var($matches)
    {
        global $db_host, $db_name, $db_user, $db_pass, $table_db;

        $key = $matches[2];
        $conn = mysqli_connect($db_host, $db_user, $db_pass, $db_name);
        $result = mysqli_query($conn, "SELECT $key FROM `mil_db`");
        $row = mysqli_fetch_array($result);
        mysqli_close($conn);
        return $row[$key];
    }

    public function tpl_parse()
    {
        $this->template = preg_replace_callback("/({FILE=\")([A-Z_\.]*)(\"})/i", 'Template::load_file', $this->template);
        $this->template = preg_replace_callback("/({DB=\")([A-Z_\_]*)(\"})/i", array($this, 'get_db_var'), $this->template);

        foreach($this->vars as $key => $value)
        {
            $this->template = str_replace("{" . strtoupper($key) . "}", $value, $this->template);
        }
    }
}