using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace Treasures.Common.Interfaces;

public interface ICloudinaryService {
    Task<ImageUploadResult?> UploadFile(IFormFile file, string itemId, string? publicId, int? width, int? height);
    Task<DeletionResult> RemoveFile(string fileId);
}   