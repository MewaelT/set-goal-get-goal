# Set Goal, Get Goal — Product Requirement

### 1. Product Vision

Set Goal, Get Goal is a simple goal and activity tracker that helps users create goals, track daily progress, monitor streaks, and view a dashboard showing consistency and completion.

The purpose of this project is to build a clean, portfolio-ready full-stack application while practicing professional engineering habits: requirements gathering, API design, clean architecture, middleware, Docker, testing, CI/CD, and documentation.

### 2. Problem Statement

### 3. Target User

### 4. MVP Scope

#### MVP Features

1. Create a goal
2. View all goals
3. View goal details
4. Update a goal
5. Delete a goal
6. Add daily progress to a goal
7. Mark a goal as completed
8. View dashboard summary:
    - Total goals
    - Active goals
    - Completed goals
    - Missed goals
    - Current streak

### 5. Out of Scope

#### Out of Scope for MVP

- Authentication
- User accounts
- Role-based access
- Email notifications
- Mobile app
- Payment features
- Social sharing
- Complex analytics

### 6. User Stories

1. As a user, I want to create a goal so that I can track something important to me.
2. As a user, I want to view all my goals so that I can monitor my progress.
3. As a user, I want to view a single goal in detail so that I can see progress history and status.
4. As a user, I want to update a goal so that I can change details when plans change.
5. As a user, I want to delete a goal so that I can remove goals I no longer need.
6. As a user, I want to add daily progress updates so that I can track consistency.
7. As a user, I want to mark a goal as completed so that I can track achievements.
8. As a user, I want to see a dashboard summary so that I can understand my overall performance and streaks.

### 7. Acceptance Criteria

#### Goal Creation

- User can create a goal with required fields.
- Goal is saved to database.
- API returns 201 Created.

#### Goal Retrieval

- User can retrieve all goals.
- User can retrieve a goal by ID.

#### Goal Update

- User can update editable goal fields.
- UpdatedAt should change automatically.

#### Goal Delete

- User can delete a goal.
- Deleted goal no longer appears in retrieval.

#### Progress Tracking

- User can add progress entries to a goal.
- Progress entries store date and notes.

#### Goal Completion

- User can mark a goal completed.
- Goal status updates correctly.

#### Dashboard

- Dashboard returns total goals.
- Dashboard returns active goals and completed goals.
- Dashboard returns streak information.

### 8. Data Model

### 9. API Requirements

### 10. Technical Decisions

#### Frontend

- React
- Axios
- Responsive CSS

#### Backend

- [ASP.NET](http://ASP.NET) Core Web API
- Entity Framework Core
- PostgreSQL

#### Infrastructure

- Docker
- Docker Compose
- GitHub Actions

#### Documentation

- Swagger/OpenAPI
- Markdown docs
- GitHub Spec Kit
- Notion

#### Testing

- xUnit

### 11. Project Constitution

The project follows a constitution stored in `.specify/memory/constitution.md` that mandates:
- quality-first code design,
- mandatory test coverage for new features and regressions,
- consistent UX patterns,
- measurable performance and reliability goals.

### 12. Risks / Questions

### 12. Bugs & Lessons Learned