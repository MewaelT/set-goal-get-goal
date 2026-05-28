# Set Goal, Get Goal Constitution

## Core Principles

### I. Quality-First Code
- Source code MUST be readable, maintainable, and easy to navigate.
- Modules, services, components, and APIs MUST be designed for independent testing and minimal coupling.
- All behavior-critical logic MUST be documented with intent, not just implementation details.
- Refactoring is expected whenever complexity grows faster than the current code structure can safely support.

### II. Test-Driven Delivery
- Tests are mandatory for every new feature, bug fix, and behavior change.
- When feasible, write tests before implementation and use red-green-refactor cycles.
- Unit tests MUST cover validation, business logic, and edge cases for goals, progress entries, completion, and dashboard metrics.
- Integration tests MUST validate end-to-end flows for the MVP experience, including goal creation, progress updates, and dashboard reporting.
- Regression tests MUST capture discovered defects and prevent repeat failures.

### III. Consistent User Experience
- User interactions MUST be consistent across the application in form layout, messaging, feedback, and error handling.
- The UI MUST be responsive, accessible, and usable across desktop and mobile breakpoints.
- Visual patterns MUST maintain consistent spacing, typography, iconography, and tone.
- User-facing copy MUST be clear, direct, and aligned with the app’s goal-tracking purpose.

### IV. Performance & Reliability
- User-visible actions MUST complete within 300ms on typical desktop connections.
- API endpoints MUST target <200ms p95 response time in normal operation.
- The application MUST avoid N+1 data access patterns, unbounded queries, and unnecessary payloads.
- Failure modes MUST be handled gracefully with clear recovery messaging and retry guidance where appropriate.

### V. Continuous Feedback & Governance
- Every pull request MUST pass automated linting, formatting, static analysis, and test suites before merge.
- Changes that add complexity MUST be justified with measurable user value or risk reduction.
- Design and implementation decisions MUST be reviewed against this constitution during planning and execution.
- Amendments to this constitution MUST be documented, reviewed, and dated.

## Non-Functional Requirements
- Code quality is enforced by linting, formatting, and peer review.
- Test coverage MUST be sufficient to verify core behavior and regressions; at a minimum, critical flows are protected by automated tests.
- UX consistency MUST be preserved through reusable components, shared patterns, and review of changes across screens.
- Performance budgets MUST be respected for load time, API response, and data fetch efficiency.

## Development Workflow
- Branches SHOULD follow a clear feature naming convention and reference the related spec or task.
- Pull requests MUST include a summary, affected areas, test evidence, and any constitution compliance notes.
- No change is mergeable without passing the required automated checks and addressing review feedback.
- Complexity must be justified explicitly when introducing architectural or cross-cutting changes.

## Governance
- This constitution supersedes lower-level preferences when evaluating feature proposals, plans, and implementations.
- All work MUST align with the principles above; constitution violations are treated as blockers until resolved.
- Constitution amendments MUST be made in this document and include a ratified date and version update.
- Reviewers and maintainers are responsible for enforcing these principles during code review and planning.

**Version**: 0.1.0 | **Ratified**: 2026-05-27 | **Last Amended**: 2026-05-27
