<form method="post" action="">
    <textarea name="txt">Sample http://google.com sentence http://yandex.ru/mypage/myverypage/asdsa from KomunitasWeb, http://yandex.ru/mypage/myverypage/asdsa.html regex has become popular in web programming. Now we learn regex. According to wikipedia, Regular expressions (abbreviated as regex or regexp, with plural forms regexes, regexps, or regexen) are written in a formal language that can be interpreted by a regular expression processor</textarea>
    <button type="submit">Отправить</button>
</form>

<?php
if (empty($_POST['txt']))
    die();
$text = $_POST['txt'];

function get_name($mathes)
{
    $arr = explode('/', $mathes[0]);
    $name = array_pop($arr);
    if (!empty($name))
    {
        return "<a href='{$mathes[0]}'><font color=\"red\">$name</font></a>";
    } else
    {
        return "<a href='{$mathes[0]}'><font color=\"red\">{$mathes[0]}</font></a>";
    }
}

echo "Previous: " . $text . "<br /><br />";
$text = preg_replace_callback("/((http|https)\:\/\/([A-Z0-9][A-Z0-9_-][A-Z0-9]*)\.([A-Z0-9_\/_\.]*))/i", 'get_name', $text);

echo "Modified: " . $text;