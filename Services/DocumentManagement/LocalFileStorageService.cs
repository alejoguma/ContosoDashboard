using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ContosoDashboard.Services.DocumentManagement
{
    public class LocalFileStorageService : IFileStorageService
    {
        private readonly string _basePath;
        public LocalFileStorageService(string basePath)
        {
            _basePath = basePath;
        }

        public async Task<string> UploadAsync(IFormFile file, string filePath)
        {
            var fullPath = Path.Combine(_basePath, filePath);
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath)!);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return filePath;
        }

        public Task DeleteAsync(string filePath)
        {
            var fullPath = Path.Combine(_basePath, filePath);
            if (File.Exists(fullPath))
                File.Delete(fullPath);
            return Task.CompletedTask;
        }

        public async Task<byte[]> DownloadAsync(string filePath)
        {
            var fullPath = Path.Combine(_basePath, filePath);
            return await File.ReadAllBytesAsync(fullPath);
        }

        public Task<string> GetUrlAsync(string filePath)
        {
            // For local storage, return a relative path or throw NotSupportedException
            return Task.FromResult(filePath);
        }
    }
}
