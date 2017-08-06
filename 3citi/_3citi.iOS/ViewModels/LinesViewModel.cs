using _3citi.Helpers;
using _3citi.Models;
using Xamarin.Forms;

namespace _3citi.ViewModels
{
    public interface LinesViewModel
    {
        ObservableRangeCollection<Item> Items { get; set; }
        ObservableRangeCollection<Item> Items { get; set; }
        Command LoadItemsCommand { get; set; }
        Command LoadItemsCommand { get; set; }
    }
}