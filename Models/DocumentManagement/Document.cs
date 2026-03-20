using System;
using System.Collections.Generic;

namespace ContosoDashboard.Models.DocumentManagement
{
    public class Document
    {
        public int DocumentId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Category { get; set; } = string.Empty;
        public int? ProjectId { get; set; }
        public string? Tags { get; set; }
        public string FilePath { get; set; } = string.Empty;
        public string FileType { get; set; } = string.Empty;
        public int FileSize { get; set; }
        public int UploadedBy { get; set; }
        public DateTime UploadDate { get; set; }
    }

    public class DocumentShare
    {
        public int DocumentId { get; set; }
        public int? UserId { get; set; }
        public int? TeamId { get; set; }
        public int SharedBy { get; set; }
        public DateTime SharedDate { get; set; }
    }
}
