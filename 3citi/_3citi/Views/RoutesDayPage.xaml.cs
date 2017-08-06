using System;
using System.Collections.Generic;
using System.Linq;
using _3citi.ViewModels;
using _3citi.Models;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace _3citi.Views
{
	public partial class RoutesDayPage : ContentPage
	{
        RoutesDayViewModel viewModel;

        public RoutesDayPage()
        {
            InitializeComponent();
        }

        public RoutesDayPage(RoutesDayViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var route = args.SelectedItem as Route;
            if (route == null)
                return;

            await Navigation.PushAsync(new DirectionsPage(new DirectionViewModel(route)));

            RoutesListView.SelectedItem = null;
        }

        private void RoutesdaySearchBarName_TextChanged(object sender, TextChangedEventArgs e)
        {
            var keyworld = RoutesDaySearchBarName.Text;
            viewModel.SearchCommandExecute(keyworld.ToString());
        }
    }
}