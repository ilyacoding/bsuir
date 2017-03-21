<?php
define('DELIMITER', '/');

function get_files($filedir)
{
	if ($handle = @opendir($filedir)) {
    echo $filedir;
	    while ($entry = readdir($handle)) {
	        if ($entry == "." || $entry == "..")
	            continue;


            if (is_dir($filedir . DELIMITER . $entry))
            {
                print("----------<br />");
                print("Каталог: " . $entry . "<br />");
                print("Дата изменения: " . date("F d Y H:i:s.", filectime($filedir . DELIMITER . $entry)) . "<br />");
                print("Дата обращения: " . date("F d Y H:i:s.", fileatime($filedir . DELIMITER . $entry)) . "<br />");
                $dir_size = 0;
                $recursive_dir = new RecursiveIteratorIterator(new RecursiveDirectoryIterator($filedir . DELIMITER . $entry));
                foreach ($recursive_dir as $element)
                {
                    if ($element->isFile())
                    {
                        $dir_size += filesize($element);
                    }
                }
                print("Размер: " . $dir_size/1000 . " КБайт<br />");
                print("<br />");
            }
            else if (is_file($filedir . DELIMITER . $entry))
            {
                print("----------<br />");
                print("Файл: " . $entry . "<br />");
                print("Размер: " . filesize($filedir . DELIMITER . $entry)/1000 . " КБайт<br />");
                print("Дата изменения: " . date("F d Y H:i:s.", filectime($filedir . DELIMITER . $entry)) . "<br />");
                print("Дата обращения: " . date("F d Y H:i:s.", fileatime($filedir . DELIMITER . $entry)) . "<br />");
                $content = substr(file_get_contents($filedir . DELIMITER . $entry), 0, 100);
                if (strlen($content) > 0)
                    print("Первые 100 символов: " . htmlspecialchars($content) . "<br />");
                print("<br />");
            }
        }
	    closedir($handle);
	}
	else
    {
        echo "Неверная директория.";
    }
}

if (!empty($_GET['dir']))
{
    get_files($_SERVER['DOCUMENT_ROOT'] . DELIMITER . $_GET['dir']);
    exit;
}

echo '<form action="" method="get">
  <p><b>Директория</b></p>
  <p><input type="text" name="dir" value="">
  <p><input type="submit"></p>
 </form>';