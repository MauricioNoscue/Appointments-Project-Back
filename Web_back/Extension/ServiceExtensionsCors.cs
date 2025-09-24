namespace Web_back.Extension
{
    public static class ServiceExtensionsCors
    {
        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var origenesPermitidos = configuration.GetSection("OrigenesPermitidos").Get<string[]>();

            services.AddCors(opciones =>
            {
                opciones.AddPolicy("AllowFrontend", politica =>
                {
                    politica.WithOrigins(origenesPermitidos)  // 👈 Usa los que vienen de config
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();             
                });
            });

            return services;
        }
    }
}
