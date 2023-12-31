using Lab04WebAPI.DB_Helper;
using Lab04WebAPI.Repository;
using Lab04WebAPI.Service;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
//khai bao ket noi
builder.Services.AddDbContext<DatabaseContext>(options=>options.UseSqlServer(
    builder.Configuration.GetConnectionString("ConnectDB")));
//khai bao DI
builder.Services.AddScoped<ICustomerRepository, CustomerServices>();
builder.Services.AddScoped<IOrderRepository, OrderServices>();
//Khai bao eager loading for .net 6.0
builder.Services.AddControllersWithViews().AddJsonOptions(
    options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Add services to the container.
builder.Services.AddControllers();
    //.AddJsonOptions(x =>x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

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
