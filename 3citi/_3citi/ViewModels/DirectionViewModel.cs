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
    public class DirectionViewModel : BaseViewModel
    {
        public ObservableCollection<Trip> TripsCollection { get; set; }
        public ObservableCollection<Direction> DirectionsCollection { get; set; }
        public ObservableCollection<StopTime> StopTimesCollection { get; set; }
        public ObservableCollection<Stop> StopsCollection { get; set; }
        public Command LoadDirectionsCommand { get; set; }
        public Route Route;
        public string Wynik { get; set; }

        public DirectionViewModel(Route route=null)
        {
            Title = "Kierunki";
            Wynik = Testy(route.AgencyId);
            Route = route;
            TripsCollection = new ObservableCollection<Trip>();
            DirectionsCollection = new ObservableCollection<Direction>();
            StopTimesCollection = new ObservableCollection<StopTime>();
            StopsCollection = new ObservableCollection<Stop>();
            LoadDirectionsCommand = new Command(async () => await ExecuteLoadDirectionsCommand());
            LoadDirectionsCommand.Execute(null);
        }
        string Testy(int to)
        {
            switch (to)
            {
                case 1: return "GAiT Autobusy";
                case 2: return "GAiT Tramwaje";
                case 3: return "Warbus Gdańsk";
                case 4: return "PKS Gdańsk";
                case 5: return "PKT Gdyniak";
                case 6: return "PKA Gdynia";
                case 7: return "PA GRYF";
                case 8: return "PKM Gdynia";
                case 9: return "PKS Wejherowo";
                case 10: return "PKS Gdynia";
                case 11: return "Warbus Gdynia";
                case 17: return "Irex";
                default: return "Błąd";
            }
        }
        
        async Task ExecuteLoadDirectionsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                StopsCollection.Clear();
                var stops = await StopDataStore.GetItemsAsync(true);
                foreach (Stop stop in stops)
                {
                    StopsCollection.Add(stop);
                }

                StopTimesCollection.Clear();
                StopTimeDataStore.Clear();
                var stopsTime = await StopTimeDataStore.GetItemsAsync(Route.RouteId, Route.i, true);
                foreach (StopTime stopTime in stopsTime)
                {
                    StopTimesCollection.Add(stopTime);
                }

                foreach (Stop stop in StopsCollection)
                {
                    foreach (StopTime stopTime in StopTimesCollection)
                    {
                        if (stop.StopId == stopTime.StopId)
                        {
                            stopTime.StopDesc = stop.StopDesc;
                        }
                    }
                }
                foreach (StopTime stopTime in StopTimesCollection)
                {
                    stopTime.ArrivalTime = stopTime.ArrivalTime.Replace("1899-12-30T", "");
                    stopTime.DepartureTime = stopTime.DepartureTime.Replace("1899-12-30T", "");
                    stopTime.ArrivalTime = stopTime.ArrivalTime.Replace("1899-12-31T", "Następnego dnia o:");
                    stopTime.DepartureTime = stopTime.DepartureTime.Replace("1899-12-31T", "Następnego dnia o:");
                }
                
                TripsCollection.Clear();
                var trips = await TripsDataStore.GetItemsAsync(Route.i, true);

                foreach (Trip trip in trips)
                {
                    TripsCollection.Add(trip);
                }
                DirectionsCollection.Clear();
                Direction DirectionZero = new Direction();
                DirectionZero.variants = new List<Variant>();
                Direction DirectionOne = new Direction();
                DirectionOne.variants = new List<Variant>();
                foreach (Trip trip in TripsCollection)
                {
                    if (Route.RouteId == int.Parse(trip.RouteId))
                    {
                        if (trip.DirectionId == "2")
                        {
                            Variant variantV2 = new Variant();
                            variantV2.stopTimesTest = new List<StopTime>();
                            DirectionZero.directionId = trip.DirectionId;
                            variantV2.directionId = int.Parse(trip.DirectionId);
                            variantV2.tripId = int.Parse(trip.TripId);
                            variantV2.tripHeadsign = trip.TripHeadsign;
                            foreach (StopTime stopTime in StopTimesCollection)
                            {
                                if (int.Parse(stopTime.RouteId) == Route.RouteId && stopTime.TripId == trip.TripId)
                                {
                                    variantV2.stopTimesTest.Add(stopTime);
                                }
                            }
                            DirectionZero.variants.Add(variantV2);
                        }
                        if (trip.DirectionId == "1")
                        {
                            Variant variantV1 = new Variant();
                            variantV1.stopTimesTest = new List<StopTime>();
                            DirectionOne.directionId = trip.DirectionId;
                            variantV1.directionId = int.Parse(trip.DirectionId);
                            variantV1.tripId = int.Parse(trip.TripId);
                            variantV1.tripHeadsign = trip.TripHeadsign;
                            foreach (StopTime stopTime in StopTimesCollection)
                            {
                                if (int.Parse(stopTime.RouteId) == Route.RouteId && stopTime.TripId == trip.TripId)
                                {
                                    variantV1.stopTimesTest.Add(stopTime);
                                }
                            }
                            DirectionOne.variants.Add(variantV1);
                        }
                    }
                }
                DirectionsCollection.Add(DirectionOne);
                DirectionsCollection.Add(DirectionZero);
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
        /*
        async Task ExecuteLoadTripCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Trips.Clear();
                var trips = await TripsDataStore.GetItemsAsync(Route.i, true);
                Trips.ReplaceRange(trips);
                LoadDirectionsCommand.Execute(null);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Unable to load items.",
                    Cancel = "OK"
                }, "message");
            }
            finally
            {
                IsBusy = false;
            }
        }
        
        void ExecuteCreateDirectionList()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Directions.Clear();
                Direction DirectionZero = new Direction();
                Direction DirectionOne = new Direction();
                foreach (Trip trip in Trips)
                {
                    if (Route.RouteId == int.Parse(trip.RouteId))
                    {
                        if (trip.DirectionId == "0")
                        {
                            Variant Variant = new Variant();
                            DirectionZero.directionId = trip.DirectionId;
                            Variant.directionId = int.Parse(trip.DirectionId);
                            Variant.tripId = int.Parse(trip.TripId);
                            Variant.tripHeadsign = trip.TripHeadsign;
                            foreach (StopTime stopTime in StopsTime)
                            {
                                if (int.Parse(stopTime.RouteId) == Route.RouteId && stopTime.TripId == trip.TripId)
                                {
                                    Variant.stopTimesTest.Add(stopTime);
                                }
                            }
                            DirectionZero.variants.Add(Variant);
                        }
                        if (trip.DirectionId == "1")
                        {
                            Variant Variant = new Variant();
                            DirectionZero.directionId = trip.DirectionId;
                            Variant.directionId = int.Parse(trip.DirectionId);
                            Variant.tripId = int.Parse(trip.TripId);
                            Variant.tripHeadsign = trip.TripHeadsign;
                            foreach (StopTime stopTime in StopsTime)
                            {
                                if (int.Parse(stopTime.RouteId) == Route.RouteId && stopTime.TripId == trip.TripId)
                                {
                                    Variant.stopTimesTest.Add(stopTime);
                                }
                            }
                            DirectionOne.variants.Add(Variant);
                        }

                    }
                }
                Directions.Add(DirectionZero);
                Directions.Add(DirectionOne);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Unable to load items.",
                    Cancel = "OK"
                }, "message");
            }
            finally
            {
                IsBusy = false;
            }
        }*/
    }
}
