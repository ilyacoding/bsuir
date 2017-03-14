<?php
include_once("config.php");
include_once("Template.php");

Template::$tpl_path = $tpl_path_config;

function parse_fiels($fields)
{
    $fields = explode("||", $fields);
    $values = array();
    foreach ($fields as $f)
    {
        $row = explode("|", $f);
        $values['x_' . $row[0]] = $row[1];
    }
    return $values;
}

function throw_error($message)
{
    global $site_title;

    $err = new Template();
    $err->get_tpl('error.tpl');
    $err->set_var('SITE-TITLE', $site_title . " | " . $message);
    $err->tpl_parse();
    $err = $err->template;

    $header = new Template();
    $header->get_tpl('header.tpl');
    $header->set_var('SITE-TITLE', $site_title . " | " . $message);
    $header->tpl_parse();
    $header = $header->template;

    $tpl = new Template();
    $tpl->get_tpl('main.tpl');
    $tpl->set_var('CONTENT', $err);
    $tpl->set_var('ERR_MESSAGE', $message);
    $tpl->set_var('HEADER', $header);
    $tpl->tpl_parse();
    echo $tpl->template;
    die();
}

function get_page($p_id)
{
    global $db_host, $db_name, $db_user, $db_pass, $table_items, $table_cats, $site_title;

    $p_id = abs(intval($p_id));
    $conn = mysqli_connect($db_host, $db_user, $db_pass, $db_name);
    $result = mysqli_query($conn, "SELECT * FROM $table_items i JOIN $table_cats c ON c.cat_id = i.cat_id WHERE i.id = $p_id LIMIT 1");

    if (!($result->num_rows == 1))
    {
        throw_error("Нет такой новости.");
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
    $tpl->set_array(parse_fiels($row['fields']));
    $tpl->tpl_parse();

    mysqli_close($conn);

    return $tpl->template;
}

function get_cat($cat_id)
{
    global $db_host, $db_name, $db_user, $db_pass, $table_items, $table_cats, $site_title;

    $cat_id = abs(intval($cat_id));
    $conn = mysqli_connect($db_host, $db_user, $db_pass, $db_name);
    $cat_row = mysqli_query($conn, "SELECT cat_name FROM $table_cats WHERE cat_id = $cat_id");

    if (!($cat_row->num_rows > 0))
    {
        throw_error("Нет такой категории.");
    }
    else
    {
        $cat_row = mysqli_fetch_array($cat_row);
        $cat_name = $cat_row['cat_name'];
    }

    $q = "SELECT i.id, i.title, i.date, i.cat_id, i.img, i.short_desc, i.fields, c.cat_name FROM $table_items i JOIN $table_cats c ON i.cat_id = c.cat_id";
    if ($cat_id > 0)
    {
        $q = $q . " WHERE i.cat_id = $cat_id";
    }

    $result = mysqli_query($conn, $q);

    if (!($result->num_rows > 0))
    {
        throw_error("Нет новостей в данной категории.");
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
        $tpl->set_array(parse_fiels($row['fields']));
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