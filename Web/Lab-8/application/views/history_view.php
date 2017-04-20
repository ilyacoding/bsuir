<?php
/**
 * Created by PhpStorm.
 * User: Ilya
 * Date: 16.04.2017
 * Time: 17:34
 */
class history_View extends View
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

            $tpl = new Template();
            $tpl->get_tpl('history.tpl');
            $tpl->set_var('DATE', $row['time']);
            $tpl->set_var('PATH', $row['page_url']);
            $tpl->tpl_parse();
            $content = $content . $tpl->template;
        }

        $tpl = new Template();
        $tpl->get_tpl('main.tpl');
        $tpl->set_var('SITE-TITLE', $site_title . " | " . "История");
        $tpl->set_var('CONTENT', $content);
        $tpl->set_var('CALENDAR', $calendar);
        $tpl->set_var('LOGIN', $login);
        $tpl->set_array($banners);
        $tpl->tpl_parse();

        echo $tpl->template;
    }
}