using Application.Services.Abstraction;
using Application.Services.Implementation;
using Domain.Repositories;
using Infastructre;
using Infastructre.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<AppDbContext>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, JwtAuthService>();

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("securitykeysecuritykeysecuritykeysecuritykeysecuritykeysecuritykeysecuritykeysecuritykey"))
        };

        options.Events = new JwtBearerEvents()
        {
            OnMessageReceived = context =>
            {
                context.Token = context.Request.Cookies["myToken"];
                return Task.CompletedTask;
            },
            OnChallenge = async context =>
            {
                if (context.Handled) return;

                // Пытаемся обновить токен с помощью refresh‑токена из cookie
                var refreshToken = context.Request.Cookies["refresh_token"];
                if (string.IsNullOrEmpty(refreshToken))
                {
                    context.HandleResponse();
                    context.Response.Redirect("/Account/Login");
                    return;
                }

                var dbContext = context.HttpContext.RequestServices.GetRequiredService<AppDbContext>();
                var jwtService = context.HttpContext.RequestServices.GetRequiredService<IAuthService>();

                var storedToken = await dbContext.RefreshTokens
                    .Include(rt => rt.User)
                    .FirstOrDefaultAsync(rt => rt.Token == refreshToken && !rt.IsRevoked && rt.ExpiresAt > DateTime.UtcNow);

                if (storedToken == null)
                {
                    context.HandleResponse();
                    context.Response.Redirect("/Account/Login");
                    return;
                }

                var newAccessToken = jwtService.GenerateAccessToken(storedToken.User);

                context.Response.Cookies.Append("access_token", newAccessToken, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTime.UtcNow.AddMinutes(jwtSettings.GetValue<int>("AccessTokenExpirationMinutes", 15))
                });

                // Заменяем токен в контексте аутентификации
                context.Token = newAccessToken;
                context.HandleResponse();

                context.Response.Redirect(context.Request.Path + context.Request.QueryString);
            }
        };
    });
builder.Services.AddAuthorization(options =>
    options.AddPolicy("NotForOlegs", builder =>
        builder.RequireAssertion(context =>
            context.User.FindFirst(ClaimTypes.Name)?.Value != "Олег")));

var app = builder.Build();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

Console.WriteLine(DateTime.Now);

app.Run();
