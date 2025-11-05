using Utilities_Back.Mapster;
using Mapster;
using Web_back.Extension;
using Microsoft.Extensions.Configuration;
using Business_Back.Implements.Socket;
using Business_Back.Interface.Socket;
using Web_back.Hub;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// servicios y data
builder.Services.AddProjectServices();

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();
// Configuraci�n de base de datos
builder.Services.AddDatabaseConfiguration(configuration);


//Cors
builder.Services.AddCorsConfiguration(configuration);
// AutoMapper
MapsterConfig.RegisterMappings();




// (ES): SignalR
builder.Services.AddSignalR();

// (ES): Cache distribuida (Redis). Para dev puedes usar MemoryDistributedCache.
// (ES): Cache distribuida con Redis (usa MemoryCache como respaldo si falla)
builder.Services.AddStackExchangeRedisCache(options =>
{
    var redisConnection = builder.Configuration.GetConnectionString("Redis");

    // Si no hay conexión definida, usa memoria local para no romper la app
    if (string.IsNullOrWhiteSpace(redisConnection))
    {
        Console.WriteLine("⚠️ No se encontró cadena de conexión Redis. Usando MemoryCache temporalmente.");
        builder.Services.AddDistributedMemoryCache(); // respaldo
        return;
    }

    options.Configuration = redisConnection;
    Console.WriteLine($"✅ Redis configurado correctamente: {redisConnection}");
});



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

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<Entity_Back.Context.ApplicationDbContext>();

    try
    {
        dbContext.Database.Migrate();
        Console.WriteLine("✅ Base de datos creada o actualizada correctamente.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Error al inicializar la base de datos: {ex.Message}");
    }
}
app.Run();