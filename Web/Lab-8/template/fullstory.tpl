<article class="fullstory">
    <header><h2>{TITLE}</h2></header>
    <p class="fullstory-bar">Время добавления: {DATE} | Категория: {CAT_NAME} | Страна: {X_COUNTRY}</p>
    <hr>
    <div class="fullstory-block">
        <div class="fullstory-img">
            <img src="{IMG}">
        </div>
        <section class="fullstory-content">
            {FULL_DESC}
        </section>
        <section class="fullstory-ttx">
            <p>Тактико-технические характеристики</p>
            <table class="fullstory-table" cellspacing="1">
                <tr><td class="fullstory-table-title" colspan="2">Общие данные</td></tr>
                <tr><td>Боевая масса, т</td><td>{X_MAIN_MASS}</td></tr>
                <tr><td>Экипаж, чел</td><td>{X_MAIN_CREW}</td></tr>
                <tr><td>Длина корпуса, мм</td><td>{X_MAIN_LENGTH}</td></tr>
                <tr><td>Ширина общая, мм</td><td>{X_MAIN_WIDTH}</td></tr>

                <tr><td class="fullstory-table-title" colspan="2">Вооружение</td></tr>
                <tr><td>Пушка</td><td>{X_GUN}</td></tr>
                <tr><td>Тип пушки</td><td>{X_GUN_TYPE}</td></tr>
                <tr><td>Заряжание</td><td>{X_GUN_LOAD}</td></tr>
                <tr><td>Боекомплект</td><td>{X_GUN_AMMUNATION}</td></tr>
                <tr><td>Стабилизатор</td><td>{X_GUN_STABILIZER}</td></tr>
                <tr><td>Спаренное вооружение</td><td>{X_GUN_COUPLED}</td></tr>
                <tr><td>Зенитное вооружение</td><td>{X_GUN_ANTIAIRCRAFT}</td></tr>
                <tr><td>Дополнительное вооружение</td><td>{X_GUN_ADDITION}</td></tr>

                <!--<tr><td class="fullstory-table-title" colspan="2">Система управления огнем</td></tr>
                <tr><td>Дальномер, тип</td><td>{FIRECONTROL_RANGEFINDER}</td></tr>
                <tr><td>Диапазон измерения дальности, м</td><td>{FIRECONTROL_MEASUREMENT}</td></tr>-->

                <tr><td class="fullstory-table-title" colspan="2">Защищенность</td></tr>
                <tr><td>Броневая защита, тип</td><td>{X_PROTECTION_TYPE}</td></tr>
                <tr><td>Дымовые гранатометы, шт</td><td>{X_PROTECTION_SMOKE}</td></tr>
                <tr><td>Дополнительно</td><td>{X_PROTECTION_ADDITION}</td></tr>

                <tr><td class="fullstory-table-title" colspan="2">Подвижность</td></tr>
                <tr><td>Двигатель</td><td>{X_ENGINE}</td></tr>
                <tr><td>Тип</td><td>{X_ENGINE_TYPE}</td></tr>
                <tr><td>Охлаждение</td><td>{X_ENGINE_COOLING}</td></tr>
                <tr><td>Максимальная мощность</td><td>{X_ENGINE_POWER}</td></tr>
                <!--<tr><td>Допустимые условия эксплуатации двигателя:</td><td>{ENGINE_TEMPERATURE_RANGE}</td></tr>
                <tr><td>Тип трансмиссии</td><td>{MOBILITY_TRANSMISSION}</td></tr>-->
                <tr><td>Подвеска, тип</td><td>{X_MOBILITY_SUSPENSION}</td></tr>
            </table>
        </section>
    </div>
</article>