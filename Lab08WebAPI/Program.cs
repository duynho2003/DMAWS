using Lab08WebAPI.Models;
using Lab08WebAPI.Repository;
using Lab08WebAPI.Service;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
//khai bao ket noi
builder.Services.AddDbContext<DmawsdbContext>();
//khai bao DI
builder.Services.AddScoped<ICategoryRepository, CategoryService>();
builder.Services.AddScoped<IProductRepository, ProductService>();
//khai bao Eager loading .net 6
builder.Services.AddControllersWithViews().AddJsonOptions(
    options => options.JsonSerializerOptions.ReferenceHandler= ReferenceHandler.IgnoreCycles);
// Add services to the container.

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
