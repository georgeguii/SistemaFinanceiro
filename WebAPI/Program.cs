using Microsoft.EntityFrameworkCore;

using Infra.Context;
using Entities.Entitites;
using Domain.Interfaces.Generics;
using Infra.Repositories.Generics;
using Domain.Interfaces.ICategory;
using Infra.Repositories;
using Domain.Interfaces.IExpense;
using Domain.Interfaces.IFinancialSystem;
using Domain.Interfaces.IUserFinancialSystem;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<ContextBase>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<ContextBase>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ContextBase>();

builder.Services.AddSingleton(typeof(InterfaceGeneric<>), typeof(RepositoryGenerics<>));
builder.Services.AddSingleton<InterfaceCategory, CategoryRepository>();
builder.Services.AddSingleton<InterfaceExpense, ExpenseRepository>();
builder.Services.AddSingleton<InterfaceFinancialSystem, FinancialSystemRepository>();
builder.Services.AddSingleton<InterfaceUserFinancialSystem, UserFinancialSystemRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
