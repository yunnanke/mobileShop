# Backend Integration Map

Текущий frontend намеренно работает без подключения к API.

## Что уже есть в `REST_mobile`

В бэкенде сейчас есть generic CRUD-контроллеры по основным таблицам:

- `devices`
- `tariff-plans`
- `clients`
- `employees`
- `contracts`
- `sim-cards`
- `sales`
- `payments`
- `promotion-discounts`
- `service-orders`
- `device-repairs`
- и другие базовые сущности

## Что ещё понадобится под ТЗ

С точки зрения текущего ТЗ фронту в будущем нужны отдельные endpoints под сценарии, а не только CRUD по таблицам:

- `POST /auth/login`
- `GET /devices` с фильтрами и пагинацией
- `GET /tariffs`
- `GET /promotions`
- `GET /profile`
- `GET /repairs`
- `GET /contracts`
- `GET /bonus`
- `POST /sales`
- `PUT /repairs/{id}/close`
- `POST /contracts` с созданием договора через SIM

## Что это значит сейчас

- витрина и кабинеты уже собраны как UI
- API-каркас вынесен в `src/services/api`
- прямой привязки к `REST_mobile` пока нет
- перед интеграцией нужно будет согласовать реальные маршруты и DTO
