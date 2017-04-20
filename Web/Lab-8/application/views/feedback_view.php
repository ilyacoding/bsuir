<?php
/**
 * Created by PhpStorm.
 * User: Ilya
 * Date: 20.04.2017
 * Time: 13:04
 */
class feedback_View extends View
{
    function generate($data = null)
    {
        $mysql_row = $data[0];
        $site_title = $data[1];
        $banners = $data[2];
        $calendar = $data[3];
        $login = $data[4];
        //
        $feedback_content = "";
        foreach ($mysql_row as $row) {

            $tpl = new Template();
            $tpl->get_tpl('feedback-element.tpl');
            $tpl->set_var('ID', $row['id']);
            $tpl->set_var('USERNAME', $row['login']);
            $tpl->tpl_parse();
            $feedback_content = $feedback_content . $tpl->template;
        }

        $tpl = new Template();
        $tpl->get_tpl('feedback.tpl');
        $tpl->set_var('FEEDBACK-USERS', $feedback_content);
        $tpl->tpl_parse();
        $content = $tpl->template;

        $tpl = new Template();
        $tpl->get_tpl('main.tpl');
        $tpl->set_var('SITE-TITLE', $site_title . " | " . "Обратная связь");
        $tpl->set_var('CONTENT', $content);
        $tpl->set_var('CALENDAR', $calendar);
        $tpl->set_var('LOGIN', $login);
        $tpl->set_array($banners);
        $tpl->tpl_parse();

        echo $tpl->template;
    }
}