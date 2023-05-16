namespace XkcdViewer;

public partial class MainPage : ContentPage
{
	private MainPageViewModel _vm;

	public MainPage(MainPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = _vm = vm;
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await _vm.InitializeAsync();
	}
}

