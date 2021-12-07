using System.Text;
using Lishl.Authentication.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Lishl.Authentication
{
    public static class JwtAuthenticationDependencyInjection
    {
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, ConfigurationManager configuration)
        {
            var tokenConfiguration = new TokenConfiguration(configuration);
            var authPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build();

            services.AddAuthentication(o =>
            {
                o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters.ValidateIssuer = true;
                o.TokenValidationParameters.ValidIssuer = tokenConfiguration.Issuer;
                o.TokenValidationParameters.ValidateIssuerSigningKey = true;
                o.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfiguration.Secret));
                o.TokenValidationParameters.ValidateAudience = false;
                o.TokenValidationParameters.ValidateLifetime = true;
            });

            services.AddAuthorization(auth => auth.AddPolicy("Baerer", authPolicy));
            
            return services;
        }
    }
}