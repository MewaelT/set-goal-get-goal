# Tasks: Set Goal, Get Goal

**Input**: Design documents from `/specs/001-set-goal-get-goal/`

**Prerequisites**: `plan.md`, `spec.md`

## Phase 1: Setup (Shared Infrastructure)

**Purpose**: Establish the project structure, dependencies, and quality tooling.

- [X] T001 Create the backend project skeleton under `backend/`.
- [X] T002 Create the frontend project skeleton under `frontend/`.
- [ ] T003 Configure linting, formatting, and static analysis for backend and frontend.
- [ ] T004 Configure PostgreSQL local development environment and connection settings.
- [ ] T005 Add shared documentation notes to `specs/001-set-goal-get-goal/plan.md` and `specs/001-set-goal-get-goal/spec.md`.

---

## Phase 2: Foundational (Blocking Prerequisites)

**Purpose**: Build core models, database schema, and API structure required by all user stories.

- [X] T006 Create `backend/Models/Goal.cs` with fields for `Id`, `Title`, `Description`, `Status`, `CreatedAt`, `UpdatedAt`, `TargetDate`, and `CompletedAt`.
- [X] T007 Create `backend/Models/ProgressEntry.cs` with fields for `Id`, `GoalId`, `Date`, `Notes`, and `CreatedAt`.
- [X] T008 Create `backend/Data/ApplicationDbContext.cs` and register `Goals` and `ProgressEntries` DbSets.
- [ ] T009 Add EF Core migrations and database initialization for PostgreSQL.
- [X] T010 Implement base API infrastructure in `backend/Startup.cs` or `Program.cs` with routing, error handling, and JSON settings.
- [ ] T011 Add validation and common error response handling for backend requests.
- [ ] T012 Add backend integration test support in `backend/Tests/` and a sample test fixture for database-backed tests.

---

## Phase 3: User Story 1 - Create and manage goals (Priority: P1) 🎯 MVP

**Goal**: Deliver goal creation, listing, detail retrieval, and update/delete operations.

**Independent Test**: Create a goal through the API and verify it persists, can be retrieved, updated, and deleted.

### Implementation
- [ ] T013 Create `backend/Controllers/GoalsController.cs` with endpoints for create, list, get-by-id, update, and delete.
- [ ] T014 Add `backend/DTOs/GoalDto.cs` and `backend/DTOs/CreateGoalDto.cs` / `UpdateGoalDto.cs` for API contracts.
- [ ] T015 Implement goal service logic in `backend/Services/GoalService.cs`.
- [ ] T016 Implement frontend goal list page in `frontend/src/pages/GoalListPage.jsx` or `.tsx`.
- [ ] T017 Implement frontend goal detail page in `frontend/src/pages/GoalDetailPage.jsx` or `.tsx`.
- [ ] T018 Implement frontend goal create/edit form in `frontend/src/components/GoalForm.jsx` or `.tsx`.
- [X] T019 Add frontend API service methods in `frontend/src/services/api.js` or `.ts` for goals.
- [ ] T020 Add backend unit tests for goal controller and service in `backend/Tests/`.
- [ ] T021 Add frontend unit tests for goal listing and form components in `frontend/tests/`.

---

## Phase 4: User Story 2 - Track daily progress (Priority: P1)

**Goal**: Deliver progress entry creation and visibility within goal details.

**Independent Test**: Add a progress entry for a goal and confirm it appears in the goal detail view.

### Implementation
- [ ] T022 Create `backend/Controllers/ProgressEntriesController.cs` with endpoints for adding progress entries and retrieving goal progress.
- [ ] T023 Add `backend/DTOs/CreateProgressEntryDto.cs` for progress entry creation.
- [ ] T024 Implement progress entry service logic in `backend/Services/ProgressEntryService.cs`.
- [ ] T025 Extend the goal detail page in `frontend/src/pages/GoalDetailPage.jsx` or `.tsx` to show progress history.
- [ ] T026 Add `frontend/src/components/ProgressEntryForm.jsx` or `.tsx` to submit progress entries.
- [ ] T027 Add frontend API methods for progress entries in `frontend/src/services/api.js` or `.ts`.
- [ ] T028 Add backend tests covering progress entry creation and retrieval.
- [ ] T029 Add frontend tests covering progress form behavior and progress list rendering.

---

## Phase 5: User Story 3 - View dashboard summary and streaks (Priority: P1)

**Goal**: Deliver dashboard metrics for total goals, active/completed goals, missed goals, and current streak.

**Independent Test**: Verify dashboard metrics update correctly when goals and progress are updated.

### Implementation
- [ ] T030 Create `backend/Controllers/DashboardController.cs` with a `GET /dashboard` endpoint.
- [ ] T031 Implement dashboard aggregation logic in `backend/Services/DashboardService.cs`.
- [ ] T032 Create `frontend/src/pages/DashboardPage.jsx` or `.tsx` to display summary metrics.
- [ ] T033 Add dashboard UI components in `frontend/src/components/DashboardSummary.jsx` or `.tsx`.
- [ ] T034 Add frontend API call for dashboard summary in `frontend/src/services/api.js` or `.ts`.
- [ ] T035 Add backend tests for dashboard aggregation and streak calculations.
- [ ] T036 Add frontend tests for dashboard metric rendering and empty-state behavior.

---

## Phase 6: User Story 4 - Update, complete, and delete goals (Priority: P2)

**Goal**: Deliver goal editing, completion state, and deletion UX.

**Independent Test**: Edit a goal, mark it complete, and delete it while verifying state updates across the app.

### Implementation
- [ ] T037 Add completion support to `GoalsController.cs` and `GoalService.cs`.
- [ ] T038 Extend `UpdateGoalDto.cs` to include completion state or separate completion endpoint.
- [ ] T039 Add frontend controls for completing and deleting goals in `GoalDetailPage.jsx` or `.tsx`.
- [ ] T040 Update frontend goal list and detail UI to reflect completed status.
- [ ] T041 Add backend tests covering completion and deletion behavior.
- [ ] T042 Add frontend tests for completion and delete interactions.

---

## Phase 7: Polish & Cross-Cutting Concerns

**Purpose**: Improve UX, ensure quality gates, and complete documentation.

- [ ] T043 Add responsive styling and consistent UI patterns in `frontend/src/styles/`.
- [ ] T044 Ensure all API responses follow consistent error shapes and validate user-friendly messages.
- [ ] T045 Add additional unit and integration tests as needed for edge cases.
- [ ] T046 Review and update `specs/set-goal-get-goal/spec.md`, `plan.md`, and `tasks.md` with any changes.
- [ ] T047 Document setup and usage in a `README.md` or quickstart doc if required.
- [ ] T048 Run final linting and formatting checks for backend and frontend.

---

## Dependencies & Execution Order

- Phase 1 tasks can be completed first and include parallel setup work.
- Phase 2 foundational tasks block user story development until infrastructure is ready.
- Phases 3-6 are the user story implementation phases and can proceed once the foundation is complete.
- Phase 7 is final polishing once core functionality is in place.
