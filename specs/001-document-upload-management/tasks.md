---
description: "Task list for Document Upload and Management feature"
---

# Tasks: Document Upload and Management

**Input**: Design documents from `/specs/001-document-upload-management/`
**Prerequisites**: plan.md (required), spec.md (required for user stories), research.md, data-model.md, contracts/

**Tests**: Only if explicitly requested (not required by spec)

**Organization**: Tasks are grouped by user story to enable independent implementation and testing of each story.

## Phase 1: Setup (Shared Infrastructure)

**Purpose**: Project initialization and basic structure

  - [X] T001 Create folder structure for document management in ContosoDashboard/
  - [X] T002 Initialize Document, DocumentShare models in ContosoDashboard/Models/
  - [X] T003 [P] Add document upload endpoints to ContosoDashboard/Services/
  - [X] T004 [P] Add document management navigation to ContosoDashboard/Shared/NavMenu.razor

---

## Phase 2: Foundational (Blocking Prerequisites)

**Purpose**: Core infrastructure that MUST be complete before ANY user story can be implemented

  - [X] T005 Setup database schema and migrations for Document and DocumentShare in Data/ApplicationDbContext.cs
  - [X] T006 [P] Implement file storage logic (max 25MB, allowed types) in ContosoDashboard/Services/
  - [X] T007 [P] Configure error handling for document endpoints in ContosoDashboard/Services/
  - [X] T008 Setup environment config for file storage in appsettings.json
  - [X] T009 [P] Add base validation for document upload in ContosoDashboard/Services/

**Checkpoint**: Foundation ready - user story implementation can now begin in parallel

---

## Phase 3: User Story 1 - Upload Documents (Priority: P1) 🎯 MVP

**Goal**: Employees can upload one or more work-related documents, provide required metadata, and see upload progress/results.

**Independent Test**: Upload a PDF and a Word file, see them listed with correct metadata, and receive success/failure messages.

### Implementation for User Story 1

  - [X] T010 [P] [US1] Implement POST /api/documents/upload in ContosoDashboard/Services/
  - [X] T011 [P] [US1] Add file size/type validation logic in ContosoDashboard/Services/
  - [X] T012 [US1] Add upload progress UI in ContosoDashboard/Pages/Projects.razor
  - [X] T013 [US1] Show upload result and error messages in ContosoDashboard/Pages/Projects.razor
  - [X] T014 [US1] Save document metadata to database in Data/ApplicationDbContext.cs
  - [X] T015 [US1] List uploaded documents for user in ContosoDashboard/Pages/Projects.razor

**Checkpoint**: User Story 1 should be fully functional and testable independently

---

## Phase 4: User Story 2 - Organize and Browse Documents (Priority: P2)

**Goal**: Users can view, sort, and filter their documents and project documents by category, project, date, and other metadata.

**Independent Test**: User uploads several documents, then filters by category and sorts by date to find a specific file.

### Implementation for User Story 2

- [X] T016 [P] [US2] Implement GET /api/documents with filter/sort in ContosoDashboard/Services/
- [X] T017 [US2] Add document list UI with filter/sort in ContosoDashboard/Pages/Projects.razor
- [X] T018 [US2] Show project documents to project members in ContosoDashboard/Pages/ProjectDetails.razor

**Checkpoint**: User Stories 1 AND 2 should both work independently

---

## Phase 5: User Story 3 - Download, Preview, and Share (Priority: P3)

**Goal**: Users can download, preview (PDF/images), and share documents with other users or teams, with notifications for recipients.

**Independent Test**: User shares a document with a team, recipients see it in "Shared with Me" and get notified.

### Implementation for User Story 3

- [X] T019 [P] [US3] Implement GET /api/documents/{id}/download in ContosoDashboard/Services/
- [X] T020 [P] [US3] Implement GET /api/documents/{id}/preview in ContosoDashboard/Services/
- [X] T021 [US3] Implement POST /api/documents/{id}/share in ContosoDashboard/Services/
- [X] T022 [US3] Add preview/download/share UI in ContosoDashboard/Pages/Projects.razor
- [X] T023 [US3] Show "Shared with Me" section in ContosoDashboard/Pages/Projects.razor
- [X] T024 [US3] Trigger notification on share in ContosoDashboard/Services/NotificationService.cs

**Checkpoint**: All user stories should now be independently functional

---

## Phase 6: User Story 4 - Edit and Delete Documents (Priority: P4)

**Goal**: Users can edit document metadata, replace files, and delete documents they own; project managers can manage all project documents.

**Independent Test**: User edits a document title, replaces a file, and deletes a document, confirming removal.

### Implementation for User Story 4

- [X] T025 [P] [US4] Implement PUT /api/documents/{id} for metadata edit in ContosoDashboard/Services/
- [X] T026 [P] [US4] Implement file replacement logic in ContosoDashboard/Services/
- [X] T027 [US4] Implement DELETE /api/documents/{id} in ContosoDashboard/Services/
- [X] T028 [US4] Add edit/delete UI in ContosoDashboard/Pages/Projects.razor
- [X] T029 [US4] Add project manager permissions in ContosoDashboard/Services/

**Checkpoint**: All user stories up to P4 should be independently testable

---

## Phase 7: User Story 5 - Integration and Notifications (Priority: P5)

**Goal**: Document management integrates with tasks, dashboard widgets, and notifications for sharing and uploads.

**Independent Test**: User uploads a document from a task page, sees it in project documents, and receives notifications.

### Implementation for User Story 5

- [X] T030 [P] [US5] Implement POST /api/tasks/{taskId}/documents/upload in ContosoDashboard/Services/
- [X] T031 [US5] Show document upload in task page in ContosoDashboard/Pages/Tasks.razor
- [X] T032 [US5] Show document widget in dashboard in ContosoDashboard/Pages/Index.razor
- [X] T033 [US5] Trigger notification on upload/share in ContosoDashboard/Services/NotificationService.cs

**Checkpoint**: All user stories complete and integrated

---

## Phase 8: Polish & Cross-Cutting Concerns

**Purpose**: Improvements that affect multiple user stories

- [X] T034 [P] Documentation updates in StakeholderDocs/document-upload-and-management-feature.md
- [X] T035 Code cleanup and refactoring in ContosoDashboard/
- [X] T036 Performance optimization for document endpoints in ContosoDashboard/Services/
- [X] T037 [P] Additional unit tests for document logic in ContosoDashboard/Services/
- [X] T038 Security hardening for file storage and endpoints in ContosoDashboard/Services/
- [X] T039 Run quickstart.md validation in specs/001-document-upload-management/quickstart.md

---

## Dependencies & Execution Order

### Phase Dependencies

- **Setup (Phase 1)**: No dependencies - can start immediately
- **Foundational (Phase 2)**: Depends on Setup completion - BLOCKS all user stories
- **User Stories (Phase 3+)**: All depend on Foundational phase completion
  - User stories can then proceed in parallel (if staffed)
  - Or sequentially in priority order (P1 → P2 → P3 → P4 → P5)
- **Polish (Final Phase)**: Depends on all desired user stories being complete

### User Story Dependencies

- **User Story 1 (P1)**: Can start after Foundational (Phase 2) - No dependencies on other stories
- **User Story 2 (P2)**: Can start after Foundational (Phase 2) - May integrate with US1 but should be independently testable
- **User Story 3 (P3)**: Can start after Foundational (Phase 2) - May integrate with US1/US2 but should be independently testable
- **User Story 4 (P4)**: Can start after Foundational (Phase 2) - May integrate with previous stories but should be independently testable
- **User Story 5 (P5)**: Can start after Foundational (Phase 2) - May integrate with previous stories but should be independently testable

### Within Each User Story
- Models before services
- Services before endpoints
- Core implementation before integration
- Story complete before moving to next priority

### Parallel Opportunities
- All [P] tasks in Setup, Foundational, and each user story can run in parallel
- User stories can be implemented in parallel after Foundational phase
- UI and backend tasks for a story can be parallelized if files are independent

---

## Parallel Example: User Story 1

- T010 [P] [US1] Implement POST /api/documents/upload in ContosoDashboard/Services/
- T011 [P] [US1] Add file size/type validation logic in ContosoDashboard/Services/

---

## Implementation Strategy

### MVP First (User Story 1 Only)
1. Complete Phase 1: Setup
2. Complete Phase 2: Foundational (CRITICAL - blocks all stories)
3. Complete Phase 3: User Story 1
4. **STOP and VALIDATE**: Test User Story 1 independently
5. Deploy/demo if ready

### Incremental Delivery
1. Complete Setup + Foundational → Foundation ready
2. Add User Story 1 → Test independently → Deploy/Demo (MVP!)
3. Add User Story 2 → Test independently → Deploy/Demo
4. Add User Story 3 → Test independently → Deploy/Demo
5. Each story adds value without breaking previous stories

### Parallel Team Strategy
With multiple developers:
1. Team completes Setup + Foundational together
2. Once Foundational is done:
   - Developer A: User Story 1
   - Developer B: User Story 2
   - Developer C: User Story 3
3. Stories complete and integrate independently
