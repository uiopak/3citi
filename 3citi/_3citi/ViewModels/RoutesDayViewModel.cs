using System;
using System.Diagnostics;
using System.Threading.Tasks;

using _3citi.Helpers;
using _3citi.Models;
using _3citi.Views;

using Xamarin.Forms;
using System.Linq;
using System.Collections.ObjectModel;

namespace _3citi.ViewModels
{
    public class RoutesDayViewModel : BaseViewModel
    {
        public ObservableCollection<Route> RoutesCollection { get; set; }
        public ObservableCollection<Route> RoutesBackupCollection { get; set; }
        public RouteDay RouteDay;

        public RoutesDayViewModel(RouteDay routeDay = null)
        {
            Title = "Linie";
            RouteDay = routeDay;

            RoutesCollection = new ObservableCollection<Route>();
            RoutesBackupCollection = new ObservableCollection<Route>();
            RouteDay.routes.Sort((x, y) => x.RouteId.CompareTo(y.RouteId));

            foreach (Route item in RouteDay.routes)
            {
                item.i = routeDay.i;
                RoutesBackupCollection.Add(item);
            }

            LoadRoutes();
            


        }

        public void SearchCommandExecute(string SearchedText)
        {
            var Backup = RoutesBackupCollection;
            var tempRecords = Backup.Where(c => (c.RouteShortName.IndexOf(SearchedText, StringComparison.OrdinalIgnoreCase) >= 0) || (c.RouteLongName.IndexOf(SearchedText, StringComparison.OrdinalIgnoreCase) >= 0));
            RoutesCollection.Clear();
            foreach (var item in tempRecords)
            {
                RoutesCollection.Add(item);
            }
            if (RoutesCollection.Count == 0)
            {
                foreach (var item in Backup)
                {
                    RoutesCollection.Add(item);
                }
            }
        }
        void LoadRoutes()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                RoutesCollection.Clear();
                var routes = RouteDay.routes;
                foreach (Route route in routes)
                {
                    RoutesCollection.Add(route);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                App.Current.MainPage.DisplayAlert("Błąd", "Coś poszło nie tak", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}