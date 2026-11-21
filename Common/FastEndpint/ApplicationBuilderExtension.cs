using Common.Middleware;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Builder;

namespace FastEndpoints;

public static class ApplicationBuilderExtension
{
    public static IApplicationBuilder UseApplicationPipeline(this IApplicationBuilder app)
    {
        app.UseMiddleware<TraceIdMiddleware>();
        app.UseGlobalExceptionHandler();
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseFastEndpoints();
        app.UseSwaggerGen();
        return app;
    }
}

