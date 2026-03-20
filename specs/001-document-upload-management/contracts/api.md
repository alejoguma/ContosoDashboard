# API Contract: Document Upload and Management

## Upload Document
- **POST** `/api/documents/upload`
- **Body**: Multipart/form-data
  - file: binary
  - title: string (required)
  - category: string (required)
  - description: string (optional)
  - projectId: int (required)
  - tags: string[] (optional)
- **Response**: 200 OK { documentId, metadata } | 400/413 error

## List Documents
- **GET** `/api/documents`
- **Query**: filter, sort, search params
- **Response**: 200 OK [ { document metadata } ]

## Download Document
- **GET** `/api/documents/{id}/download`
- **Response**: file stream | 404

## Preview Document
- **GET** `/api/documents/{id}/preview`
- **Response**: inline PDF/image | 404

## Share Document
- **POST** `/api/documents/{id}/share`
- **Body**: { userId/teamId }
- **Response**: 200 OK | 404

## Edit Metadata
- **PUT** `/api/documents/{id}`
- **Body**: { title, category, description, tags }
- **Response**: 200 OK | 404

## Delete Document
- **DELETE** `/api/documents/{id}`
- **Response**: 200 OK | 404

## Integration
- **POST** `/api/tasks/{taskId}/documents/upload` (attach to task)

---

All endpoints are for demo/training only. No real security or production guarantees.