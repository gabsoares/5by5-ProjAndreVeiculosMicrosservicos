using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using _5by5_ProjAndreVeiculosMicrosservicos.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<_5by5_ProjAndreVeiculosMicrosservicosContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("_5by5_ProjAndreVeiculosMicrosservicosContext") ?? throw new InvalidOperationException("Connection string '_5by5_ProjAndreVeiculosMicrosservicosContext' not found.")));

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
