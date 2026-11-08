namespace Common;

public partial class Response
{
    public bool Success { get; protected set; }
    public string? Message { get; protected set; }
    public IReadOnlyList<ApiError>? Errors { get; protected set; }
}

public partial class Response<T>: Response
{
    public T? Data { get; private set; }
}

public sealed record ApiError(string Message,string? Field = null);