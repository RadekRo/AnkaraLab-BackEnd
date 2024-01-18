using AnkaraLab_BackEnd.WebAPI.Infrastructure;
using AnkaraLab_BackEnd.WebAPI.Infrastructure.Implementations;
using AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using FluentValidation;
using AnkaraLab_BackEnd.WebAPI.Domain;
using Microsoft.Identity.Client;
using FluentValidation.AspNetCore;
using AnkaraLab_BackEnd.WebAPI.DTOs;
using AnkaraLab_BackEnd.WebAPI.DTOs.Validators;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace AnkaraLab_BackEnd.WebAPI;

public class Program
{
    public static IConfiguration Configuration { get; }

    [Obsolete]
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);
        
        // Add services to the container.
        builder.Services.AddDbContext<AnkaraLabDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("AnkaraDb"));
            options.EnableSensitiveDataLogging(builder.Environment.IsDevelopment());
        });

        var authenticationSettings = new AuthenticationSettings();
        var Configuration = builder.Configuration;
        Configuration.GetSection("Authentication").Bind(authenticationSettings);
        builder.Services.AddSingleton(authenticationSettings);
        builder.Services.AddAuthentication(option =>
        {
            option.DefaultAuthenticateScheme = "Bearer";
            option.DefaultScheme = "Bearer";
            option.DefaultChallengeScheme = "Bearer";
        }).AddJwtBearer(cfg =>
        {
            cfg.RequireHttpsMetadata = false;
            cfg.SaveToken = true;
            cfg.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidIssuer = authenticationSettings.JwtIssuer,
                ValidAudience = authenticationSettings.JwtIssuer,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),
            };
        });

        builder.Services.AddControllers().AddFluentValidation();
        builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
        builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
        builder.Services.AddScoped<IFaqRepository, FaqRepository>();
        builder.Services.AddScoped<IBasketRepository, BasketRepository>();
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<IClientRepository, ClientRepository>();
        builder.Services.AddScoped<IPasswordHasher<Client>, PasswordHasher<Client>>();
        builder.Services.AddScoped<IValidator<ClientForRegistrationDto>, RegisterClientDtoValidator>();
        builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
        

        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(policyBuilder =>
            {
                policyBuilder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
            // WithOrigins("http://localhost:5173")
        });
  
        builder.Services.AddControllers(configure =>
        {
            configure.CacheProfiles.Add("Any-7200",
                new CacheProfile
                {
                    Location = ResponseCacheLocation.Any,
                    Duration = 7200
                });
        })
            .AddNewtonsoftJson(options =>
        {
            // required to prevent "Self referencing loop detected" error
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        });
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        var app = builder.Build();

        // Configure the HTTP request pipeline. 
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthentication();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.UseCors();

        app.MapControllers();

        app.Run();
    }
}