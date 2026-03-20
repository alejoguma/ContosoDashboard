# Data Model: Document Upload and Management

## Entities

### Document
- **DocumentId** (int, PK)
- **Title** (string, required)
- **Description** (string, optional)
- **Category** (enum/string, required)
- **ProjectId** (int, FK to Project, required)
- **Tags** (string[], optional)
- **FilePath** (string, required, not web-accessible)
- **FileType** (string, required)
- **FileSize** (int, required)
- **UploadedBy** (int, FK to User, required)
- **UploadDate** (DateTime, required)

### DocumentShare
- **DocumentId** (int, FK to Document, PK)
- **UserId** (int, FK to User, PK, nullable)
- **TeamId** (int, FK to Team, PK, nullable)
- **SharedBy** (int, FK to User, required)
- **SharedDate** (DateTime, required)

### Project (existing)
- **ProjectId** (int, PK)
- ...

### User (existing)
- **UserId** (int, PK)
- ...

## Relationships
- Document belongs to Project
- Document uploaded by User
- DocumentShare links Document to User or Team

## Validation Rules
- File size ≤ 25MB
- File type in whitelist (PDF, Office, image, text)
- Title, category, project required
- Description, tags optional
- FilePath must not be in wwwroot

## State Transitions
- Uploaded → (shared/edited/deleted)
- Shared → (unshared/deleted)
- Edited → (replaces file/metadata)
- Deleted → (permanently removed)

---

All fields and rules align with requirements and constitution constraints.