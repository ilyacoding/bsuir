<?php
include_once("config.php");
include_once("Template.php");

Template::$tpl_path = $tpl_path_config;

function ThrowError($message)
{
    global $site_title;
    $header = new Template();
    $header->get_tpl('header.tpl');
    $header->set_var('SITE-TITLE', $site_title . " | " . $message);
    $header->tpl_parse();
    $header = $header->template;

    $tpl = new Template();
    $tpl->get_tpl('main.tpl');
    $tpl->set_var('CONTENT', $message);
    $tpl->set_var('HEADER', $header);
    $tpl->tpl_parse();
    echo $tpl->template;
    die();
}

function GetPage($p_id)
{
    global $db_host, $db_name, $db_user, $db_pass, $table_news, $table_categories, $site_title;

    $p_id = abs(intval($p_id));
    $conn = mysqli_connect($db_host, $db_user, $db_pass, $db_name);
    $result = mysqli_query($conn, "SELECT * FROM $table_news n JOIN $table_categories c ON c.id = n.cat WHERE n.id = $p_id LIMIT 1");

    if (!($result->num_rows == 1))
    {
        ThrowError("Нет такой новости.");
    }

    $row = mysqli_fetch_array($result);

    $tpl = new Template();
    $tpl->get_tpl('fullstory.tpl');
    $tpl->tpl_parse();
    $content = $tpl->template;

    $tpl = new Template();
    $tpl->get_tpl('header.tpl');
    $tpl->tpl_parse();
    $header = $tpl->template;

    $tpl = new Template();
    $tpl->get_tpl('main.tpl');
    $tpl->set_var('CONTENT', $content);
    $tpl->set_var('HEADER', $header);
    $tpl->set_var('SITE-TITLE', $site_title . " | " . $row['title']);
    $tpl->set_array($row);
    $tpl->tpl_parse();

    mysqli_close($conn);

    return $tpl->template;
}

function GetCat($cat_id)
{
    global $db_host, $db_name, $db_user, $db_pass, $table_news, $table_categories, $site_title;

    $cat_id = abs(intval($cat_id));
    $conn = mysqli_connect($db_host, $db_user, $db_pass, $db_name);
    $cat_row = mysqli_query($conn, "SELECT cat_name FROM $table_categories WHERE id = $cat_id");

    if (!($cat_row->num_rows > 0))
    {
        ThrowError("Нет такой категории.");
    }
    else
    {
        $cat_row = mysqli_fetch_array($cat_row);
        $cat_name = $cat_row['cat_name'];
    }

    $q = "SELECT n.id, n.cat, n.img, n.title, n.date, n.short_desc, c.cat_name FROM $table_news n JOIN $table_categories c ON n.cat = c.id";
    if ($cat_id > 0)
    {
        $q = $q . " WHERE n.cat = $cat_id";
    }

    $result = mysqli_query($conn, $q);

    if (!($result->num_rows > 0))
    {
        ThrowError("Нет новостей в данной категории.");
    }

    $content = "";
    $header = "";
    while ($row = mysqli_fetch_array($result)) {
        if (!isset($cat_name))
        {
            $cat_name = $row['cat_name'];
        }
        $tpl = new Template();
        $tpl->get_tpl('shortstory.tpl');
        $tpl->set_array($row);
        $tpl->tpl_parse();
        $content = $content . $tpl->template;
    }

    $tpl = new Template();
    $tpl->get_tpl('header.tpl');
    $tpl->set_var('SITE-TITLE', $site_title . " | " . $cat_name);
    $tpl->tpl_parse();
    $header = $tpl->template;

    $tpl = new Template();
    $tpl->get_tpl('main.tpl');
    $tpl->set_var('CONTENT', $content);
    $tpl->set_var('HEADER', $header);
    $tpl->tpl_parse();
    echo $tpl->template;
    die();

    mysqli_close($conn);

    return $tpl->template;
}