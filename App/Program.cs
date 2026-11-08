global using Common;
global using FastEndpoints;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;

using App;
using Common.HttpClient;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplicationService()
    .AddDbConfig<AppDbContext>(builder.Configuration);

var app = builder.Build();
app.UseApplicationPipeline();

app.Run();
