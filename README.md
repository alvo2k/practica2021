## Практическая работа на тему «Разработка прикладного программного продукта для операционных систем семейства Windows «Запись в приемную директора»

Стек: ``` C#, WinForms, MSSQL```

### Список изменений

01.12.21

- Добавлены файлы с прошлой практики

02.12.21

- Изменение названия форм и форма времени работы теперь открывается по центру родителя
- Добавлена форма авторизации
- Проведен рефакторинг
- Исправлено падение приложения при первом запуске
- Добавлена база данных
- Добавлена таблица в БД с пользователями

03.12.21

- Добавленно подключение к БД
- Добавленна функциональность формы авторизации
- Добавлены проверки валидности вводимых данных

04.12.21

- Дополнительные проверки формы регистрации
- Создание таблицы с записями приемов

05.12.21

- Добавлено сохранение неотправленной заявки
- Проверка пользователя на админ права
- Загрузка встреч из БД в ListBox

06.12.21

- Добавлена загрузка встечи из БД 

07.12.21

- Загрузка встречи в поля TextBox
- Изменена кодировка символов БД
- Исправлен парсер ListBox
- Изменены логика отправки почты, добавлена отмена записи
- Проверка ввода email только на английском

08.12.21

- Дизайн формы авторизации
- Добавлена форма редактирования профиля
- Добавлена функция выхода из учетной записи
