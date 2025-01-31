# Генерация случайного пароля

## Описание
Программа предназначена для установки и удаления паролей у файлов. В основе работы используется библиотека `GroupDocs.Merger`, позволяющая манипулировать защищёнными файлами.

## Функциональность
- Генерация случайного пароля.
- Сохранение пароля в текстовый файл.
- Установка пароля на файл.
- Удаление пароля с файла.
- Выбор файла для обработки через диалоговое окно.

## Как использовать

### Генерация и установка пароля:
1. Выбрать файл с помощью кнопки **"Выбрать файл"**.
2. Нажать **"Сгенерировать пароль"**.
3. Пароль сохранится в `пароль.txt` и применится к файлу.

### Удаление пароля:
1. Выбрать файл с помощью кнопки **"Выбрать файл"**.
2. Нажать **"Удалить пароль"**.
3. Программа загрузит сохранённый пароль из `пароль.txt` и снимет защиту.

## Используемые технологии
- **C# (Windows Forms)** — GUI-приложение
- **GroupDocs.Merger** — библиотека для работы с файлами
