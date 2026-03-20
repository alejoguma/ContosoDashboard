using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace ContosoDashboard.Services.DocumentManagement
{
    public interface IFileStorageService
    {
        Task<string> UploadAsync(IFormFile file, string filePath);
        Task DeleteAsync(string filePath);
        Task<byte[]> DownloadAsync(string filePath);
        Task<string> GetUrlAsync(string filePath);
    }
}
