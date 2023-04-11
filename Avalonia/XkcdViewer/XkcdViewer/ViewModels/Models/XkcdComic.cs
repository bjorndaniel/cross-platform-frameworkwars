namespace XkcdViewer.ViewModels.Models;
public class XkcdComic
{
    public string month { get; set; }
    public int num { get; set; }
    public string link { get; set; }
    public string year { get; set; }
    public string news { get; set; }
    public string safe_title { get; set; }
    public string transcript { get; set; }
    public string alt { get; set; }
    public string img { get; set; }
    public string title { get; set; }
    public string day { get; set; }
    public string DateDisplay => $"{year}-{month.PadLeft(2, '0')}-{day.PadLeft(2, '0')} ({num})";
    public Task<Bitmap> Image => GetImageAsync();
    private async Task<Bitmap> GetImageAsync()
    {
        var response = await App.HttpClient.GetByteArrayAsync(img);
        var stream = new MemoryStream(response);
        return new Bitmap(stream);
    }
}