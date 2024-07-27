using Core.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using SozcuApp.Application.Services.Repositories;
using SozcuApp.Persistence.Repositories;
using Microsoft.Extensions.Configuration;

namespace SozcuApp.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        var elasticSearchSettings = configuration.GetSection("ElasticSearch").Get<ElasticSearchSettings>();
        services.AddSingleton(elasticSearchSettings);

        services.AddScoped<INewsRepository, NewsRepository>();

        return services;
    }
}
