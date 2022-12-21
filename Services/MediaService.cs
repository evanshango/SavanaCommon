using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;
using Treasures.Common.Interfaces;

namespace Treasures.Common.Services;

public class MediaService : IMedia {
    private readonly Cloudinary _cloudinary;

    public MediaService(string cloudName, string apiKey, string apiSecret) {
        var account = new Account(cloudName, apiKey, apiSecret);
        _cloudinary = new Cloudinary(account);
    }

    public async Task<string> UploadFile(IFormFile file, int? width, int? height) {
        return "";
    }

    public async Task<string> RemoveFile(string fileName) {
        return "";
    }
}