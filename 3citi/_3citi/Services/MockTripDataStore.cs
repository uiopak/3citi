using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using _3citi.Models;

using Xamarin.Forms;

using System.Net;
using Newtonsoft.Json;
using System.Net.Http;

[assembly: Dependency(typeof(_3citi.Services.MockTripDataStore))]
namespace _3citi.Services
{
    public class MockTripDataStore : ITripDataStore<Trip>
    {
        bool isInitialized;
        public List<Trip> trips;

        public void Clear()
        {
            if (trips != null)
                trips.Clear();
        }

        public async Task<IEnumerable<Trip>> GetItemsAsync(int i,bool forceRefresh = false)
        {
            isInitialized = false;
            await InitializeAsync(i);

            return await Task.FromResult(trips);
        }

        public async Task InitializeAsync(int i)
        {
            if (isInitialized)
                return;

            trips = new List<Trip>();
            var client = new HttpClient();
            var jsonTripsUrl = "http://91.244.248.19/dataset/c24aa637-3619-4dc2-a171-a23eec8f2172/resource/33618472-342c-4a4a-ba88-a911ec0ad5a7/download/trips.json";
            var jsonTrips = await client.GetStringAsync(jsonTripsUrl);
            Dictionary<string, TripTop> jTripObject = JsonConvert.DeserializeObject<Dictionary<string, TripTop>>(jsonTrips);
            TripTop DayTrips = new TripTop();

            jTripObject.TryGetValue(DateTime.Now.AddDays(i).Date.ToString("yyyy-MM-dd"), out DayTrips);

            foreach (Trip item in DayTrips.trips)
            {
                trips.Add(item);
            }
           
            isInitialized = true;
        }
    }
}