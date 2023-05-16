namespace XkcdViewer.Views;

public partial class XkcdView : ContentView
{
	public XkcdView()
	{
		InitializeComponent();
	}

	public static readonly BindableProperty ComicProperty = BindableProperty.Create(
		nameof(Comic), typeof(XkcdComic), typeof(XkcdView), null);

	public XkcdComic Comic { get; set; }
}