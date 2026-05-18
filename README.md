# Mobile Shop

[![GitHub stars](https://img.shields.io/github/stars/yunnanke/mobileShop)](https://github.com/yunnanke/mobileShop/stargazers)
[![GitHub license](https://img.shields.io/github/license/yunnanke/mobileShop)](https://github.com/yunnanke/mobileShop/blob/main/LICENSE)
![C#](https://img.shields.io/badge/C%23-52.4%25-blue)
![TypeScript](https://img.shields.io/badge/TypeScript-19.0%25-blue)

**Mobile Shop** — это полноценное веб-приложение для управления интернет-магазином мобильных телефонов. Проект включает backend REST API на C# и пользовательский интерфейс на TypeScript, CSS и HTML.

> **Примечание:** Проект находится в стадии активной разработки. Некоторые функции могут быть неполными или изменяться.

---

## Возможности

- **Backend (REST API)**
  - CRUD-операции для товаров, заказов и клиентов
  - Безопасная аутентификация и авторизация (в планах)
  - RESTful эндпоинты с документацией Swagger/OpenAPI

- **Frontend (Пользовательский интерфейс)**
  - Каталог товаров
  - Корзина покупок
  - Оформление и отслеживание заказов
  - Адаптивный дизайн (поддержка мобильных устройств)

- **DevOps**
  - Поддержка Docker (см. `Dockerfile`)
  - Скрипты автоматизации на PowerShell

---

## Технологии

| Компонент     | Технологии                                                                 |
|---------------|----------------------------------------------------------------------------|
| Backend       | C#, ASP.NET Core, Entity Framework Core                                    |
| Frontend      | TypeScript, HTML5, CSS3 (кастомные стили)                                  |
| База данных   | (Не указана — предположительно SQL Server / PostgreSQL, настройте под себя)|
| Инструменты   | Docker, PowerShell, Git                                                    |

---

## Начало работы

### Требования

- [.NET 6.0 SDK или новее](https://dotnet.microsoft.com/en-us/download) (для backend)
- [Node.js 16+](https://nodejs.org/) (для frontend)
- [Git](https://git-scm.com/)
- [Docker](https://www.docker.com/) (опционально, для контейнеризации)

### Установка и запуск

1. **Клонируйте репозиторий**
   ```bash
   git clone https://github.com/yunnanke/mobileShop.git
   cd mobileShop
   ```

2. **Настройка и запуск backend (REST API)**

   Перейдите в папку backend:
   ```bash
   cd REST_mobile
   ```

   Восстановите зависимости и запустите проект:
   ```bash
   dotnet restore
   dotnet run
   ```

   API будет доступно по адресу: `https://localhost:5001` или `http://localhost:5000`

   > **Подсказка:** Если используется база данных, выполните миграции:
   > ```bash
   > dotnet ef database update
   > ```

3. **Настройка и запуск frontend**

   Откройте новый терминал и перейдите в папку frontend:
   ```bash
   cd FRONT_mobile
   ```

   Установите зависимости (если есть `package.json`):
   ```bash
   npm install
   ```

   Запустите сервер разработки:
   ```bash
   npm start
   # или npm run dev
   ```

   Frontend будет доступен по адресу: `http://localhost:3000`

4. **Запуск через Docker (опционально)**

   Из корневой папки проекта выполните:
   ```bash
   docker build -t mobile-shop .
   docker run -p 8080:80 mobile-shop
   ```

---

## Структура проекта

```
mobileShop/
├── REST_mobile/          # Backend API (C#)
│   ├── Controllers/      # Обработчики запросов
│   ├── Models/           # Модели данных
│   ├── Data/             # Контекст базы данных
│   └── Program.cs        # Точка входа
├── FRONT_mobile/         # Frontend приложение
│   ├── src/              # Исходные файлы (TypeScript, CSS)
│   ├── public/           # Статические файлы
│   └── index.html        # Главная страница
├── _tmp_tz_docx/         # Временные файлы документации
├── .gitignore
├── Dockerfile            # Инструкция для сборки Docker-образа
└── README.md
```

---

## Как внести вклад

Вклад приветствуется! Следуйте этим шагам:

1. Форкните репозиторий
2. Создайте ветку для вашей функции (`git checkout -b feature/amazing-feature`)
3. Зафиксируйте изменения (`git commit -m 'Add amazing feature'`)
4. Отправьте в ваш форк (`git push origin feature/amazing-feature`)
5. Откройте Pull Request

---

## Контакты

Автор: **yunnanke**

Ссылка на проект: [https://github.com/yunnanke/mobileShop](https://github.com/yunnanke/mobileShop)

---

## Благодарности

- Всем контрибьюторам и тестировщикам
- Открытому сообществу .NET и TypeScript

---

*Последнее обновление: 14 мая 2026 г.
