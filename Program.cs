using System.Text;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using wms.Contracts.Authentication;
using wms.Contracts.Authentication.Login;
using wms.Contracts.Authentication.Register;
using wms.Contracts.Package;
using wms.Contracts.Warehouse;
using wms.Entites;
using wms.ErrorHandling;
using wms.Interfaces.Repositories;
using wms.Interfaces.Services;
using wms.Persistance;
using wms.Repositories;
using wms.Services;
using wms.Validation.Authentication.Login;
using wms.Validation.Package;
using wms.Validation.User;
using wms.Validation.Warehouse;

var jwtSettings = new JwtSettings();

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.Bind(JwtSettings.SectionName, jwtSettings);

// TODO: Handle database connection errors
builder.Services.AddDbContext<PersistanceContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ProblemDetailsFactory, WmsProblemDetailsFactory>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IWarehouseRepository, WarehouseRepository>();
builder.Services.AddScoped<IPackageRepository, PackageRepository>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IWarehouseService, WarehouseService>();
builder.Services.AddScoped<IPackageService, PackageService>();
builder.Services.AddSingleton(Options.Create(jwtSettings));
// TODO: Find a better way to do this DI
builder.Services.AddScoped<IValidator<RegisterRequest>, RegisterRequestValidator>();
builder.Services.AddScoped<IValidator<LoginRequest>, LoginRequestValidator>();
builder.Services.AddScoped<IValidator<AddWarehouseRequest>, AddWarehouseRequestValidator>();
builder.Services.AddScoped<IValidator<AddPackageRequest>, AddPackageRequestValidator>();

builder.Services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(
        options => options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings.Issuer, 
            ValidAudience = jwtSettings.Audience, 
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings.Secret)
            )
        }
    );

var app = builder.Build();

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
