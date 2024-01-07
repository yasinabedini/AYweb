namespace AIPFramework.Queries;

/// <summary>
/// نتیجه یک کوئری را بازگشت می‌دهد
/// </summary>
/// <typeparam name="TData"></typeparam>
public sealed class QueryResult<TData>
{
    public TData? _data;
    public TData? Data
    {
        get
        {
            return _data;
        }
    }
}

