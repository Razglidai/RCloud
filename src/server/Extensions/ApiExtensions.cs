using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using RCloud.DataAccess.Repositories;
using RCloud.Services;
public static class ApiExtensions
{
    public static void AddApiCors(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddCors(
            options =>{
                options.AddDefaultPolicy(policy=>{
                policy.WithOrigins("http://localhost:5173");
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
            });
        });
    }

    public static void AddApiAuthentication(
        this IServiceCollection services, 
        IConfiguration configuration){
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.TokenValidationParameters = new ()
                    {
                        ValidateLifetime = false,
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey()
                    };
                });
    }

    public static void AddApiServices(
        this IServiceCollection services, 
        IConfiguration configuration
    )
    {
        services.AddTransient<UserRepository>();
        services.AddTransient<DataService>();
        services.AddTransient<UserService>();

    }
}
