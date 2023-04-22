using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;


using WebAPI.Token;
using Infra.Context;
using Entities.Entitites;
using Domain.Interfaces.Generics;
using Infra.Repositories.Generics;
using Domain.Interfaces.ICategory;
using Infra.Repositories;
using Domain.Interfaces.IExpense;
using Domain.Services;
using Domain.Interfaces.IServices;
using Domain.Interfaces.IFinancialSystem;
using Domain.Interfaces.IUserFinancialSystem;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<ContextBase>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
    // UseFullTypeNameInSchemaIds replacement for .NET Core
    c.CustomSchemaIds(x => x.FullName);
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"'Bearer' [space] seu token",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
         {
            new OpenApiSecurityScheme
            {
               Reference = new OpenApiReference
               {
                  Type = ReferenceType.SecurityScheme,
                  Id = "Bearer"
               },
               Scheme = "oauth2",
               Name = "Bearer",
               In= ParameterLocation.Header
            },
            new List<string> ()
         }
    });
});

//builder.Services.AddDbContext<ContextBase>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ContextBase>();

builder.Services.AddSingleton(typeof(InterfaceGeneric<>), typeof(RepositoryGenerics<>));

builder.Services.AddSingleton<InterfaceExpense, ExpenseRepository>();
builder.Services.AddSingleton<InterfaceCategory, CategoryRepository>();
builder.Services.AddSingleton<InterfaceFinancialSystem, FinancialSystemRepository>();
builder.Services.AddSingleton<InterfaceUserFinancialSystem, UserFinancialSystemRepository>();

builder.Services.AddSingleton<IExpenseService, ExpenseService>();
builder.Services.AddSingleton<ICategoryService, CategoryService>();
builder.Services.AddSingleton<IFinancialSystemService, FinancialSystemService>();
builder.Services.AddSingleton<IUserFinancialSystemService, UserFinancialSystemService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(option =>
    {
        option.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = "Teste.Securiry.Bearer",
            ValidAudience = "Teste.Securiry.Bearer",
            IssuerSigningKey = JwtSecurityKey.Create("Secret_Key-12345678")
        };

        option.Events = new JwtBearerEvents()
        {
            OnAuthenticationFailed = context =>
            {
                Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                return Task.CompletedTask;
            },
            OnTokenValidated = context =>
            {
                Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                return Task.CompletedTask;
            }
        };
    });


var app = builder.Build();

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
