# Implementation Plan: Set Goal, Get Goal

**Branch**: `feature/set-goal-get-goal`

**Date**: 2026-05-27

**Spec**: `specs/set-goal-get-goal/spec.md`

## Summary

Build the MVP goal tracker as a responsive web application with a React frontend, ASP.NET Core Web API backend, and PostgreSQL storage. The implementation will focus on clean architecture, automated tests, consistent UX patterns, and performance-sensitive API endpoints.

## Technical Context

**Language/Version**: C# / .NET 8 (or latest stable ASP.NET Core), JavaScript/TypeScript with React

**Primary Dependencies**: ASP.NET Core Web API, Entity Framework Core, React, Axios, PostgreSQL, xUnit

**Storage**: PostgreSQL

**Testing**: xUnit for backend, Jest/React Testing Library for frontend, end-to-end tests if feasible

**Target Platform**: Web browser (desktop and mobile responsive)

**Project Type**: Web application with separate frontend and backend concerns

**Performance Goals**: API endpoints should target <200ms p95 response time; user-visible actions should complete within 300ms on typical desktop connections

**Constraints**: No authentication, no user accounts, no social or payment features; must follow the project constitution for code quality, testing, UX, and performance

**Scale/Scope**: MVP for a single-user goal tracking experience with a handful of core screens and data flows

## Constitution Check

*GATE: Must pass before Phase 0 research. Re-check after Phase 1 design.*

- The plan MUST align with the project constitution in `.specify/memory/constitution.md`.
- All planned work MUST support quality-first code, mandatory test coverage, consistent UX, and defined performance expectations.
- The architecture MUST be simple, modular, and independently testable.
- Any increase in complexity MUST be justified in the plan.

## Project Structure

### Proposed Structure

```text
backend/
├── Controllers/
├── Models/
├── Data/
├── Services/
├── DTOs/
└── Tests/

frontend/
├── src/
│   ├── components/
│   ├── pages/
│   ├── services/
│   ├── hooks/
│   └── styles/
└── tests/
```

**Structure Decision**: A two-tier web application structure keeps the UI and API responsibilities separated, which supports independent testing and aligns with the constitution’s quality and UX consistency requirements.

## Complexity Tracking

> **Fill ONLY if Constitution Check has violations that must be justified**

| Violation | Why Needed | Simpler Alternative Rejected Because |
|-----------|------------|-------------------------------------|
| Two-tier frontend/backend separation | Enables clean API contracts and reusable UI service layers | Single project with mixed concerns would make testing and future scaling harder |
| Dashboard aggregation logic | Required to support metrics like streaks and missed goals | Keeping it in UI only would duplicate logic and reduce reliability |

## Implementation Plan

1. Define the data model and API contracts.
   - Goal entity
   - ProgressEntry entity
   - DashboardSummary aggregate
   - API routes for goals, progress entries, completion, and dashboard

2. Implement backend persistence and endpoints.
   - Create EF Core models and migrations
   - Build goal CRUD controllers
   - Build progress entry controller
   - Build dashboard controller with aggregated metrics
   - Add input validation and error handling

3. Build frontend feature flows.
   - Goal list and create/edit UI
   - Goal detail view with progress timeline
   - Progress entry creation form
   - Dashboard view with counts and streaks
   - Shared layout, responsive styles, and consistent feedback patterns

4. Add automated tests.
   - Unit tests for business logic and API controllers
   - Integration tests for backend flows and database operations
   - Frontend tests for component behavior and form validation
   - Regression tests for key user journeys

5. Validate performance and quality.
   - Ensure backend endpoints meet p95 latency targets in normal operation
   - Verify reusable frontend patterns and consistent styling
   - Run linting, formatting, and static analysis before merge

## Tasks

- [ ] Create `Goal` and `ProgressEntry` data models
- [ ] Add PostgreSQL schema and EF Core migrations
- [ ] Implement goal CRUD API endpoints
- [ ] Implement progress entry API endpoints
- [ ] Implement dashboard summary API endpoint
- [ ] Build React pages for goals, goal detail, progress entry, and dashboard
- [ ] Add frontend service layer using Axios
- [ ] Create unit and integration tests for backend
- [ ] Create unit tests for frontend components
- [ ] Add responsive styling and consistent UX patterns
- [ ] Document API contracts and architecture decisions

## Notes

- Follow the constitution’s quality gates for every implementation decision.
- Keep the first iteration focused on the MVP scope and avoid out-of-scope features.
- If new complexity is introduced, document and justify it in the plan or PR notes.
