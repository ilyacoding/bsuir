<?php
session_start();

define('DELIMITER', '/');

echo "<a href='?mode=view&path=/'>Корень</a> | <a href='?mode=view'>Просмотр</a> | <a href='?mode=addfile'>Создать файл</a> | <a href='?mode=adddir'>Создать каталог</a><br />";

if (isset($_GET['path']))
{
    $_SESSION['path'] = $_GET['path'];
}

if ($_SESSION['path'] == '/')
{
    $_SESSION['path'] = '';
}

if (!isset($_REQUEST['mode']))
{
    $_REQUEST['mode'] = 'view';
}

switch ($_REQUEST['mode']) {
    case "addfile":
        if (!empty($_GET['file'])) {
            if (empty($_SESSION['path']))
            {
                $filepath = $_SERVER['DOCUMENT_ROOT'] . DELIMITER . $_GET['file'];
            }
            else
            {
                $filepath = $_SERVER['DOCUMENT_ROOT'] . DELIMITER . $_SESSION['path'] . DELIMITER . $_GET['file'];
            }

            if (touch($filepath))
                echo 'Файл ' . $_GET['file'] . ' успешно создан.<br />';
            else
                echo 'Ошибка при создании файла ' . $_GET['file'] . '.<br />';
        } else {
            echo '<form action="" method="get">
            <p><b>Файл</b></p>
            <p><input type="hidden" name="mode" value="addfile"></p>
            <p><input type="text" name="file" value=""></p>
            <p><input type="submit"></p>
            </form>';
        }

        break;

    case "adddir":

        if (!empty($_GET['file']))
        {
            if (empty($_SESSION['path']))
            {
                $filepath = $_SERVER['DOCUMENT_ROOT'] . DELIMITER . $_GET['file'];
            }
            else
            {
                $filepath = $_SERVER['DOCUMENT_ROOT'] . DELIMITER . $_SESSION['path'] . DELIMITER . $_GET['file'];
            }

            if (@mkdir($filepath))
                echo 'Каталог ' . $_GET['file'] . ' успешно создан.<br />';
            else
                echo 'Ошибка при создании каталога ' . $_GET['file'] . '.<br />';
        }
        else
        {
            echo '<form action="" method="get">
            <p><b>Каталог</b></p>
            <p><input type="hidden" name="mode" value="adddir"></p>
            <p><input type="text" name="file" value=""></p>
            <p><input type="submit"></p>
            </form>';
        }

        break;

    case "remove":
        if (!empty($_GET['file']))
        {
            $filepath = $_SERVER['DOCUMENT_ROOT'] . DELIMITER . $_GET['file'];
            if (is_dir($filepath))
            {
                if (remove_dir($filepath))
                    echo "Директория успешно удалена <br />";
                else
                    echo "Ошибка при удалении директории <br />";
            }
            else
            {
                if (@unlink($filepath))
                {
                    echo "Файл успешно удален <br />";
                }
                else
                {
                    echo "Ошибка при удалении файла <br />";
                }
            }
        }
        break;

    case "view":
        echo "Текущая директория: " . $_SERVER['DOCUMENT_ROOT'] . ' ' . DELIMITER . ' ' . $_SESSION['path'] . "<br />";
        echo get_files($_SERVER['DOCUMENT_ROOT'] . DELIMITER . $_SESSION['path']);
        break;

    case "edit":
        if (!empty($_GET['file']))
        {
            $file_content = file_get_contents($_GET['file']);
            echo '<form action="" method="post">
            <p><b>Файл</b></p>
            <p><input type="hidden" name="mode" value="save"></p>
            <p><input type="hidden" name="file" value="'.$_GET['file'].'"></p>
            <p><textarea name="content">'.htmlspecialchars($file_content).'</textarea></p>
            <p><input type="submit"></p>
            </form>';
        }
        else
        {
            echo 'Не выбран файл.';
        }
        break;

    case "save":
        if (!empty($_POST['file']) && !empty($_POST['content']))
        {
            if ($file = fopen($_POST['file'], "w+")) {
                if (fwrite($file, $_POST['content']))
                {
                    fclose($file);
                    echo 'Файл ' . $_POST['file'] . ' был успешно обновлён.';
                }
            }
            else
            {
                echo 'Не могу открыть файл.';
            }
        }
        else
        {
            echo 'Недостаточно данных для сохранения в файл.';
        }
        break;

    default:

        break;
}

function file_date($filepath)
{
    return date("F d Y H:i:s", filectime($filepath));
}

function dir_size($filepath) {
    $dir_size = 0;
    $recursive_dir = new RecursiveIteratorIterator(new RecursiveDirectoryIterator($filepath));
    foreach ($recursive_dir as $element)
    {
        if ($element->isFile())
        {
            $dir_size += filesize($element);
        }
    }
    return $dir_size;
}

function remove_dir($path) {
    $files = glob(preg_replace('/(\*|\?|\[)/', '[$1]', $path).'/{,.}*', GLOB_BRACE);
    foreach ($files as $file)
    {
        if ($file == $path.'/.' || $file == $path.'/..')
        {
            continue;
        }
        is_dir($file) ? remove_dir($file) : unlink($file);
    }
    rmdir($path);
    if (!file_exists($path))
    {
        return true;
    }
    else
    {
        return false;
    }
}

function get_files($filedir)
{
    $content = "<table border='1'>";
    if ($handle = @opendir($filedir)) {

        $content .= "<tr><td>Название</td><td>Размер</td><td>Дата изменения</td><td>Удаление</td><td>Редактирование</td><td>MD5 хеш</td></tr>";
        while ($entry = readdir($handle)) {
            if ($entry == ".")
                continue;

            if (empty($_SESSION['path']))
            {
                $filepath = $entry;
            }
            else
            {
                $filepath = $_SESSION['path'] . DELIMITER . $entry;
            }

            if (is_dir($filedir . DELIMITER . $entry))
            {
                if ($entry == "..")
                {
                    $content .= "<tr><td><a href='?mode=view&path=" . substr($_SESSION['path'], 0, strripos($_SESSION['path'], DELIMITER))."'>" . $entry . "</a></td></tr>";
                }
                else
                {


                    $content .= "<tr>";
                    $content .= "<td><a href='?mode=view&path=" . $filepath . "'>" . $entry . "</a></td>";
                    $content .= "<td>" . dir_size($filepath)/1000 . " КБайт</td>";
                    $content .= "<td>" . file_date($filepath) . "</td>";
                    $content .= "<td>(<a href='?mode=remove&file=" . $filepath . "'>Удалить</a>)</td>";
                    $content .= "</tr>";
                }
            }
            else
            {
                $content .= "<tr>";
                $content .= "<td>" . $entry . "</td>";
                $content .= "<td>" . filesize($filepath)/1000 . " КБайт</td>";
                $content .= "<td>" . date("F d Y H:i:s", filectime($filepath)) . "</td>";
                $content .= "<td>(<a href='?mode=remove&file={$filepath}'>Удалить</a>)</td>";
                $content .= "<td>(<a href='?mode=edit&file=" . $filepath . "'>Редактировать</a>)</td>";
                $content .= "<td>" . hash_file('md5', $filepath) . "</td>";
                $content .= "</tr>";
            }
        }
        closedir($handle);
    }
    else
    {
        echo "Неверный путь";
    }
    $content .= "</table>";
    return $content;
}


