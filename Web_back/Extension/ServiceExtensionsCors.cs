namespace Web_back.Extension
{
    public static class ServiceExtensionsCors
    {
        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var OrigenesPermitidos = configuration.GetSection("OrigenesPermitidos").Get<string[]>();


            services.AddCors(opciones =>
            {
                opciones.AddDefaultPolicy(politica =>
                {
                    politica.WithOrigins(OrigenesPermitidos).AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });
            return services;
        }
    }
}
