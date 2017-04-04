<?php
include_once("config.php");
include_once("Template.php");

Template::$tpl_path = $tpl_path_config;

function validate_date($date) // Y-m-d
{
    $array = explode("-", $date);
    if (count($array) != 3) return false;
    return checkdate($array[1], $array[2], $array[0]);
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

function throw_error($message)
{
    global $site_title;

    $err = new Template();
    $err->get_tpl('error.tpl');
    $err->set_var('SITE-TITLE', $site_title . " | " . $message);
    $err->tpl_parse();
    $err = $err->template;

    $tpl = new Template();
    $tpl->get_tpl('main.tpl');
    $tpl->set_var('SITE-TITLE', $site_title . " | " . $message);
    $tpl->set_var('CONTENT', $err);
    $tpl->set_var('ERR_MESSAGE', $message);
    $tpl->tpl_parse();
    echo $tpl->template;
    die();
}

function get_sitemap()
{
    global $db_host, $db_name, $db_user, $db_pass, $table_items, $table_cats, $site_title;
    $sitemap = '<?xml version="1.0" encoding="UTF-8"?>';
    $sitemap .= '<urlset xmlns="http://www.sitemaps.org/schemas/sitemap/0.9">';
    $conn = mysqli_connect($db_host, $db_user, $db_pass, $db_name);

    $q = "SELECT i.id, i.date, c.cat_name FROM $table_items i JOIN $table_cats c ON i.cat_id = c.cat_id";
    $result = mysqli_query($conn, $q);

    while ($row = mysqli_fetch_array($result)) {
        $sitemap .= '
        <url>
            <loc>http://'.$_SERVER['SERVER_NAME'].'/item/'. $row['id'] .'</loc>
            <lastmod>'. date('c', strtotime($row['date'])) .'</lastmod>
        </url>';
    }

    $q = "SELECT cat_id FROM $table_cats";
    $result = mysqli_query($conn, $q);

    while ($row = mysqli_fetch_array($result)) {
        $sitemap .= '
        <url>
            <loc>http://'.$_SERVER['SERVER_NAME'].'/cat/'. $row['cat_id'] .'</loc>
        </url>';
    }

    $sitemap .= '</urlset>';
    return $sitemap;
}

function get_calendar($month, $year)
{
    global $db_host, $db_name, $db_user, $db_pass, $table_items;

    $conn = mysqli_connect($db_host, $db_user, $db_pass, $db_name);

    $month = str_pad($month, 2, '0', STR_PAD_LEFT);
    $year = str_pad($year, 4, '0', STR_PAD_LEFT);
    $calendar = '<table cellpadding="0" cellspacing="0" class="calendar">';

    $running_day = date('w', mktime(0, 0, 0, $month, 1, $year));
    $days_in_month = date('t', mktime(0, 0, 0, $month, 1, $year));
    $days_in_this_week = 1;
    $day_counter = 0;

    $calendar .= date("F Y", mktime(0, 0, 0, $month, 1, $year));;
    $calendar .= "<br><a href='/?module=calendar&type=minus'>Назад</a> | <a href='/?module=calendar&type=plus'>Вперед</a>";
    $calendar .= '<tr class="calendar-row">';
    for ($x = 0; $x < $running_day; $x++) {
        $calendar .= '<td class="calendar-day-np"> </td>';
        $days_in_this_week++;
    }

    for ($list_day = 1; $list_day <= $days_in_month; $list_day++)
    {
        $list_day = str_pad($list_day, 2, '0', STR_PAD_LEFT);
        $calendar .= '<td class="calendar-day">';
        $date = $year . '-' . $month . '-' . $list_day;

        $q = "SELECT * FROM $table_items WHERE DATE(date) = '$date'";
        $result = mysqli_query($conn, $q);
        if (mysqli_num_rows($result) > 0)
            $calendar .= '<p><a href="/date/'. $date .'">'. $list_day .'</a></p>';
        else
            $calendar .= '<p>'. $list_day .'</p>';

        $calendar .= '</td>';
        if ($running_day == 6) {
            $calendar .= '</tr>';
            if (($day_counter + 1) != $days_in_month) {
                $calendar .= '<tr class="calendar-row">';
            }
            $running_day = -1;
            $days_in_this_week = 0;
        }
        $days_in_this_week++;
        $running_day++;
        $day_counter++;
    }

    if($days_in_this_week < 8)
    {
        for($x = 1; $x <= (8 - $days_in_this_week); $x++) {
            $calendar .= '<td class="calendar-day-np"> </td>';
        }
    }

    $calendar.= '</tr>';

    $calendar.= '</table>';

    return $calendar;
}

function get_page($p_id, $session_month, $session_year)
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
    $tpl->get_tpl('main.tpl');
    $tpl->set_var('SITE-TITLE', $site_title . " | " . $row['title']);
    $tpl->set_var('CONTENT', $content);
    $tpl->set_var('CALENDAR', get_calendar($session_month, $session_year));
    $tpl->set_array($row);
    $tpl->set_array(parse_fields($row['fields']));
    $tpl->tpl_parse();

    mysqli_close($conn);

    return $tpl->template;
}

function get_cat($cat_id, $session_month, $session_year, $date)
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
        $q .= " WHERE i.cat_id = $cat_id";
        if (validate_date($date, "Y-m-d"))
        {
            $q .= " AND i.date = '$date'";
        }
    }
    else
    {
        if (validate_date($date, "Y-m-d"))
        {
            $q .= " WHERE i.date = '$date'";
        }
        else
        {
            if (!empty($date))
            {
                throw_error("Нет новостей по такой дате добавления.");
            }
        }
    }

    $result = mysqli_query($conn, $q);

    if (!($result->num_rows > 0))
    {
        throw_error("Нет новостей в данной категории и/или по такой дате добавления.");
    }

    $content = "";
    while ($row = mysqli_fetch_array($result)) {
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
    $tpl->set_var('CALENDAR', get_calendar($session_month, $session_year));
    $tpl->tpl_parse();
    echo $tpl->template;
    die();

    mysqli_close($conn);

    return $tpl->template;
}