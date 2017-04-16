<?php

include_once 'Template.php';


function throw_error($message, $site_title)
{
    $err = new Template();
    $err->get_tpl('error.tpl');
    $err->set_var('SITE-TITLE', $site_title . " | " . $message);
    $err->tpl_parse();
    $err = $err->template;

    $tpl = new Template();
    $tpl->get_tpl('main.tpl');
    $tpl->set_var('SITE-TITLE', $site_title . " | " . $message);
    $tpl->set_var('CALENDAR', get_calendar($_SESSION['month'], $_SESSION['year']));
    $tpl->set_array(get_banners());
    $tpl->set_var('CONTENT', $err);
    $tpl->set_var('ERR_MESSAGE', $message);
    $tpl->tpl_parse();
    echo $tpl->template;
    die();
}

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

function add_page()
{
    require 'config.php';
    $conn = mysqli_connect($db_host, $db_user, $db_pass, $db_name);

    $q = "INSERT INTO `$table_history`(`session_id`, `page_url`, `time`) VALUES ('" . session_id() . "', '" . $_SERVER['REQUEST_URI'] . "', '" . date("Y-m-d H:i:s") . "')";
    mysqli_query($conn, $q);
    mysqli_close($conn);
}

function get_login()
{
    if ($_SESSION['logged'])
    {
        $tpl = new Template();
        $tpl->get_tpl('logged.tpl');
        $tpl->set_var('LOGIN', $_SESSION['login']);
        $tpl->tpl_parse();
        return $tpl->template;
    }
    else
    {
        $tpl = new Template();
        $tpl->get_tpl('not-logged.tpl');
        $tpl->tpl_parse();
        return $tpl->template;
    }
}

function get_banners()
{
    require 'config.php';
    $conn = mysqli_connect($db_host, $db_user, $db_pass, $db_name);

    $q = "SELECT * FROM `$table_banners`";
    $result = mysqli_query($conn, $q);

    $banners = array();

    while ($row = mysqli_fetch_array($result)) {
        if ($row['is_show'] > 0)
        {
            $tpl = new Template();
            $tpl->get_tpl('banner.tpl');
            $tpl->set_var('BANNER_SRC', $row['src']);
            $tpl->set_var('BANNER_ALT', $row['alt']);
            $tpl->set_var('BANNER_LINK', $row['link']);
            $tpl->set_var('BANNER_WIDTH', $row['width']);
            $tpl->set_var('BANNER_HEIGHT', $row['height']);
            $tpl->tpl_parse();
        }

        $banner = $tpl->template;
        $banners['BANNER-' . $row['id']] = $banner;
    }
    mysqli_close($conn);
    return $banners;
}

function get_sitemap()
{
    require 'config.php';
    $sitemap = '<?xml version="1.0" encoding="UTF-8"?>';
    $sitemap .= '<urlset xmlns="http://www.sitemaps.org/schemas/sitemap/0.9">';
    $conn = mysqli_connect($db_host, $db_user, $db_pass, $db_name);

    $q = "SELECT i.id, i.date, c.cat_name FROM $table_items i JOIN $table_cats c ON i.cat_id = c.cat_id";
    $result = mysqli_query($conn, $q);

    while ($row = mysqli_fetch_array($result)) {
        $sitemap .= '
        <url>
            <loc>http://'.$_SERVER['SERVER_NAME'].'/item/id/'. $row['id'] .'</loc>
            <lastmod>'. date('c', strtotime($row['date'])) .'</lastmod>
        </url>';
    }

    $q = "SELECT cat_id FROM $table_cats";
    $result = mysqli_query($conn, $q);

    while ($row = mysqli_fetch_array($result)) {
        $sitemap .= '
        <url>
            <loc>http://'.$_SERVER['SERVER_NAME'].'/category/id/'. $row['cat_id'] .'</loc>
        </url>';
    }

    $sitemap .= '</urlset>';
    return $sitemap;
}

function get_new_month_year($month, $year, $delta)
{
    if ($delta == 1)
    {
        if ($month == 12)
        {
            $month = 0;
            $year++;
        }
        else
        {
            $month++;
        }
    }
    else if ($delta == -1)
    {
        if ($month == 0)
        {
            $month = 12;
            $year--;
        }
        else
        {
            $month--;
        }
    }
    return array($month, $year);
}

function get_calendar($month, $year)
{
    require 'config.php';

    $conn = mysqli_connect($db_host, $db_user, $db_pass, $db_name);

    $month = str_pad($month, 2, '0', STR_PAD_LEFT);
    $year = str_pad($year, 4, '0', STR_PAD_LEFT);
    $calendar = '<table cellpadding="0" cellspacing="0" class="calendar">';

    $running_day = date('w', mktime(0, 0, 0, $month, 1, $year));
    $days_in_month = date('t', mktime(0, 0, 0, $month, 1, $year));
    $days_in_this_week = 1;
    $day_counter = 0;

    $calendar .= date("F Y", mktime(0, 0, 0, $month, 1, $year));;

    $new_date_minus = get_new_month_year($month, $year, -1);
    $new_date_plus = get_new_month_year($month, $year, 1);

    $calendar .= "<br><a href='/calendar/set/".$new_date_minus[0]."/".$new_date_minus[1]."'>Назад</a> | <a href='/calendar/set/".$new_date_plus[0]."/".$new_date_plus[1]."'>Вперед</a>";
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
            $calendar .= '<p><a href="/category/id/0/'. $date .'">'. $list_day .'</a></p>';
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
