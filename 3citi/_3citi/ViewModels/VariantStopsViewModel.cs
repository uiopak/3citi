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
    public class VariantStopsViewModel : BaseViewModel
    {
        public ObservableCollection<RouteStopTimes> StopsTimeCollection { get; set; }
        public ObservableCollection<RouteStopTimes> StopsTimeSearchBackupCollection { get; set; }
        public Variant Variant { get; set; }
        public List<RouteStopTimes> RouteStopTimes { get; set; }

        public VariantStopsViewModel(Variant variant = null)
        {
            Variant = variant;
            Title = variant.tripHeadsign + " lista przystanków";
            RouteStopTimes = new List<RouteStopTimes>();
            RouteStopTimes = variant.routeStopTimes;
            StopsTimeCollection = new ObservableCollection<RouteStopTimes>();
            StopsTimeSearchBackupCollection = new ObservableCollection<RouteStopTimes>();
        }        
    }
}
