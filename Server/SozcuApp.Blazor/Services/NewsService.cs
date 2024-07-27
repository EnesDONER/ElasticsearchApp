using Core.Application.Requests;
using Core.Persistence.Paging;
using Newtonsoft.Json.Linq;
using SozcuApp.Blazor.Models;

namespace SozcuApp.Blazor.Services;

public class NewsService : BaseService
{
    public NewsService(HttpClient httpClient, IConfiguration config) : base(httpClient, config)
    {
    }

    public async Task<Paginate<NewsView>> GetListNews(int pageIndex, int pageSize)
    {
        var requestUri = $"{_serviceEndpoint}/News?PageIndex={pageIndex}&PageSize={pageSize}";
        return await _httpClient.GetFromJsonAsync<Paginate<NewsView>>(requestUri);
    }

    public async Task<Paginate<NewsView>> GetListSearchNews(string searchQuery, int pageIndex, int pageSize)
    {
        var requestUri = $"{_serviceEndpoint}/News/{searchQuery}?PageIndex={pageIndex}&PageSize={pageSize}";
        return await _httpClient.GetFromJsonAsync<Paginate<NewsView>>(requestUri);
    }
}

