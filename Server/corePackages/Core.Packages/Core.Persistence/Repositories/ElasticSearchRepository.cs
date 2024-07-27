using Core.Persistence.Paging;
using Elasticsearch.Net;
using Newtonsoft.Json.Linq;

namespace Core.Persistence.Repositories;

public class ElasticSearchRepository<TEntity,TEntityId> : IAsyncRepository<TEntity,TEntityId> where TEntity : Entity<TEntityId>
{
    private readonly ElasticLowLevelClient _client;

    public ElasticSearchRepository(ElasticSearchSettings settings)
    {
        var uri = settings.Uri;
        var connectionSettings = new ConnectionConfiguration(new Uri(uri));
        _client = new ElasticLowLevelClient(connectionSettings);
    }

    public async Task<Paginate<TEntity>> GetListAsync(string indexName, int index = 0, int size = 10, CancellationToken cancellationToken = default)
    {
        var searchQuery = new
        {
            from = index * size,
            query = new
            {
                match_all = new { }
            }
        };

        var response = await _client.SearchAsync<StringResponse>(indexName, PostData.Serializable(searchQuery));
        var results = JObject.Parse(response.Body);
        var hits = results["hits"]["hits"].ToObject<List<JObject>>();

        List<TEntity> items = new();
        foreach (var hit in hits)
        {
            items.Add(hit["_source"].ToObject<TEntity>());
        }

        var countResponse = await _client.CountAsync<StringResponse>(indexName, PostData.Serializable(new { query = new { match_all = new { } } }));
        var countResult = JObject.Parse(countResponse.Body);
        int totalCount = countResult["count"].ToObject<int>();

        var paginateResult = new Paginate<TEntity>
        {
            Items = items,
            Size = size,
            Index = index,
            Count = totalCount,
            Pages = (int)Math.Ceiling((double)totalCount / size)
        };

        return paginateResult;
    }

    public async Task<Paginate<TEntity>> GetListSearchAsync(string indexName, string fieldName, string value, int index = 0, int size = 10, CancellationToken cancellationToken=default)
    {
        var searchQuery = new
        {
            from = index * size,
            query = new
            {
                wildcard = new Dictionary<string, object>
            {
                { fieldName, new { value = $"*{value}*" } }
            }
            }
        };

        var response = await _client.SearchAsync<StringResponse>(indexName, PostData.Serializable(searchQuery));
        var results = JObject.Parse(response.Body);
        var hits = results["hits"]["hits"].ToObject<List<JObject>>();

        List<TEntity> items = new();
        foreach (var hit in hits)
        {
            items.Add(hit["_source"].ToObject<TEntity>());
        }

        var countQuery = new
        {
            query = new
            {
                wildcard = new Dictionary<string, object>
            {
                { fieldName, new { value = $"*{value}*" } }
            }
            }
        };

        var countResponse = await _client.CountAsync<StringResponse>(indexName, PostData.Serializable(countQuery));
        var countResult = JObject.Parse(countResponse.Body);
        int totalCount = countResult["count"].ToObject<int>();

        var paginateResult = new Paginate<TEntity>
        {
            Items = items,
            Size = size,
            Index = index,
            Count = totalCount,
            Pages = (int)Math.Ceiling((double)totalCount / size)
        };

        return paginateResult;
    }
}
