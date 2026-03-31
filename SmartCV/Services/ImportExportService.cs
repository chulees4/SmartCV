using SmartCV.Services.Interfaces;

namespace SmartCV.Services;

// TODO Phase 7: Implement with ClosedXML
public class ImportExportService : IImportExportService
{
    public Task<byte[]> ExportCandidatesToExcelAsync() => throw new NotImplementedException();
    public Task<byte[]> ExportCompaniesToExcelAsync() => throw new NotImplementedException();
    public Task<(int Imported, int Failed)> ImportCandidatesFromExcelAsync(IFormFile file) => throw new NotImplementedException();
    public Task<(int Imported, int Failed)> ImportCompaniesFromExcelAsync(IFormFile file) => throw new NotImplementedException();
}
