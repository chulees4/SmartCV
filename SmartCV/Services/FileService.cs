using Microsoft.Extensions.Options;
using SmartCV.Services.Interfaces;

namespace SmartCV.Services;

public class FileUploadSettings
{
    public int MaxFileSizeMB { get; set; } = 5;
    public string[] AllowedImageExtensions { get; set; } = [".jpg", ".jpeg", ".png", ".gif", ".webp"];
    public string[] AllowedDocExtensions { get; set; } = [".pdf", ".docx"];
    public string UploadPath { get; set; } = "wwwroot/uploads";
}

public class FileService : IFileService
{
    private readonly FileUploadSettings _settings;
    private readonly IWebHostEnvironment _env;

    public FileService(IOptions<FileUploadSettings> settings, IWebHostEnvironment env)
    {
        _settings = settings.Value;
        _env = env;
    }

    public async Task<string> SaveImageAsync(IFormFile file, string subfolder)
    {
        if (!IsValidImage(file)) throw new ArgumentException("File ảnh không hợp lệ.");
        return await SaveFileAsync(file, subfolder);
    }

    public async Task<string> SaveDocumentAsync(IFormFile file, string subfolder)
    {
        if (!IsValidDocument(file)) throw new ArgumentException("File tài liệu không hợp lệ.");
        return await SaveFileAsync(file, subfolder);
    }

    public void DeleteFile(string relativePath)
    {
        var fullPath = Path.Combine(_env.WebRootPath, relativePath.TrimStart('/'));
        if (File.Exists(fullPath)) File.Delete(fullPath);
    }

    public bool IsValidImage(IFormFile file)
    {
        if (file.Length > _settings.MaxFileSizeMB * 1024 * 1024) return false;
        var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
        return _settings.AllowedImageExtensions.Contains(ext);
    }

    public bool IsValidDocument(IFormFile file)
    {
        if (file.Length > _settings.MaxFileSizeMB * 1024 * 1024) return false;
        var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
        return _settings.AllowedDocExtensions.Contains(ext);
    }

    private async Task<string> SaveFileAsync(IFormFile file, string subfolder)
    {
        var folder = Path.Combine(_env.WebRootPath, "uploads", subfolder);
        Directory.CreateDirectory(folder);
        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        var fullPath = Path.Combine(folder, fileName);
        await using var stream = new FileStream(fullPath, FileMode.Create);
        await file.CopyToAsync(stream);
        return $"/uploads/{subfolder}/{fileName}";
    }
}
