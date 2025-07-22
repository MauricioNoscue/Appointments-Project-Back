using Utilities_Back.Mapster;
using Mapster;
using Web_back.Extension;
using Microsoft.Extensions.Configuration;
var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// servicios y data
builder.Services.AddProjectServices();


// Configuración de base de datos
builder.Services.AddDatabaseConfiguration(configuration);


// AutoMapper
MapsterConfig.RegisterMappings();


// JWT auht2.0
builder.Services.AddJwtAndGoogleAuthentication(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
