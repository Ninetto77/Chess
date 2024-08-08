using ChessAPI.Models.DB;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); //работа контроллеров


builder.Services.AddDbContext<ChessDBContext>(
	options => options.UseSqlServer("DefaultConnection"));

var app = builder.Build();
//builder.Services.AddTransient<IAllGamesRepository, GamesRepository>();

app.MapControllers(); //Чтобы подключить маршрутизацию контроллеров на основе атрибутов


app.MapGet("/", () => "Hello World!");

app.Run();
