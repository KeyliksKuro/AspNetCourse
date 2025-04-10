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
            }
        };
    });
builder.Services.AddAuthorization(options =>
    options.AddPolicy("NotForOlegs", builder =>
        builder.RequireAssertion(context =>
            context.User.FindFirst(ClaimTypes.Name)?.Value != "Юыху")));

var app = builder.Build();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

Console.WriteLine(DateTime.Now);

app.Run();
