using _3citi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using _3citi.Helpers;


namespace _3citi.ViewModels
{
    public class StopDetailViewModel : BaseViewModel
    {
        public ObservableCollection<Delay> DelaysCollection { get; set; }
        public ObservableCollection<Route> RoutesCollection { get; set; }
        public Stop Stop { get; set; }
        public Command LoadDelays;


        public StopDetailViewModel(Stop stop = null)
        {
            DelaysCollection = new ObservableCollection<Delay>();
            RoutesCollection = new ObservableCollection<Route>();

            Title = stop.StopDesc;
            Stop = stop;
            LoadDelays = new Command(async () => await ExecuteLoadDelaysCommand());
            LoadDelays.Execute(null);

        }
        async Task ExecuteLoadDelaysCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                RoutesCollection.Clear();
                var routes = await RouteDataStore.GetItemsAsync(true);
                foreach (Route route in routes)
                {
                    RoutesCollection.Add(route);
                }

                DelaysCollection.Clear();
                var delays = await StopDelaysDataStore.GetItemsAsync(int.Parse(Stop.StopId), true);
                foreach (Delay delay in delays)
                {
                    DelaysCollection.Add(delay);
                }
                
                foreach (Delay delay in DelaysCollection)
                {
                    foreach (Route route in RoutesCollection)
                    {
                        if (int.Parse(delay.RouteId) == route.RouteId)
                        {
                            delay.RouteLongName = route.RouteLongName;
                            delay.RouteShortName = route.RouteShortName;
                        }
                    }
                }
                if (DelaysCollection.Count == 0)
                {
                    await App.Current.MainPage.DisplayAlert("", "Brak  przyjazdów w najbliższym czasie", "OK");
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