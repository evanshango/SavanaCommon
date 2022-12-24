using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Treasures.Common.Interfaces;

namespace Treasures.Common.Services;

public class CloudinaryService : ICloudinaryService {
    private readonly Cloudinary _cloudinary;

    public CloudinaryService(string cloudName, string apiKey, string apiSecret) => _cloudinary = new Cloudinary(
        new Account(cloudName, apiKey, apiSecret)
    );

    public async Task<ImageUploadResult?> UploadFile(IFormFile file, string itemId, int? width, int? height) {
        if (file.Length <= 0) return null;

        var extension = file.FileName.Split(".")[file.FileName.Split(".").Length - 1];
        var fileName = $"{DateTime.Now:yyyyMMddHHmmssffff}.{extension.ToLower()}";

        await using var stream = file.OpenReadStream();
        var uploadParams = new ImageUploadParams {
            File = new FileDescription(fileName, stream),
            Folder = itemId,
            Transformation = new Transformation().Width(width).Height(height).Crop("fill").Gravity("face"),
        };

        return await _cloudinary.UploadAsync(uploadParams);
    }

    public async Task<DeletionResult> RemoveFile(string fileId) {
        return await _cloudinary.DestroyAsync(new DeletionParams(fileId));
    }
}