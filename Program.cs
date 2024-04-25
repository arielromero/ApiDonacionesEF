using apiNetDonacionesEF.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<DonacionesContext>(p => p.UseInMemoryDatabase("DonacionesDB"));
builder.Services.AddSqlServer<DonacionesContext>(builder.Configuration.GetConnectionString("cnDonaciones"));
Console.WriteLine(builder.Configuration.GetConnectionString("cnDonaciones"));
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
app.MapGet("/dbConexion", async ([FromServices] DonacionesContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de dato en memoria: " + dbContext.Database.IsInMemory());
});
app.Run();
