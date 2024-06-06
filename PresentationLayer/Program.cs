using System.Text;
using BusinessLogicLayer;
using codeBattleService.BusinessLogicLayer.Interfaces;
using codeBattleService.BusinessLogicLayer.Services;
using DataAccessLayer.EF;
using DataAccessLayer.Interfaces; // Add this line
using DataAccessLayer.Ropositories;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer; // Add this line
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Npgsql;
using SecretStore.Extensions;


var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddDbContext<CodeBattleDBContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUserRepository, UserRepository>(); // Add this line
builder.Services.AddServices();
builder.Services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtOptions:SecretKey"]))
        };
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                context.Token = context.Request.Cookies["net-Token"];
                return Task.CompletedTask;
            }
        };

    });
builder.Services.AddAuthorization();


var app = builder.Build();

app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.Always

});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthentication();
app.UseHttpsRedirection();


var fileServerOptions = new FileServerOptions
{
    RequestPath = "",
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "../dist")),
    EnableDefaultFiles = true,
    EnableDirectoryBrowsing = false
};

app.UseFileServer(fileServerOptions);

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();