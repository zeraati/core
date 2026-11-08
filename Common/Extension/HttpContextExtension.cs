using Microsoft.AspNetCore.Http;

namespace Common.Extension;

public static class HttpContextExtension
{
    public static string? Token(this HttpContext context)
        => context.Request.Headers.Authorization.ToString();

    public static string? ApiKey(this HttpContext context)
        => context.Request.Headers["x-api-key"].ToString();
}