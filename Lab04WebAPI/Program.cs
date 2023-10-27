using Lab04WebAPI.DB_Helper;
using Lab04WebAPI.Repository;
using Lab04WebAPI.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DatabaseContext>(options=>options.UseSqlServer(
    builder.Configuration.GetConnectionString("ConnectDB")));
//khai bao DI
builder.Services.AddScoped<ICustomerRepository, CustomerServices>();
builder.Services.AddScoped<IOrderRepository, OrderServices>();

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
