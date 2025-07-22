using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SCI.Domain._SharedKernel.Abstractions;
using url_shortener.Data.Contexts.Default;
using url_shortener.Data.Contexts.Default.Repositories;
using url_shortener.Data.Settings;
using url_shortener.Domain._SharedKernel;
using url_shortener.Domain.Entities;

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
        })
            .AddScoped<IUnitOfWork<DefaultDbContext>, UnitOfWork<DefaultDbContext>>();

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services) => services.AddScoped<IRepository<Link>, LinkRepository>();
}
