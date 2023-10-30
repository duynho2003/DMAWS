using Lab05WebAPI.DB_Helper;
using Lab05WebAPI.Repository;
using Lab05WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);
//Connect to DB
builder.Services.AddDbContext<DatabaseContext>();
//DI
builder.Services.AddScoped<IUserRepository, UserServices>();
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
