namespace SmartCV.Services.Interfaces;

public interface IFileService
{
    Task<string> SaveImageAsync(IFormFile file, string subfolder);
    Task<string> SaveDocumentAsync(IFormFile file, string subfolder);
    void DeleteFile(string relativePath);
    bool IsValidImage(IFormFile file);
    bool IsValidDocument(IFormFile file);
}
