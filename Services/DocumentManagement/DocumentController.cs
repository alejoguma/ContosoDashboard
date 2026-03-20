using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ContosoDashboard.Services.DocumentManagement;
using ContosoDashboard.Models.DocumentManagement;
using ContosoDashboard.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ContosoDashboard.Services.DocumentManagement
{
    [ApiController]
    [Route("api/documents")]
    public class DocumentController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IFileStorageService _storage;
        private readonly IConfiguration _config;

        public DocumentController(ApplicationDbContext db, IFileStorageService storage, IConfiguration config)
        {
            _db = db;
            _storage = storage;
            _config = config;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] IFormFile file, [FromForm] string title, [FromForm] string category, [FromForm] string? description, [FromForm] int? projectId, [FromForm] string? tags)
        {
            var validation = FileValidation.ValidateFile(file);
            if (validation != null)
                return BadRequest(validation);

            var userId = 1; // TODO: Replace with actual user context
            var guid = Guid.NewGuid().ToString();
            var ext = System.IO.Path.GetExtension(file.FileName);
            var filePath = $"{userId}/{(projectId.HasValue ? projectId.ToString() : "personal")}/{guid}{ext}";

            await _storage.UploadAsync(file, filePath);

            var doc = new Document
            {
                Title = title,
                Description = description,
                Category = category,
                ProjectId = projectId,
                Tags = tags,
                FilePath = filePath,
                FileType = file.ContentType,
                FileSize = (int)file.Length,
                UploadedBy = userId,
                UploadDate = DateTime.UtcNow
            };
            _db.Documents.Add(doc);
            await _db.SaveChangesAsync();
            return Ok(new { documentId = doc.DocumentId, metadata = doc });
        }
    }
}
