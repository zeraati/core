namespace Common;

public partial class Response
{
    public static Response Ok(string? message = null)
        => new() { Success = true, Message = message };

    public static Response Fail(string message, IReadOnlyList<ApiError>? errors = null)
        => new() { Success = false, Message = message, Errors = errors };
}

public partial class Response<T>
{
    public static Response<T> Ok(T data, string? message = null)
        => new() { Success = true, Data = data, Message = message};
}
