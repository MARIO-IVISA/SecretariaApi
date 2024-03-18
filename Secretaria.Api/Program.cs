using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Secretaria.Api.Properties;
using Secretaria.Api.Settings;
using Secretaria.Application.Contracts;
using Secretaria.Application.Services;
using Secretaria.Domain.Contracts.Datas;
using Secretaria.Domain.Contracts.Services;
using Secretaria.Domain.Entities;
using Secretaria.Domain.Service;
using Secretaria.Infrastructure.Context;
using Secretaria.Infrastructure.Repositories;



var builder = WebApplication.CreateBuilder(args);

AppSettings.ConnectionStrings = builder.Configuration.GetSection("ConnectionStrings:SecretariaConnection").Value ?? string.Empty;
AppSettings.ApiCursos = builder.Configuration.GetSection("Api:Cursos").Value ?? string.Empty;
AppSettings.ApiUsuarios = builder.Configuration.GetSection("Api:Usuarios").Value ?? string.Empty;

string securityKey = builder.Configuration.GetSection("AppSettings:SecurityKey").Value ?? string.Empty;

builder.Services.AddApplicationInsightsTelemetry();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(securityKey)),
        ValidateAudience = false,
        ValidateIssuer = false,
        ClockSkew = TimeSpan.Zero
    };

});
builder.Services.AddAuthorization();
builder.Services.AddTransient<IMatriculaApplicationService, MatriculaApplicationService>();
builder.Services.AddTransient<IMatriculaDomainService, MatriculaDomainService>();
builder.Services.AddTransient<IMatriculaRepository, MatriculaRepository>();
builder.Services.AddHttpClient<IApiService, ApiService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
SwaggerSettings.AddSwaggerSetup(builder);
CorsSettings.AddCorsSetup(builder);

var app = builder.Build();

SwaggerSettings.UseSwaggerSetup(app);
CorsSettings.UseCorsSetup(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }