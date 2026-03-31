namespace SmartCV.Services.Interfaces;

public interface IImportExportService
{
    Task<byte[]> ExportCandidatesToExcelAsync();
    Task<byte[]> ExportCompaniesToExcelAsync();
    Task<(int Imported, int Failed)> ImportCandidatesFromExcelAsync(IFormFile file);
    Task<(int Imported, int Failed)> ImportCompaniesFromExcelAsync(IFormFile file);
}
