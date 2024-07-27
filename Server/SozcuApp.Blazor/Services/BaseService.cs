namespace SozcuApp.Blazor.Services;

public class BaseService
{
    protected readonly HttpClient _httpClient;
    protected readonly string _serviceEndpoint;

    public BaseService(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient;
        _serviceEndpoint = $"{config.GetValue<string>("BackendUrl")}/api";
    }
}
