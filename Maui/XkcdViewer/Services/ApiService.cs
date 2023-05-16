namespace XkcdViewer.Services;
public class ApiService
{
    private HttpClient _httpClient;

    public ApiService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();    
    }

    public async Task<IEnumerable<XkcdComic>> GetComics(int currentComic = 0)
    {
        var result = new List<XkcdComic>();
        for(int i = 0; i < 10; i++)
        {
            var comic = await _httpClient.GetFromJsonAsync<XkcdComic>($"https://xkcd.com{(currentComic == 0 ? "" : $"/{currentComic}")}/info.0.json");
            currentComic = comic.num - 1;
            result.Add(comic);
        }
        return result;
    }
}
