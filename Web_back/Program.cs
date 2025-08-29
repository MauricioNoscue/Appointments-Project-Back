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


//Cors
builder.Services.AddCorsConfiguration(configuration);
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


//// Archivos estáticos
//app.UseStaticFiles();

//// Swagger
//app.UseSwagger();
//app.UseSwaggerUI(c =>
//{
//    c.SwaggerEndpoint("/swagger/v1/swagger.json", "citas API v1");
//    c.RoutePrefix = "swagger";
//});


app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();



//< environmentVariables >

//            < environmentVariable name = "Cloudinary:CloudName" value = "djj163sc9" />
//            < environmentVariable name = "Cloudinary:ApiKey" value = "856391536481728" />
//            < environmentVariable name = "Cloudinary:ApiSecret" value = "hL1KKYppl_EENHvX_ZKKONwHdm8" />
//            < environmentVariable name = "Jwt:Key" value = "1226D984-7C6D-4846-A37F-F73467D2B64A" />


//            < environmentVariable name = "ConnectionStrings:DefaultConnection" value = "Server=localhost,14340;Database=DbPortalAgro;User Id=sa;password=Admin123;TrustServerCertificate=true" />
//            < environmentVariable name = "CONFIG_EMAIL:EMAIL" value = "portalagrocomercialhuila@gmail.com" />
//            < environmentVariable name = "CONFIG_EMAIL:PASSWORD" value = "llyn shva zobe zzhs" />
//            < environmentVariable name = "CONFIG_EMAIL:PORT" value = "587" />
//            < environmentVariable name = "CONFIG_EMAIL:HOST" value = "smtp.gmail.com" />
//          </ environmentVariables >


