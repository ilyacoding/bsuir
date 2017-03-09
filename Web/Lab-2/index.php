<?php
include_once("./include/functions.php");


if (!empty($_GET['p']))
{
    echo GetPage($_GET['p']);
}
else
{
    $cat_id = $_GET['cat'] ?? 0;
    echo GetCat($cat_id);
}
