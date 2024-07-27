using Core.Persistence.Repositories;
using SozcuApp.Application.Services.Repositories;
using SozcuApp.Domain.Entities;

namespace SozcuApp.Persistence.Repositories;

public class NewsRepository : ElasticSearchRepository<News, Guid>, INewsRepository
{
    public NewsRepository(ElasticSearchSettings settings) : base(settings)
    {
    }
}
