using System;

using _3citi.Models;
using _3citi.ViewModels;
using _3citi.Services;

using Xamarin.Forms;

namespace _3citi.Views
{
    public partial class RoutesPage : ContentPage
    {
        RoutesViewModel viewModel;

        public RoutesPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new RoutesViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var route = args.SelectedItem as RouteDay;
            if (route == null)
                return;

            await Navigation.PushAsync(new RoutesDayPage(new RoutesDayViewModel(route)));

            RoutesListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.RoutesCollection.Count == 0)
                viewModel.LoadRouteDaysCommand.Execute(null);
        }

    }
}

