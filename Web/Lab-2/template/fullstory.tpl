<article class="fullstory">
    <header><h2>{TITLE}</h2></header>
    <p class="fullstory-bar">Время добавления: {DATE} | Страна: {CAT_NAME}</p>
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
                <tr><td>Боевая масса, т</td><td>46,5</td></tr>
                <tr><td>Экипаж, чел</td><td>3</td></tr>
                <tr><td>Длина корпуса, мм</td><td>6860</td></tr>
                <tr><td>Ширина общая, мм</td><td>3780</td></tr>

                <tr><td class="fullstory-table-title" colspan="2">Вооружение</td></tr>
                <tr><td>Пушка</td><td>{GUN}</td></tr>
                <tr><td>Тип пушки</td><td>{GUN_TYPE}</td></tr>
                <tr><td>Скорострельность, в/мин</td><td>{GUN_SPEED}</td></tr>
                <tr><td>Заряжание</td><td>{GUN_LOAD}</td></tr>
                <tr><td>Боекомплект</td><td>{GUN_AMMUNATION}</td></tr>
                <tr><td>Боеприпасы</td><td>{GUN_AMMUNATION_TYPE}</td></tr>
                <tr><td>Бронепробиваемость гомогенной брони на дальности 2000 м под углом 60° от нормали, мм</td><td>{GUN_PENETRATION}</td></tr>
                <tr><td>Стабилизатор</td><td>{GUN_STABILIZER}</td></tr>
                <tr><td>Спаренное вооружение</td><td>{GUN_COUPLED}</td></tr>
                <tr><td>Зенитное вооружение</td><td>{GUN_ANTIAIRCRAFT}</td></tr>
                <tr><td>Управляемое вооружение</td><td>{GUN_CONTROLLED}</td></tr>

                <tr><td class="fullstory-table-title" colspan="2">Система управления огнем</td></tr>
                <tr><td>Дальномер, тип</td><td>{FIRECONTROL_RANGEFINDER}</td></tr>
                <tr><td>Диапазон измерения дальности, м</td><td>{FIRECONTROL_MEASUREMENT}</td></tr>

                <tr><td class="fullstory-table-title" colspan="2">Защищенность</td></tr>
                <tr><td>Броневая защита, тип</td><td>{PROTECTION_TYPE}</td></tr>
                <tr><td>Дымовые гранатометы, шт</td><td>{PROTECTION_SMOKE}</td></tr>
                <tr><td>Комплекс оптико-электронного подавления</td><td>{PROTECTION_OPTOELECTRONICS}</td></tr>

                <tr><td class="fullstory-table-title" colspan="2">Подвижность</td></tr>
                <tr><td>Двигатель</td><td>{ENGINE}</td></tr>
                <tr><td>Тип</td><td>{ENGINE_TYPE}</td></tr>
                <tr><td>Охлаждение</td><td>{ENGINE_COOLING}</td></tr>
                <tr><td>Максимальная мощность, кВт (л.с.)</td><td>{ENGINE_POWER}</td></tr>
                <tr><td>Допустимые условия эксплуатации двигателя:</td><td>{ENGINE_TEMPERATURE_RANGE}</td></tr>
                <tr><td>Тип трансмиссии</td><td>{MOBILITY_TRANSMISSION}</td></tr>
                <tr><td>Подвеска, тип</td><td>{MOBILITY_SUSPENSION}</td></tr>
                <tr><td>Амортизаторы, тип</td><td>{MOBILITY_ABSORBERS}</td></tr>
            </table>
        </section>
    </div>
</article>