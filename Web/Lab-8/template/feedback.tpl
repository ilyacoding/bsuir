<div class="dcont" align="center">
    <form action="/feedback/send" method="post">
    <h2>Обратная связь</h2>
    <table class="tableform">

        <tr>
            <td class="label">
                Ваше имя:<span class="impot">*</span>
            </td>
            <td><input type="text" maxlength="35" name="name" class="f_input" /></td>
        </tr>

        <tr>
            <td class="label">
                Кому:<span class="impot">*</span>
            </td>
            <td><select name="recid">
                    {FEEDBACK-USERS}
                </select></td>
        </tr>
        <tr>
            <td class="label">
                Тема:<span class="impot">*</span>
            </td>
            <td><input type="text" maxlength="45" name="subject" class="f_input" /></td>
        </tr>
        <tr>
            <td class="label" valign="top">
                Сообщение:
            </td>
            <td><textarea name="message" style="width: 380px; height: 160px" class="f_textarea"></textarea></td>
        </tr>

    </table>
    <div align="center">
        <button name="send_btn" class="fbutton" type="submit"><span>Отправить</span></button>
    </div>
    </form>
</div>