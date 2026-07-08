# SpendWise

A personal-finance dashboard that turns raw transactions into a monthly spending plan. Built to demonstrate a pragmatic .NET + React product architecture.

[![CI](https://github.com/YUVARAJKUNCHALA/spendwise/actions/workflows/ci.yml/badge.svg)](https://github.com/YUVARAJKUNCHALA/spendwise/actions/workflows/ci.yml)

## Portfolio Signal

SpendWise demonstrates product thinking on top of a practical full-stack foundation: clear user stories, explicit API validation, a simple domain model, and a React dashboard that makes the financial state visible immediately.

## Highlights

- ASP.NET Core 8 minimal API with explicit validation and RESTful resource design
- React + TypeScript dashboard with category summaries and budget-status states
- Docker Compose for a repeatable local environment
- Domain-first model suitable for adding PostgreSQL/EF Core persistence

## Architecture

```text
React + TypeScript dashboard
        ↓
ASP.NET Core 8 minimal API
        ↓
Transaction and category domain model
        ↓
Future persistence boundary for PostgreSQL / EF Core
```

## Core user stories

1. Record income and expenses.
2. Categorize transactions and inspect the current month.
3. Set a budget for a category and immediately see remaining spend.

## API Surface

| Method | Endpoint | Purpose |
| --- | --- | --- |
| `GET` | `/api/summary` | Return income, expenses, balance, and category totals |
| `POST` | `/api/transactions` | Add an income or expense transaction |

Example transaction:

```bash
curl -X POST http://localhost:8080/api/transactions \
  -H "Content-Type: application/json" \
  -d '{"description":"Groceries","category":"Food","kind":"expense","amount":48.72}'
```

## Run Locally

```bash
docker compose up --build
```

The API is available at `http://localhost:8080`. The React client can also be run directly from `client/` during development.

## Suggested demo flow

Create a food budget, add two expenses, and show the remaining-budget calculation updating in the dashboard. That makes the business logic visible in under a minute.

## Engineering Notes

- Request validation keeps invalid transaction data out of the domain layer.
- The category summary endpoint is intentionally shaped for dashboard rendering.
- The current in-memory storage keeps the demo easy to run; the model is ready for EF Core persistence.

## Roadmap

- [ ] Add PostgreSQL persistence with EF Core migrations
- [ ] Add monthly budget limits per category
- [ ] Add unit tests for summary calculations
- [ ] Add charts for category trends and month-over-month comparison
