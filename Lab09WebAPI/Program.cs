using Lab09WebAPI.Db_Helper;
using Lab09WebAPI.Repository;
using Lab09WebAPI.Service;

var builder = WebApplication.CreateBuilder(args);
//Goi ket noi
builder.Services.AddDbContext<DatabaseContext>();
//Khai bao DI
builder.Services.AddScoped<IUserRepository, UserService>();
builder.Services.AddScoped<IShipperRepository, ShipperService>();

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
