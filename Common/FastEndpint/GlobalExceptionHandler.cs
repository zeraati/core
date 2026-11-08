using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace FastEndpoints;

public static class GlobalExceptionHandler
{
    public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app, bool useGenericReason = true)
    {
        app.UseExceptionHandler(errApp =>
        {
            errApp.Run(async ctx =>
            {
                var feature = ctx.Features.Get<IExceptionHandlerFeature>();
                if (feature is null) return;

                var exception = feature.Error;
                var logger = ctx.RequestServices.GetRequiredService<ILoggerFactory>().CreateLogger(nameof(GlobalExceptionHandler));
                logger.LogError(exception, "Unhandled exception at {Path}", ctx.Request.Path);
                ctx.Response.StatusCode = StatusCodes.Status500InternalServerError;

                var message = useGenericReason ? "An unexpected error has occurred." : exception.Message;
                var response = Response.Fail(message);
                await ctx.Response.WriteAsJsonAsync(response, cancellationToken: ctx.RequestAborted);
            });
        });

        return app;
    }
}


