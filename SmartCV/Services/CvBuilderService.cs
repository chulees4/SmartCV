using SmartCV.Services.Interfaces;

namespace SmartCV.Services;

// TODO Phase 6: Implement CV builder with PDF export (PuppeteerSharp)
public class CvBuilderService : ICvBuilderService
{
    public Task<byte[]> BuildPdfAsync(int candidateId, int templateId, string primaryColor, string fontFamily)
        => throw new NotImplementedException("CV Builder sẽ được triển khai ở Giai đoạn 6.");
}
