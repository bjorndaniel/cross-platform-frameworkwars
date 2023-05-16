namespace XkcdViewer.ViewModels;
public class MainPageViewModel : ObservableObject
{
    private readonly ApiService _apiService;
    private bool _isBusy;

    public MainPageViewModel(ApiService apiService) 
    {
        _apiService = apiService;
        LoadMoreCommand = new AsyncRelayCommand(async () => await LoadMoreAsync());
    }

    public ObservableCollection<XkcdComic> Comics { get; } = new();

    public ICommand LoadMoreCommand { get; }

    public bool IsBusy
    {
        get => _isBusy;
        set => SetProperty(ref _isBusy, value);
    }

    public Task InitializeAsync() => LoadMoreAsync(true);

    public async Task LoadMoreAsync(bool start = false)
    {
        IsBusy = true;
        foreach(var c in await _apiService.GetComics(start ? 0 : Comics.Last().num - 1))
        {
            Comics.Add(c);
        }
        IsBusy = false;
    }
}
