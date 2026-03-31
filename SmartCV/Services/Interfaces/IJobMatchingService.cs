namespace SmartCV.Services.Interfaces;

public interface IJobMatchingService
{
    /// <summary>
    /// Tính Matching Score giữa Candidate và Job.
    /// Ngành 30% | Kỹ năng 30% | Địa điểm 15% | Kinh nghiệm 15% | Lương 10%
    /// </summary>
    double CalculateScore(int candidateId, int jobId);

    /// <summary>Trả về top N job phù hợp nhất cho candidate.</summary>
    Task<List<int>> GetTopMatchingJobIdsAsync(int candidateId, int topN = 10);
}
