using Core.Persistence.Paging;

namespace Core.Persistence.Repositories;

public interface IAsyncRepository <TEntity, TEntityId> where TEntity : Entity<TEntityId>
{
    Task<Paginate<TEntity>> GetListAsync(
        string indexName,
        int index = 0,
        int size = 10,
        CancellationToken cancellationToken=default);

    Task<Paginate<TEntity>> GetListSearchAsync(
        string indexName,
        string fieldName,
        string value,
        int index = 0,
        int size = 10,
        CancellationToken cancellationToken = default);
}
