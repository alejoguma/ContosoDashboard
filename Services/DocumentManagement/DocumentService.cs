using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoDashboard.Models.DocumentManagement;
using ContosoDashboard.Data;
using Microsoft.EntityFrameworkCore;

namespace ContosoDashboard.Services.DocumentManagement
{
    public class DocumentService
    {
        private readonly ApplicationDbContext _db;
        public DocumentService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Document>> GetUserDocumentsAsync(int userId)
        {
            return await _db.Documents.Where(d => d.UploadedBy == userId).OrderByDescending(d => d.UploadDate).ToListAsync();
        }
    }
}
