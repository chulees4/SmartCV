namespace SmartCV.Services.Interfaces;

public interface ICvBuilderService
{
    /// <summary>Render HTML từ template + dữ liệu candidate rồi xuất PDF bytes.</summary>
    Task<byte[]> BuildPdfAsync(int candidateId, int templateId, string primaryColor, string fontFamily);
}
