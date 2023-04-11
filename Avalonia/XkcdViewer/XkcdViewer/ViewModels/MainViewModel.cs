namespace XkcdViewer.ViewModels;

public class MainViewModel : ViewModelBase
{
    private bool _isLoading;
    private int _currentComic;

    public ObservableCollection<XkcdComic> Comics { get; } = new();


    public int CurrentComic
    {
        get => _currentComic;
        set => this.RaiseAndSetIfChanged(ref _currentComic, value);
    }

    public async Task LoadComicsAsync()
    {
        if (_isLoading)
        {
            return;
        }
        _isLoading = true;
        for (int i = 0; i < 10; i++)
        {
            if (CurrentComic == 0)
            {
                var comic = await App.HttpClient.GetFromJsonAsync<XkcdComic>("https://xkcd.com/info.0.json");
                Comics.Add(comic);
                CurrentComic = comic.num;
            }
            else
            {
                var comic = await App.HttpClient.GetFromJsonAsync<XkcdComic>($"https://xkcd.com/{CurrentComic - 1}/info.0.json");
                Comics.Add(comic);
                CurrentComic = comic.num;
            }
        }


        _isLoading = false;
    }
}
