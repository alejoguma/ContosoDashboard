# Research: Document Upload and Management

## Unknowns and Clarifications

### Technical Context (from plan template)

- **Language/Version**: .NET 8 (C#)
- **Primary Dependencies**: Blazor Server, Entity Framework Core, local file storage, mock virus scanning (demo logic), notification service (existing), authentication (mock/demo)
- **Storage**: Local disk (outside wwwroot), Entity Framework for metadata
- **Testing**: xUnit, bUnit (for Blazor), manual test scripts for file upload flows
- **Target Platform**: Windows (training/demo), browser (Blazor Server)
- **Project Type**: Web application (Blazor Server)
- **Performance Goals**: Upload ≤25MB in <30s, search/list/preview ≤2-3s for ≤500 docs
- **Constraints**: No real credentials, no production security, offline/local only, all security is mock/demo, all limitations documented
- **Scale/Scope**: Up to 500 documents, 10–50 users (training/demo)

## Research Tasks

### 1. Virus/Malware Scanning (Demo)
- Decision: Use a mock virus scan (simulate scan delay, always pass for whitelisted types)
- Rationale: Constitution prohibits real security; demo logic suffices for training
- Alternatives: Integrate ClamAV or Windows Defender (rejected: not allowed by constitution)

### 2. File Storage Location
- Decision: Store files outside wwwroot, in a dedicated local folder (e.g., /Data/Uploads)
- Rationale: Prevent direct web access, aligns with security-by-example
- Alternatives: Store in wwwroot (rejected: less secure, not best practice)

### 3. File Type Whitelisting
- Decision: Allow PDF, Office docs, images, text; reject others
- Rationale: Matches requirements, easy to demo
- Alternatives: Allow all types (rejected: not safe, not realistic)

### 4. Metadata and Search
- Decision: Store all required metadata in EF Core; index for fast search
- Rationale: Simplicity, demo value, aligns with requirements
- Alternatives: Use full-text search engine (rejected: overkill for scale)

### 5. Offline/Local-Only Support
- Decision: All features work offline; no cloud dependencies
- Rationale: Constitution constraint
- Alternatives: Cloud storage (rejected: not allowed)

### 6. Integration with Existing Features
- Decision: Use existing notification and authentication services (mock/demo)
- Rationale: Reuse, demo value
- Alternatives: Build new (rejected: unnecessary)

---

All clarifications resolved. No open unknowns remain for Phase 1 design.