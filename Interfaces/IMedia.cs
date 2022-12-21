using Microsoft.AspNetCore.Http;

namespace Treasures.Common.Interfaces;

public interface IMedia {
    Task<string> UploadFile(IFormFile file, int? width, int? height);
    Task<string> RemoveFile(string fileName);
}