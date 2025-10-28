using Utilities_Back.Mapster;
using Mapster;
using Web_back.Extension;
using Microsoft.Extensions.Configuration;
using Business_Back.Implements.Socket;
using Business_Back.Interface.Socket;
using Web_back.Hub;
using Microsoft.AspNetCore.SignalR;
var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// servicios y data
builder.Services.AddProjectServices();


// Configuraci�n de base de datos
builder.Services.AddDatabaseConfiguration(configuration);


//Cors
builder.Services.AddCorsConfiguration(configuration);
// AutoMapper
MapsterConfig.RegisterMappings();




// (ES): SignalR
builder.Services.AddSignalR();

// (ES): Cache distribuida (Redis). Para dev puedes usar MemoryDistributedCache.
builder.Services.AddStackExchangeRedisCache(opt =>
{
    opt.Configuration = builder.Configuration.GetConnectionString("Redis"); // p. ej. "localhost:6379"
});
// <summary>
/// Configuración de fuentes de configuración en orden de prioridad.
/// </summary>
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

// (ES): DI
builder.Services.AddScoped<ISlotLockStore, RedisSlotLockStore>();
builder.Services.AddScoped<IAppointmentOrchestrator, AppointmentOrchestrator>();

builder.Services.AddScoped<IAppointmentNotifier, SignalRAppointmentNotifier>();

builder.Services.AddSingleton<IUserIdProvider, SubUserIdProvider>();

builder.Services.AddSignalR();

// JWT auht2.0
builder.Services.AddJwtAndGoogleAuthentication(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}


    app.UseSwagger();
    app.UseSwaggerUI();



//// Archivos est�ticos
//app.UseStaticFiles();

//// Swagger
//app.UseSwagger();
//app.UseSwaggerUI(c =>
//{
//    c.SwaggerEndpoint("/swagger/v1/swagger.json", "citas API v1");
//    c.RoutePrefix = "swagger";
//});


app.UseHttpsRedirection();
app.UseCors("AllowFrontend");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapHub<AppointmentHub>("/hubs/appointments");

app.Run();