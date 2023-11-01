using Lab06WebAPI.DB_Helper;
using Lab06WebAPI.Repository;
using Lab06WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);
//khai bao ket noi
builder.Services.AddDbContext<DatabaseContext>();
//khai bao DI
builder.Services.AddScoped<IMovieRepository, MovieServices>();
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
