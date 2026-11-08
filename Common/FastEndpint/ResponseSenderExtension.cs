using Common;
using Microsoft.AspNetCore.Http;

namespace FastEndpoints;

public static class ResponseSenderExtension
{
    public static Task Success<T>(this IResponseSender sender, T data, string? message, CancellationToken cancellation)
    {
        var context = sender.HttpContext;
        var response = Response<T>.Ok(data, message);
        return context.Response.SendOkAsync(response, cancellation: cancellation);
    }

    public static Task Success(this IResponseSender sender, string? message, CancellationToken cancellation)
    {
        var context = sender.HttpContext;
        var response = Response.Ok(message);
        return context.Response.SendOkAsync(response, cancellation: cancellation);
    }

    public static Task Fail(this IResponseSender sender, string message, IReadOnlyList<ApiError>? errors, CancellationToken cancellation)
    {
        var context = sender.HttpContext;
        var response = Response.Fail(message, errors);
        return context.Response.SendAsync(response, 400, cancellation: cancellation);
    }
}

public static class HttpResponseExtension
{
    public static Task<Void> Failed(this HttpResponse response, string message, IReadOnlyList<ApiError>? errors, CancellationToken cancellation)
    {
        var result = Response.Fail(message, errors);
        return response.SendAsync(result,StatusCodes.Status400BadRequest,cancellation: cancellation);
    }
}