<!DOCTYPE html>
<html lang="en">

<head>{FILE="header.tpl"}</head>

<body>
<div class="header-main"><h1 class="header-main_text">Сравнение вооружений разных стран</h1></div>

<nav class="nav">
    <header><h2 class="aside-header">Навигация</h2></header>
    <hr>
    <ul>
        <li><a href="/">Главная</a></li>
        <li><a href="/cat/1">ОБТ</a></li>
        <li><a href="/cat/2">БМП</a></li>
        <li><a href="/cat/3">БТР</a></li>
        <li><a href="/cat/4">БРМ</a></li>
        <li><a href="/cat/5">ЛТ</a></li>
    </ul>
    <hr>
    {BANNER-2}
    <br>
    <br>
    <header><h2 class="aside-header">Календарь</h2></header>
    <hr>
    {CALENDAR}
    <br>
    {BANNER-1}
</nav>

<article>{BANNER-4}{CONTENT}</article>
<hr>
<footer>Copyright &copy 2017. Сравнение вооружений разных стран. Пользователей: {DB="users"}. Новостей: {DB="news"}. <a href="/sitemap.xml">Карта сайта</a></footer>
</body>
</html>