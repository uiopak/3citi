using System;
using System.Diagnostics;
using System.Threading.Tasks;

using _3citi.Helpers;
using _3citi.Models;
using _3citi.Views;
using _3citi.Services;

using Xamarin.Forms;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace _3citi.ViewModels
{
    public class VariantSelectedStopTimesViewModel : BaseViewModel
    {
        public ObservableCollection<Delay> DelaysCollection { get; set; }
        public ObservableCollection<Route> RoutesCollection { get; set; }
        
        public Command Test;
        
        public RouteStopTimes RouteStopTimes { get; set; }

        public string RouteName;
        public bool IsTimeVisible { get; set; }
        public bool IsNoteSymbolVisible { get; set; }
        public bool IsNoteDescriptionVisible { get; set; }
        public bool IsTomorrowVisible { get; set; }
        public bool LiveArrival { get; set; }
        public string NoteSymbol { get; set; }
        public string NoteDescription { get; set; }
        public GridLength TomorrowHeightAuto
        {
            get { return new GridLength(1, GridUnitType.Auto); }
        }
        public GridLength TomorrowHeightZero
        {
            get { return new GridLength(0); }
        }
        public GridLength TomorrowHeightStar
        {
            get { return new GridLength(1, GridUnitType.Star); }
        }
        public GridLength TomorrowHeightTwoStar
        {
            get { return new GridLength(2, GridUnitType.Star); }
        }
        public GridLength TomorrowHeightLive { get; set; }
        public GridLength TomorrowHeightTime { get; set; }
        public GridLength TomorrowHeightTimeTomorrow { get; set; }

        public VariantSelectedStopTimesViewModel(RouteStopTimes routeStopTimes = null)
        {
            RouteStopTimes = routeStopTimes;
            NoteDescription = RouteStopTimes.NoteDescription;
            NoteSymbol = RouteStopTimes.NoteSymbol;
            TomorrowHeightLive = TomorrowHeightStar;
            TomorrowHeightTime = TomorrowHeightTwoStar;
            TomorrowHeightTimeTomorrow = TomorrowHeightTwoStar;
            LiveArrival = true;
            DelaysCollection = new ObservableCollection<Delay>();
            RoutesCollection = new ObservableCollection<Route>();
            Test = new Command(async () => await ExecuteLoadItemsCommand());
            Test.Execute(null);
            Title = RouteStopTimes.StopDesc+", linia: "+RouteStopTimes.RouteId;
            foreach (StopHoursMinutes SHM in RouteStopTimes.Times)
            {
                string minutesStr = "";
                SHM.minutes.Sort((x, y) => y.CompareTo(x));
                foreach (string item in SHM.minutes)
                {
                    if (minutesStr == "")
                        minutesStr = item;
                    else minutesStr = item + ", " + minutesStr;
                }
                SHM.minutesString = minutesStr;
            }
            if (RouteStopTimes.Times.Count == 0) { IsTimeVisible = false; TomorrowHeightTime = TomorrowHeightZero; }
            else IsTimeVisible = true;
            foreach (StopHoursMinutes SHM in RouteStopTimes.TimesTomorrow)
            {
                string minutesStr = "";
                SHM.minutes.Sort((x, y) => y.CompareTo(x));
                foreach (string item in SHM.minutes)
                {
                    if (minutesStr == "")
                        minutesStr = item;
                    else minutesStr = item + ", " + minutesStr;
                }
                SHM.minutesString = minutesStr;
            }
            if (RouteStopTimes.TimesTomorrow.Count == 0) { IsTomorrowVisible = false; TomorrowHeightTimeTomorrow = TomorrowHeightZero; }
            else IsTomorrowVisible = true;
        }
        async Task ExecuteLoadItemsCommand()
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
                var delays = await StopDelaysDataStore.GetItemsAsync(int.Parse(RouteStopTimes.StopId), true);
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
                    LiveArrival = false;
                    TomorrowHeightLive = TomorrowHeightZero;
                    await App.Current.MainPage.DisplayAlert("", "Brak  przyjazdów w najbliższym czasie", "OK");
                }
                var Routes = await  RouteDataStore.GetItemsAsync(true);
                foreach (Route route in Routes)
                {
                    if (route.RouteId == int.Parse(RouteStopTimes.RouteId)) RouteName = route.RouteShortName;
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