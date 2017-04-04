<?php
header("Content-Type: application/xml;");
include_once($_SERVER['DOCUMENT_ROOT'] . "/include/functions.php");

echo get_sitemap();