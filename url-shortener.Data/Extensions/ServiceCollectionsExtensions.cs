using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using url_shortener.Data.Contexts.Default;
using url_shortener.Data.Settings;

namespace url_shortener.Data.Extensions;
public static class ServiceCollectionsExtensions
{
    public static IServiceCollection ConfigureEfContexts(this IServiceCollection services, IConfiguration configuration)
    {
        var settings = configuration.GetSection(DefaultDatabaseSettings.SectionName).Get<DefaultDatabaseSettings>();

        var connectionString = configuration.GetConnectionString(settings.ConnectionStringName);

        services.AddDbContext<DefaultDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        return services;
    }
}
