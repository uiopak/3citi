using _3citi.ViewModels;
using _3citi.Models;
using _3citi;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace _3citi.Views
{

    public partial class VariantsPage : ContentPage
    {
        VariantsViewModel viewModel;

        public VariantsPage()
        {
            InitializeComponent();
        }

        public VariantsPage(VariantsViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var variant = args.SelectedItem as Variant;
            if (variant == null)
                return;

            await Navigation.PushAsync(new VariantStopsPage(new VariantStopsViewModel(variant)));

            VariantsListView.SelectedItem = null;
        }
    }
}