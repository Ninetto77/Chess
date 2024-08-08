using ChessAPI.Models.DB;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); //������ ������������


builder.Services.AddDbContext<ChessDBContext>(
	options => options.UseSqlServer("DefaultConnection"));

var app = builder.Build();
//builder.Services.AddTransient<IAllGamesRepository, GamesRepository>();

app.MapControllers(); //����� ���������� ������������� ������������ �� ������ ���������


app.MapGet("/", () => "Hello World!");

app.Run();
