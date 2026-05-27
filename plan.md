# Implementation Plan — Set Goal, Get Goal

## Goal

Build a production-ready MVP goal tracker with a React frontend, ASP.NET Core Web API backend, PostgreSQL database, Docker support, tests, and documentation.

---

## Architecture

The app will use a simple full-stack architecture:

- React frontend calls backend APIs using Axios
- ASP.NET Core Web API handles business logic
- EF Core communicates with PostgreSQL
- Docker Compose runs frontend, backend, and database locally
- GitHub Actions validates build and tests

---

## Backend Layers

Controllers:
- Receive HTTP requests
- Return HTTP responses

Services:
- Contain business logic
- Keep controllers clean

DTOs:
- Shape request and response data
- Avoid exposing database models directly

Models:
- Represent database entities

Data:
- Contains EF Core DbContext

Middleware:
- Handles cross-cutting concerns like errors and request logging

## API Design

### Goals

POST /api/goals
- Create a new goal

GET /api/goals
- Get all goals

GET /api/goals/{id}
- Get one goal by ID

PUT /api/goals/{id}
- Update a goal

DELETE /api/goals/{id}
- Delete a goal

PATCH /api/goals/{id}/complete
- Mark a goal as completed

### Progress

POST /api/goals/{id}/progress
- Add daily progress to a goal

### Dashboard

GET /api/dashboard/summary
- Get dashboard summary

## Data Design

### Goal

A goal represents something the user wants to accomplish.

Relationships:
- One Goal can have many GoalProgress records.

### GoalProgress

A progress record represents one daily update for a goal.

Relationships:
- One GoalProgress belongs to one Goal.

## 3-Day Delivery Plan

### Day 1
- Finalize requirements
- Create GitHub repo
- Create solution structure
- Build backend folder structure
- Add Goal and GoalProgress models
- Configure PostgreSQL with EF Core
- Add Goal CRUD endpoints
- Enable Swagger

### Day 2
- Add progress tracking endpoint
- Add dashboard summary endpoint
- Add exception middleware
- Add request logging middleware
- Add CORS
- Add xUnit tests
- Add Docker and Docker Compose

### Day 3
- Build React frontend
- Connect frontend to backend with Axios
- Add GitHub Actions
- Complete README
- Complete docs folder
- Final testing and polish