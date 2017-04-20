<?php
/**
 * Created by PhpStorm.
 * User: Ilya
 * Date: 15.04.2017
 * Time: 22:57
 */
class Model_category extends Model
{
    function get_data($parameters)
    {
        require 'application/libs/config.php';
        require 'application/libs/functions.php';
        add_page();

        $cat_id = $parameters[0];
        $date = $parameters[1] ?? "";

        $cat_id = abs(intval($cat_id));
        $conn = mysqli_connect($db_host, $db_user, $db_pass, $db_name);
        $cat_row = mysqli_query($conn, "SELECT cat_name FROM $table_cats WHERE cat_id = $cat_id");
        if (!($cat_row->num_rows > 0))
        {
            throw_error("Нет такой категории.", $site_title);
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
            throw_error("Нет новостей в данной категории и/или по такой дате добавления.", $site_title);
        }

        $mysql_row = array();
        while ($row = mysqli_fetch_array($result)) {
            $mysql_row[] = $row;
        }

        mysqli_close($conn);

        $data = array();
        $data[0] = $mysql_row;
        $data[1] = $site_title;
        $data[2] = get_banners();
        $data[3] = get_calendar();
        $data[4] = get_login();
        return $data;
    }
}