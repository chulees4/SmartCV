namespace SmartCV.Helpers;

public class PaginationResult<T>
{
    public List<T> Items { get; set; } = [];
    public int TotalCount { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    public bool HasPrev => Page > 1;
    public bool HasNext => Page < TotalPages;
}

public static class PaginationHelper
{
    public static async Task<PaginationResult<T>> PaginateAsync<T>(
        IQueryable<T> query, int page, int pageSize)
    {
        page = Math.Max(1, page);
        pageSize = Math.Clamp(pageSize, 1, 100);
        var total = query.Count();
        var items = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        return await Task.FromResult(new PaginationResult<T>
        {
            Items = items,
            TotalCount = total,
            Page = page,
            PageSize = pageSize
        });
    }
}
