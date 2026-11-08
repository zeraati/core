using FastEndpoints.Security;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.DependencyInjection;

namespace Common;

public static partial class ServiceConfig
{
    const string Issuer = "Auth";
    const string Audience = "Auth.Api";

    public static IServiceCollection AddAuthConfig(this IServiceCollection services)
    {
        var key = nameof(Common) + "/jwt-private-key.pem";
        if (File.Exists(key))
        {
            services.Configure<JwtCreationOptions>(x =>
            {
                x.SigningKey = File.ReadAllText("Common/jwt-private-key.pem");
                x.SigningStyle = TokenSigningStyle.Asymmetric;
                x.SigningAlgorithm = SecurityAlgorithms.RsaSha256;
                x.Issuer = Issuer;
                x.Audience = Audience;
                x.KeyIsPemEncoded = true;
            });
        }

        key = nameof(Common) + "/jwt-public-key.pem";
        if (File.Exists(key))
        {
            services.Configure<JwtSigningOptions>(x =>
            {
                x.SigningKey = File.ReadAllText("Common/jwt-public-key.pem");
                x.KeyIsPemEncoded = true;
                x.SigningStyle = TokenSigningStyle.Asymmetric;
            });
        }

        services.AddAuthenticationJwtBearer(x => { },
            y =>
            {
                y.TokenValidationParameters.ValidIssuer = Issuer;
                y.TokenValidationParameters.ValidAudience = Audience;
            }).AddAuthorization();

        return services;
    }
}