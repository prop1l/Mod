
```html
<!DOCTYPE html>
<html lang="ru">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Zoo Ticket App</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
        }
        h1, h2 {
            color: #333;
        }
        ul {
            list-style-type: disc;
            padding-left: 20px;
        }
        pre {
            background-color: #282a36;
            color: #f8f8f2;
            padding: 10px;
            border-radius: 5px;
            overflow-x: auto;
        }
    </style>
</head>
<body>
    <h1>Zoo Ticket App</h1>
    <p>Простое и удобное приложение для продажи билетов в зоопарке с разграничением ролей и интеграцией с PostgreSQL.</p>

    <p>Zoo Ticket App — это десктоп-приложение на базе WPF, реализованное по паттерну MVVM, предназначенное для управления билетами, пользователями и экскурсиями в зоопарке. Приложение поддерживает:</p>

    <ul>
        <li>Просмотр доступных типов билетов</li>
        <li>Добавление билетов в корзину</li>
        <li>Отображение общей суммы заказа</li>
        <li>Разграничение прав: администратор, кассир, пользователь</li>
        <li>Навигацию между страницами через кнопки</li>
    </ul>

    <h2>Технологии</h2>
    <ul>
        <li><strong>WPF</strong> – графический интерфейс</li>
        <li><strong>C# / .NET 8.0</strong></li>
        <li><strong>MVVM</strong> – архитектурный паттерн</li>
        <li><strong>Entity Framework Core</strong> – ORM для взаимодействия с БД</li>
        <li><strong>PostgreSQL</strong> – реляционная система управления базами данных</li>
        <li><strong>XAML</strong> – разметка интерфейса</li>
        <li><strong>RelayCommand</strong> – реализация команд для MVVM</li>
        <li><strong>Frame NavigationService</strong> – навигация между страницами</li>
    </ul>

    <h2>Структура проекта</h2>
    <pre>
Mod/
├── Database/              # Контекст и модели БД
│   └── ZooContext.cs      # EF Core контекст
├── ViewModels/            # Реализация ViewModel'ей
│   └── MainViewModel.cs   # Главная логика приложения
├── Views/                 # XAML-страницы
│   ├── MainWindow.xaml    # Главное окно
│   ├── TicketsPage.xaml   # Страница с билетами
│   ├── CartPage.xaml      # Корзина
│   └── AdminPanelPage.xaml# Административная панель
├── Command/               # Команды
│   └── RelayCommand.cs   # Реализация ICommand
├── Services/              # Сервисы
│   └── NavigationService.cs # Навигация между страницами
└── Models/                # Модели из БД
    </pre>
</body>
</html>
