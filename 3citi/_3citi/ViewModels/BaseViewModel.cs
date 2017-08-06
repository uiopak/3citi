using _3citi.Helpers;
using _3citi.Models;
using _3citi.Services;

using Xamarin.Forms;

namespace _3citi.ViewModels
{
	public class BaseViewModel : ObservableObject
	{
        public ITripDataStore<Trip> TripsDataStore => DependencyService.Get<ITripDataStore<Trip>>();
        public IRoutesDayDataStore<RouteDay> RoutesDayDataStore => DependencyService.Get<IRoutesDayDataStore<RouteDay>>();
        public IRoutesDataStore<Route> RouteDataStore => DependencyService.Get<IRoutesDataStore<Route>>();
        public IStopDataStore<Stop> StopDataStore => DependencyService.Get<IStopDataStore<Stop>>();
        public IStopDelayDataStore<Delay> StopDelaysDataStore => DependencyService.Get<IStopDelayDataStore<Delay>>();
        public IStopTimeDataStore<StopTime> StopTimeDataStore => DependencyService.Get<IStopTimeDataStore<StopTime>>();

        bool isBusy = false;
		public bool IsBusy
		{
			get { return isBusy; }
			set { SetProperty(ref isBusy, value); }
		}

		string title = string.Empty;

		public string Title
		{
			get { return title; }
			set { SetProperty(ref title, value); }
		}
	}
}

