using _3citi.ViewModels;
using _3citi;

using Xamarin.Forms;

using Xamarin.Forms.Xaml;
using _3citi.Models;

namespace _3citi.Views
{

    public partial class VariantStopsPage : ContentPage
    {
        VariantStopsViewModel viewModel;

        public VariantStopsPage()
        {
            InitializeComponent();
        }

        public VariantStopsPage(VariantStopsViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {

            var stop = args.SelectedItem as RouteStopTimes;
            if (stop == null)
                return;

            await Navigation.PushAsync(new VariantSelectedStopTimesPage(new VariantSelectedStopTimesViewModel(stop)));

            VariantStopsListView.SelectedItem = null;
        }

    }
}