using SmartCV.Services.Interfaces;

namespace SmartCV.Services;

// TODO Phase 6: Implement full matching algorithm
// Ngành 30% | Kỹ năng 30% | Địa điểm 15% | Kinh nghiệm 15% | Lương 10%
public class JobMatchingService : IJobMatchingService
{
    public double CalculateScore(int candidateId, int jobId) => 0;
    public Task<List<int>> GetTopMatchingJobIdsAsync(int candidateId, int topN = 10) => Task.FromResult(new List<int>());
}
