using System;
using System.Diagnostics;
using System.Threading.Tasks;

using _3citi.Helpers;
using _3citi.Models;
using _3citi.Views;

using Xamarin.Forms;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace _3citi.ViewModels
{
    public class RoutesViewModel : BaseViewModel
    {
        public ObservableCollection<RouteDay> RoutesCollection { get; set; }
        public Command LoadRouteDaysCommand { get; set; }

        public RoutesViewModel()
        {
            Title = "Linie";
            RoutesCollection = new ObservableCollection<RouteDay>();
            LoadRouteDaysCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }
        
        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                RoutesCollection.Clear();
                var routes = await RoutesDayDataStore.GetItemsAsync(true);
                foreach (RouteDay routeDay in routes)
                {
                    RoutesCollection.Add(routeDay);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await App.Current.MainPage.DisplayAlert("Błąd", "Coś poszło nie tak", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
