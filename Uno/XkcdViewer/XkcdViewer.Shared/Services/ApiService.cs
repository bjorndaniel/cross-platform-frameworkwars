using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace XkcdViewer;
public class ApiService
{
    public static async Task<List<XkcdComic>> GetComicsAsync(int currentComic = 0)
    {
        try
        {
            var result = new List<XkcdComic>();
            for (int i = 0; i < 10; i++)
            {
                var comic = await App.HttpClient.GetFromJsonAsync<XkcdComic>($"https://xkcd.com{(currentComic == 0 ? "" : $"/{currentComic}")}/info.0.json");
                result.Add(comic);
                currentComic = comic.Num - 1;
            }
            return result;
        }
        catch (System.Exception e)
        {

            throw;
        }
    }
}