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
    public class VariantsViewModel : BaseViewModel
    {
        public Direction Direction;
        public int MaxStopSequence { get; set; }
        public string StopName { get; set; }
        public string StopId { get; set; }
        public string RouteId { get; set; }
        public string WheelchairAccessible { get; set; }
        public string OnDemand { get; set; }
        public string TicketZoneBorder { get; set; }
        public string NoteSymbol { get; set; }
        public string NoteDescription { get; set; }
        public bool Tomorrow { get; set; }
        public List<Variant> VariantsBackup { get; set; }
        public StopHoursMinutes stopHoursMinutes { get; set; }
        public RouteStopTimes routeStopTimes { get; set; }
        public List<RouteStopTimes> RouteStopTimes { get; set; }
        public ObservableCollection<StopHoursMinutes> TestyHiM { get; set; }

        public ObservableCollection<StopTime> StopsTime { get; set; }
        public ObservableCollection<Variant> Variants { get; set; }

        public VariantsViewModel(Direction direction = null)
        {
            Title = "Warianty Tras";
            Direction = direction;
            VariantsBackup = new List<Variant>();
            RouteStopTimes = new List<RouteStopTimes>();
            TestyHiM = new ObservableCollection<StopHoursMinutes>();
            StopsTime = new ObservableCollection<StopTime>();
            Variants = new ObservableCollection<Variant>();
            stopHoursMinutes = new StopHoursMinutes();
            routeStopTimes = new RouteStopTimes();
            LoadVariants();
            SortStopsTime();
            Test();
            foreach (Variant variant in Variants)
            {
                VariantsBackup.Add(variant);

            }
            foreach (Variant variant in Variants)
            {
                if (variant.routeStopTimes.Count<=2)
                {
                    VariantsBackup.Remove(variant);
                }
            }
            Variants.Clear();
            foreach (Variant variant in VariantsBackup)
            {
                Variants.Add(variant);

            }


        }
        void LoadVariants()
        {
            foreach (Variant variant in Direction.variants)
            {
                Variants.Add(variant);
            }
        }
        void Test()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                foreach (Variant Variant in Variants)
                {
                    RouteStopTimes = new List<RouteStopTimes>();

                    foreach (StopTime stopTime in Variant.stopTimesTest)
                    {
                        if (MaxStopSequence == 0 || MaxStopSequence < int.Parse(stopTime.StopSequence)) MaxStopSequence = int.Parse(stopTime.StopSequence);
                    }
                    bool create = false;
                    for (int i = 0; i <= MaxStopSequence; i++)
                    {
                        for (int j = 0; j < 25; j++)
                        {
                            stopHoursMinutes.minutes = new List<string>();
                            routeStopTimes.Times = new List<StopHoursMinutes>();
                            routeStopTimes.TimesTomorrow = new List<StopHoursMinutes>();
                            create = false;
                            foreach (StopTime item in Variant.stopTimesTest)
                            {
                                if (int.Parse(item.StopSequence) == i)
                                {
                                    if (item.ArrivalTime.Split(':')[0] != "Następnego dnia o")
                                    {
                                        if (int.Parse(item.ArrivalTime.Split(':')[0]) == j)
                                        {
                                            stopHoursMinutes.Hour = item.ArrivalTime.Split(':')[0];
                                            stopHoursMinutes.minutes.Add(item.ArrivalTime.Split(':')[1]);
                                            StopName = item.StopDesc;
                                            StopId = item.StopId;
                                            NoteSymbol = item.NoteSymbol;
                                            NoteDescription = item.NoteDescription;
                                            OnDemand = item.OnDemand;
                                            RouteId = item.RouteId;
                                            TicketZoneBorder = item.TicketZoneBorder;
                                            WheelchairAccessible = item.WheelchairAccessible;
                                            routeStopTimes.WheelchairAccessible = WheelchairAccessible;
                                            routeStopTimes.TicketZoneBorder = TicketZoneBorder;
                                            routeStopTimes.OnDemand = OnDemand;
                                            routeStopTimes.NoteDescription = NoteDescription;
                                            routeStopTimes.NoteSymbol = NoteSymbol;
                                            routeStopTimes.StopDesc = StopName;
                                            routeStopTimes.StopId = StopId;
                                            routeStopTimes.RouteId = RouteId;
                                            create = true;

                                        }
                                    }
                                    else
                                    {
                                        if (int.Parse(item.ArrivalTime.Split(':')[1]) == j)
                                        {
                                            stopHoursMinutes.Hour = item.ArrivalTime.Split(':')[1];
                                            stopHoursMinutes.minutes.Add(item.ArrivalTime.Split(':')[2]);
                                            StopName = item.StopDesc;
                                            NoteSymbol = item.NoteSymbol;
                                            NoteDescription = item.NoteDescription;
                                            OnDemand = item.OnDemand;
                                            RouteId = item.RouteId;
                                            TicketZoneBorder = item.TicketZoneBorder;
                                            WheelchairAccessible = item.WheelchairAccessible;
                                            routeStopTimes.WheelchairAccessible = WheelchairAccessible;
                                            routeStopTimes.TicketZoneBorder = TicketZoneBorder;
                                            routeStopTimes.OnDemand = OnDemand;
                                            routeStopTimes.NoteDescription = NoteDescription;
                                            routeStopTimes.NoteSymbol = NoteSymbol;
                                            routeStopTimes.StopDesc = StopName;
                                            routeStopTimes.RouteId = RouteId;
                                            create = true;
                                            Tomorrow = true;
                                        }
                                    }
                                }
                            }
                            if (create)
                            {
                                TestyHiM.Add(stopHoursMinutes);
                                stopHoursMinutes = null;
                                stopHoursMinutes = new StopHoursMinutes();
                            }
                        }
                        foreach (StopHoursMinutes SHM in TestyHiM)
                        {
                            if (!Tomorrow) routeStopTimes.Times.Add(SHM);
                            else routeStopTimes.TimesTomorrow.Add(SHM);
                        }
                        Tomorrow = false;
                        TestyHiM.Clear();
                        if (routeStopTimes.StopDesc != null)
                        {
                            RouteStopTimes.Add(routeStopTimes);
                        }
                        routeStopTimes = null;
                        routeStopTimes = new RouteStopTimes();
                    }

                    Variant.routeStopTimes = RouteStopTimes;
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

        void SortStopsTime()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                foreach (Variant Variant in Variants)
                {

                    StopsTime.Clear();
                    StopTimeDataStore.Clear();
                    List<StopTime> DoPosortowania = new List<StopTime>();
                    foreach (StopTime item in Variant.stopTimesTest)
                    {
                        DoPosortowania.Add(item);
                    }
                    DoPosortowania.Sort((x, y) => x.ArrivalTime.CompareTo(y.ArrivalTime));
                    foreach (StopTime item in DoPosortowania)
                    {
                        if (item.Nonpassenger == "0" && item.VirtualId == "0"|| item.Nonpassenger == null && item.VirtualId == null) StopsTime.Add(item);
                    }
                    Variant.stopTimesTest.Clear();
                    foreach (StopTime stopTime in StopsTime)
                    {
                        Variant.stopTimesTest.Add(stopTime);
                    }
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
