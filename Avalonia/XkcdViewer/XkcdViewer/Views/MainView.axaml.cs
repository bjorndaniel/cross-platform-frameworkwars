namespace XkcdViewer.Views;
public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }
    public async void OnLoaded(object sender, RoutedEventArgs e)
    {
        await ((MainViewModel)DataContext).LoadComicsAsync();
    }

    public async void OnElementPrepared(object sender, ItemsRepeaterElementPreparedEventArgs e)
    {
        var item = e.Element.DataContext as XkcdComic;
        var vm = DataContext as MainViewModel;
        if (item != null && vm != null)
        {
            if (item.num == vm.CurrentComic)
            {
                await vm.LoadComicsAsync();
            }
        }
    }
}