using _3citi.ViewModels;
using _3citi.Models;
using _3citi;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace _3citi.Views
{

    public partial class DirectionsPage : ContentPage
    {
        DirectionViewModel viewModel;

        public DirectionsPage()
        {
            InitializeComponent();
        }

        public DirectionsPage(DirectionViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var direction = args.SelectedItem as Direction;
            if (direction == null)
                return;

            await Navigation.PushAsync(new VariantsPage(new VariantsViewModel(direction)));

            StopTimesListView.SelectedItem = null;
        }        
    }
}