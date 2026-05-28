# Feature Specification: Set Goal, Get Goal

**Feature Branch**: `feature/set-goal-get-goal`

**Created**: 2026-05-27

**Status**: Draft

**Input**: User description: "Build a simple goal and activity tracker that supports goal CRUD, daily progress updates, completion tracking, and a dashboard summary of consistency."

## Clarifications

- A "missed goal" is defined as a goal with a target date that has no recorded progress by that date, or as a goal that misses expected daily activity for its current streak period.
- Should progress entries be unique per goal/date, or may multiple entries exist for the same date?
- Should completed goals be reopenable, or is completion final for MVP?
- When a goal is deleted, should all associated progress entries be removed as well?
- Is `TargetDate` optional for all goals, and if so, how does it influence streak or missed-goal calculations?

## User Scenarios & Testing *(mandatory)*

### User Story 1 - Create and manage goals (Priority: P1)
A user can create a new goal, see it listed, and view its details.

**Why this priority**: This is the core user value for tracking goals and enabling all further activity in the app.

**Independent Test**: Verify that a created goal appears in the goal list and can be retrieved by its ID.

**Acceptance Scenarios**:
1. **Given** an empty goals list, **When** the user submits a valid goal, **Then** the goal is saved and appears in the list.
2. **Given** a saved goal, **When** the user opens the goal detail view, **Then** the goal title, description, status, and progress history are displayed.

---

### User Story 2 - Track daily progress (Priority: P1)
A user can add progress entries for a goal to capture daily activity and notes.

**Why this priority**: Progress tracking is the key behavior that delivers the value of consistency monitoring.

**Independent Test**: Verify that a progress entry can be created for a goal and is listed under goal details.

**Acceptance Scenarios**:
1. **Given** an existing goal, **When** the user adds a progress entry with a date and notes, **Then** the entry is persisted and visible in the goal detail timeline.
2. **Given** a progress entry exists, **When** the user reloads the goal detail page, **Then** the entry still appears correctly.

---

### User Story 3 - View dashboard summary and streaks (Priority: P1)
A user can see a dashboard summarizing goal counts, active and completed goals, missed goals, and the current streak.

**Why this priority**: Dashboard insights validate the user’s consistency and help them understand progress at a glance.

**Independent Test**: Verify that dashboard metrics update when goals change state or progress is added.

**Acceptance Scenarios**:
1. **Given** multiple goals with different statuses, **When** the user views the dashboard, **Then** total goals, active goals, completed goals, missed goals, and current streak are displayed.
2. **Given** new progress activity for a goal, **When** the user refreshes the dashboard, **Then** the streak and missed counts reflect the latest activity.

---

### User Story 4 - Update, complete, and delete goals (Priority: P2)
A user can edit goal details, mark a goal as completed, and remove goals no longer needed.

**Why this priority**: This keeps the goal tracker flexible and prevents stale or unwanted goals from polluting the dashboard.

**Independent Test**: Verify that goal updates persist, completed goals change status, and deleted goals disappear from retrieval.

**Acceptance Scenarios**:
1. **Given** an existing goal, **When** the user edits title or description, **Then** the updated values are saved.
2. **Given** an active goal, **When** the user marks it completed, **Then** the goal status changes to completed and the dashboard updates.
3. **Given** a saved goal, **When** the user deletes it, **Then** it is removed from the goal list and detail retrieval returns not found.

---

### Edge Cases
- Creating a goal without a title should return a validation error.
- Adding a duplicate progress entry for the same date should be handled consistently.
- Updating a completed goal should preserve completion state unless explicitly reopened.
- Deleting a goal with progress history should remove associated entries.
- Dashboard behavior when there are no goals should show zero counts and an empty streak.

## Requirements *(mandatory)*

### Functional Requirements
- **FR-001**: System MUST allow users to create a goal with a title, optional description, and optional target date.
- **FR-002**: System MUST persist goals in the database and return `201 Created` on success.
- **FR-003**: Users MUST be able to retrieve all goals and retrieve individual goals by ID.
- **FR-004**: Users MUST be able to update goal details and have `UpdatedAt` change automatically.
- **FR-005**: Users MUST be able to delete goals and confirm removal from retrieval.
- **FR-006**: System MUST allow users to add progress entries to a goal with date and note metadata.
- **FR-007**: System MUST allow users to mark a goal as completed and update its status accordingly.
- **FR-008**: System MUST provide a dashboard summary with total goals, active goals, completed goals, missed goals, and current streak.
- **FR-009**: System MUST support responsive frontend behavior using React and Axios, backed by ASP.NET Core Web API, Entity Framework Core, and PostgreSQL.
- **FR-010**: System MUST enforce validation and return user-friendly error messages for invalid input.
- **FR-011**: System MUST align with the project constitution in `.specify/memory/constitution.md` for quality, testing, UX consistency, and performance.

### Key Entities *(include if feature involves data)*
- **Goal**: Represents a tracked objective with fields such as `Id`, `Title`, `Description`, `Status`, `CreatedAt`, `UpdatedAt`, `TargetDate`, and `CompletedAt`.
- **ProgressEntry**: Represents a single daily activity record with `Id`, `GoalId`, `Date`, `Notes`, and `CreatedAt`.
- **DashboardSummary**: Aggregated metrics with `TotalGoals`, `ActiveGoals`, `CompletedGoals`, `MissedGoals`, and `CurrentStreak`.

## Success Criteria *(mandatory)*

### Measurable Outcomes
- **SC-001**: Users can create a goal and see it listed within the application within 2 seconds.
- **SC-002**: Progress entries are saved and visible in the goal detail view immediately after submission.
- **SC-003**: Completed goals and deleted goals update dashboard metrics correctly.
- **SC-004**: Dashboard metrics reflect real data and provide a valid streak summary.
- **SC-005**: Core API endpoints respond under 200ms p95 in normal operation.
- **SC-006**: Automated tests cover goal CRUD, progress creation, completion flow, and dashboard aggregation.

## Assumptions
- Users are operating in a single-user environment with no authentication or accounts for MVP.
- Mobile support is delivered through responsive web design rather than a separate mobile application.
- Goal tracking is limited to CRUD, progress entries, completion, and dashboard reporting.
- External notifications, sharing, and payment features are out of scope for MVP.
- The system uses PostgreSQL as the primary datastore and ASP.NET Core Web API for backend services.
- The project constitution defines quality and governance expectations that must be followed.
