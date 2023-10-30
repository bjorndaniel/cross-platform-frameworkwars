using Tizen.Applications;
using Uno.UI.Runtime.Skia;

namespace XkcdViewer.Skia.Tizen
{
	public sealed class Program
	{
		static void Main(string[] args)
		{
			var host = new TizenHost(() => new XkcdViewer.App());
			host.Run();
		}
	}
}
