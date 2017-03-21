<?php
    include("./include/config.php");
    include("./include/Template.php");

    $conn = mysqli_connect($db_host, $db_user, $db_pass, $db_name);

    if (isset($_POST['title']))
    {
        $title = mysqli_real_escape_string($conn, $_POST['title']);
        $date = mysqli_real_escape_string($conn, $_POST['date']);
        $cat_id = mysqli_real_escape_string($conn, $_POST['cat_id']);
        $img = mysqli_real_escape_string($conn, $_POST['img']);
        $short_desc = mysqli_real_escape_string($conn, $_POST['short_desc']);
        $full_desc = mysqli_real_escape_string($conn, $_POST['full_desc']);
        $fields = mysqli_real_escape_string($conn, $_POST['fields']);
        $q = "INSERT INTO `$table_items`(`title`, `date`, `cat_id`, `img`, `short_desc`, `full_desc`, `fields`) VALUES ('$title', '$date', '$cat_id', '$img', '$short_desc', '$full_desc', '$fields')";
        echo $q;
        $result = mysqli_query($conn, $q);
    }
?>
    <form action="" method="post">
    <p>Название <input name="title" width='500' required></p>
    <p>Дата <input name="date" width='500' value="<?php echo date("Y-m-d"); ?>"></p>
    <p>ID категории <input name="cat_id" width='500' required></p>
    <p>Адрес картинки <input name="img" width='500' required></p>
    <p>Краткое описание <textarea rows="10" cols="45" name="short_desc"></textarea></p>
    <p>Полное описание <textarea rows="10" cols="45" name="full_desc"></textarea></p>
    <p><textarea rows="10" cols="45" name="fields">main_mass| ||main_crew| ||main_length| ||main_width| ||gun| ||gun_type| ||gun_load| ||gun_ammunation| ||gun_stabilizer| ||gun_coupled| ||gun_antiaircraft| ||gun_addition| ||protection_type| ||protection_smoke| ||protection_addition| ||engine| ||engine_type| ||engine_cooling| ||engine_power| ||mobility_suspension| ||country|</textarea></p>

    <p><input type="submit" value="Отправить"></p>
</form>