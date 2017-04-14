<?php
/**
 * Created by PhpStorm.
 * User: Ilya
 * Date: 15.04.2017
 * Time: 0:51
 */
class item_view extends View
{
    function generate($data = null)
    {
        $row = $data[0];
        $site_title = $data[1];
        $tpl = new Template();
        $tpl->get_tpl('fullstory.tpl');
        $tpl->tpl_parse();
        $content = $tpl->template;

        $tpl = new Template();
        $tpl->get_tpl('main.tpl');
        $tpl->set_var('SITE-TITLE', $site_title . " | " . $row['title']);
        $tpl->set_var('CONTENT', $content);
//        $tpl->set_var('CALENDAR', get_calendar($session_month, $session_year));
//        $tpl->set_array(get_banners());
        $tpl->set_array($row);
        $tpl->set_array($this->parse_fields($row['fields']));
        $tpl->tpl_parse();

        echo $tpl->template;
    }

    function parse_fields($fields)
    {
        $fields = explode("||", $fields);
        $values = array();
        foreach ($fields as $f)
        {
            $row = explode("|", $f);
            $values["X_" . $row[0]] = $row[1];
        }
        return $values;
    }
}