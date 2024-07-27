using Core.Persistence.Repositories;
using SozcuApp.Domain.Entities;

namespace SozcuApp.Application.Services.Repositories;

public interface INewsRepository : IAsyncRepository<News,Guid> 
{
}
