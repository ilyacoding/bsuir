<?php
/**
 * Created by PhpStorm.
 * User: Ilya
 * Date: 16.04.2017
 * Time: 13:32
 */
class register_View extends View
{
    function generate($data = null)
    {
        $site_title = $data[1];
        $banners = $data[2];
        $calendar = $data[3];
        $login = $data[4];
        $tpl = new Template();
        $tpl->get_tpl('register.tpl');
        $tpl->tpl_parse();
        $content = $tpl->template;

        $tpl = new Template();
        $tpl->get_tpl('main.tpl');
        $tpl->set_var('SITE-TITLE', $site_title . " | " . "Регистрация");
        $tpl->set_var('CONTENT', $content);
        $tpl->set_var('CALENDAR', $calendar);
        $tpl->set_var('LOGIN', $login);
        $tpl->set_array($banners);
        $tpl->tpl_parse();

        echo $tpl->template;
    }
}