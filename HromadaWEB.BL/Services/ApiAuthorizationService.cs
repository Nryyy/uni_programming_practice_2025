using Microsoft.JSInterop;

public class ApiAuthorizationService
{
    private readonly HttpClient _httpClient;
    private readonly IJSRuntime _jsRuntime;

    public ApiAuthorizationService(HttpClient httpClient, IJSRuntime jsRuntime)
    {
        _httpClient = httpClient;
        _jsRuntime = jsRuntime;
    }

    public async Task SetAuthorizationHeader()
    {
        var token = await GetTokenFromSessionStorage();

        if (!string.IsNullOrEmpty(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }
    }

    public void ClearAuthorizationHeader()
    {
        _httpClient.DefaultRequestHeaders.Authorization = null;
    }

    private async Task<string> GetTokenFromSessionStorage()
    {
        // Виклик функції через JavaScript
        var token = await _jsRuntime.InvokeAsync<string>("sessionStorageUtil.getItem", "jwtToken");
        return token;
    }
}
