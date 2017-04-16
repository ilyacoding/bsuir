<?php
/**
 * Created by PhpStorm.
 * User: Ilya
 * Date: 15.04.2017
 * Time: 22:59
 */
class category_View extends View
{
    function generate($data = null)
    {
        $mysql_row = $data[0];
        $site_title = $data[1];
        $banners = $data[2];
        $calendar = $data[3];
        $login = $data[4];
        //
        $content = "";
        foreach ($mysql_row as $row) {
            if (!isset($cat_name))
            {
                $cat_name = $row['cat_name'];
            }
            $tpl = new Template();
            $tpl->get_tpl('shortstory.tpl');
            $tpl->set_array($row);
            $tpl->set_array(parse_fields($row['fields']));
            $tpl->tpl_parse();
            $content = $content . $tpl->template;
        }

        $tpl = new Template();
        $tpl->get_tpl('main.tpl');
        $tpl->set_var('SITE-TITLE', $site_title . " | " . $cat_name);
        $tpl->set_var('CONTENT', $content);
        $tpl->set_var('CALENDAR', $calendar);
        $tpl->set_var('LOGIN', $login);
        $tpl->set_array($banners);
        $tpl->tpl_parse();

        echo $tpl->template;
    }
}