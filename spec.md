# Set Goal, Get Goal — Specification

## Overview

Set Goal, Get Goal is a goal and habit tracking application that allows users to create goals, track daily progress, monitor streaks, and visualize consistency through a dashboard.

This project is intended as a portfolio-focused full-stack application demonstrating production-ready engineering practices.

---

## MVP Features

1. Create a goal
2. View all goals
3. View goal details
4. Update a goal
5. Delete a goal
6. Add daily progress
7. Mark goals completed
8. Dashboard summary

---

## Out of Scope

- Authentication
- Multi-user support
- Notifications
- Payments
- Mobile application

---

## Entities

### Goal

- Id
- Title
- Description
- Category
- TargetFrequency
- StartDate
- EndDate
- Status
- CreatedAt
- UpdatedAt

### GoalProgress

- Id
- GoalId
- ProgressDate
- IsCompleted
- Notes
- CreatedAt

---

## Technical Stack

Frontend:
- React
- Axios

Backend:
- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL

Infrastructure:
- Docker
- Docker Compose
- GitHub Actions

Testing:
- xUnit