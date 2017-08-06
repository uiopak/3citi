using System;

using _3citi.Models;
using _3citi.ViewModels;
using _3citi.Services;

using Xamarin.Forms;

namespace _3citi.Views
{
    public partial class StopsPage : ContentPage
    {
        StopsViewModel viewModel;

        public StopsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new StopsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var stop = args.SelectedItem as Stop;
            if (stop == null)
                return;

            await Navigation.PushAsync(new StopDetailPage(new StopDetailViewModel(stop)));

            StopsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.StopsCollection.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        private void StopsSearchBarName_TextChanged(object sender, TextChangedEventArgs e)
        {
            var keyworld = StopsSearchBarName.Text;
            viewModel.SearchCommandExecute(keyworld.ToString());
        }
    }
}
