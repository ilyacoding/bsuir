<?php
session_start();
include_once($_SERVER['DOCUMENT_ROOT'] . "/include/functions.php");

if (!empty($_REQUEST['module']))
{
    switch ($_REQUEST['module'])
    {
        case "calendar":
            if (!empty($_REQUEST['type']))
            {
                switch ($_REQUEST['type'])
                {
                    case "plus":
                        if ($_SESSION['month'] == 12)
                        {
                            $_SESSION['year']++;
                            $_SESSION['month'] = 0;
                        }
                        else
                        {
                            $_SESSION['month'] += 1;
                        }
                        break;
                    case "minus":
                        if ($_SESSION['month'] == 0)
                        {
                            $_SESSION['year']--;
                            $_SESSION['month'] = 12;
                        }
                        else
                        {
                            $_SESSION['month'] -= 1;
                        }
                        break;
                }
            }
            break;
    }
}

if (!isset($_SESSION['month']) || !isset($_SESSION['year']))
{
    $_SESSION['month'] = date("m");
    $_SESSION['year'] = date("Y");
}

if (!empty($_GET['item']))
{
    echo get_page($_GET['item'], $_SESSION['month'], $_SESSION['year']);
}
else
{
    $cat_id = $_GET['cat_id'] ?? 0;
    echo get_cat($cat_id, $_SESSION['month'], $_SESSION['year'], $_GET['date'] ?? "");
}
