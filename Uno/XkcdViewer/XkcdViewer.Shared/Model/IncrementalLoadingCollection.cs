using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.UI.Xaml.Data;

namespace XkcdViewer.Model;
public class IncrementalLoadingCollection : ObservableCollection<XkcdComic>, ISupportIncrementalLoading, INotifyCollectionChanged
{
    public new event NotifyCollectionChangedEventHandler CollectionChanged;

    public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
    {
        return AsyncInfo.Run(async cancelToken =>
        {
            var next = 0;
            if (Items.Any())
            {
                next = Items.Min(_ => _.Num) - 1;
            }
            var comics = await ApiService.GetComicsAsync(next);
            comics.ForEach(Items.Add);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            return new LoadMoreItemsResult { Count = 10 };
        });
    }

    protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
    {
        base.OnCollectionChanged(e);
        CollectionChanged?.Invoke(this, e);
    }

    public bool HasMoreItems => true;
}