using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using _3citi.Models;

using Xamarin.Forms;

using System.Net;
using Newtonsoft.Json;
using System.Net.Http;

[assembly: Dependency(typeof(_3citi.Services.MockStopsTimeDataStore))]
namespace _3citi.Services
{
    public class MockStopsTimeDataStore : IStopTimeDataStore<StopTime>
    {
        bool isInitialized;
        public List<StopTime> stopsTime;
        
        public void Clear()
        {   if(stopsTime!=null)
            stopsTime.Clear();
        }
        
        public async Task<IEnumerable<StopTime>> GetItemsAsync(int route,int i,bool forceRefresh = false)
        {
            isInitialized = false;
            await InitializeAsync(route,i);

            return await Task.FromResult(stopsTime);
        }

        public async Task InitializeAsync(int route,int i)
        {
            if (isInitialized)
                return;

            stopsTime = new List<StopTime>();
            var client = new HttpClient();
            var jsonStopsTimeUrl = "http://ckan2.multimediagdansk.pl/stopTimes?date=" + DateTime.Now.AddDays(i).Date.ToString("yyyy-MM-dd") + "&routeId=" + route;
            var jsonStopsTime = await client.GetStringAsync(jsonStopsTimeUrl);
            jsonStopsTime = jsonStopsTime.Replace("virtual", "virtualId");
            StopTimeTop jStopsTimeObjectTest = JsonConvert.DeserializeObject<StopTimeTop>(jsonStopsTime);

            foreach (StopTime item in jStopsTimeObjectTest.stopTimes)
            {
                stopsTime.Add(item);
            }
            
            isInitialized = true;
        }
    }
}