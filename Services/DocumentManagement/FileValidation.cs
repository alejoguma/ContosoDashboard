using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ContosoDashboard.Services.DocumentManagement
{
    public static class FileValidation
    {
        private static readonly string[] AllowedExtensions = { ".pdf", ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx", ".txt", ".jpg", ".jpeg", ".png" };
        private const int MaxFileSize = 25 * 1024 * 1024; // 25MB

        public static bool IsAllowedExtension(string fileName)
        {
            var ext = Path.GetExtension(fileName).ToLowerInvariant();
            return AllowedExtensions.Contains(ext);
        }

        public static bool IsAllowedSize(long fileSize)
        {
            return fileSize <= MaxFileSize;
        }

        public static string? ValidateFile(IFormFile file)
        {
            if (!IsAllowedExtension(file.FileName))
                return "Unsupported file type.";
            if (!IsAllowedSize(file.Length))
                return "File exceeds 25MB size limit.";
            return null;
        }
    }
}
