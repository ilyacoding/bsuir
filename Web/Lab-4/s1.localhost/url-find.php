<?php
$text = "Sample http://google.com sentence http://yandex.ru/mypage/myverypage/asdsa from KomunitasWeb, http://yandex.ru/mypage/myverypage/asdsa.html regex has become popular in web programming. Now we learn regex. According to wikipedia, Regular expressions (abbreviated as regex or regexp, with plural forms regexes, regexps, or regexen) are written in a formal language that can be interpreted by a regular expression processor";

echo $text . "<br /><br />";

$text = preg_replace("/((http|https)\:\/\/([A-Z0-9][A-Z0-9_-][A-Z0-9]*)\.([A-Z0-9_\/_\.]*))/i", '<a href="${1}"><font color="red">${1}</font></a>', $text);
echo $text;