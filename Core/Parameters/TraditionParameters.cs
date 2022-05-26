namespace Core.Parameters;

public class TraditionParameters
{
    private const int MaxPageSize = 50;

    public int PageIndex { get; set; } = 1;
        
    private int _pageSize = 6;

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }

    public string Sort { get; set; }
    private string _search;
    private string _location;

    public string? Search
    {
        get => _search;
        set => _search = value.ToLower();
    }

    public string? Region
    {
        get => _location;
        set => _location = value.ToLower();
    }
}