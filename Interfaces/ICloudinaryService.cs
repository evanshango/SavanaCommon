using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace Treasures.Common.Interfaces;

public interface ICloudinaryService {
    Task<ImageUploadResult?> UploadFile(IFormFile file, int? width, int? height);
    Task<DeletionResult> RemoveFile(string fileId);
}