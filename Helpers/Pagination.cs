namespace Treasures.Common.Helpers; 

public class Pagination {
    private const int MaxPageSize = 36;
    public int Page { get; set; } = 1;
    private int _pageSize = 20;

    public int PageSize {
        get => _pageSize;
        set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
    }
}