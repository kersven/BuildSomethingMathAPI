using Microsoft.EntityFrameworkCore;
using MathDb;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<MathDbContext>(options => options.UseSqlServer("Server=sqlserver,1433;Database=mathdb;User Id=sa;Password=NotVeryStrong@Passw0rd;"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
