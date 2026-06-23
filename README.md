# SpendWise

A personal-finance dashboard that turns raw transactions into a monthly spending plan. Built to demonstrate a pragmatic .NET + React product architecture.

## Highlights

- ASP.NET Core 8 minimal API with explicit validation and RESTful resource design
- React + TypeScript dashboard with category summaries and budget-status states
- Docker Compose for a repeatable local environment
- Domain-first model suitable for adding PostgreSQL/EF Core persistence

## Core user stories

1. Record income and expenses.
2. Categorize transactions and inspect the current month.
3. Set a budget for a category and immediately see remaining spend.

## Suggested demo flow

Create a food budget, add two expenses, and show the remaining-budget calculation updating in the dashboard. That makes the business logic visible in under a minute.

