using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using _3citi.Models;

using Xamarin.Forms;

using System.Net;
using Newtonsoft.Json;
using System.Net.Http;

[assembly: Dependency(typeof(_3citi.Services.MockStopDelayDataStore))]
namespace _3citi.Services
{
    public class MockStopDelayDataStore : IStopDelayDataStore<Delay>
    {
        bool isInitialized;
        List<Delay> delays;
        
        public void Clear()
        {
            if (delays != null)
                delays.Clear();
        }
                
        public async Task<IEnumerable<Delay>> GetItemsAsync(int route, bool forceRefresh = false)
        {
            isInitialized = false;
            await InitializeAsync(route);

            return await Task.FromResult(delays);
        }

        public async Task InitializeAsync(int stopId)
        {
            if (isInitialized)
                return;

            delays = new List<Delay>();
            var client = new HttpClient();
            var jsonDelaysUrl = "http://87.98.237.99:88/delays?stopId=" + stopId;
            var jsonDelays = await client.GetStringAsync(jsonDelaysUrl);
            DelayTop jDelaysObject = JsonConvert.DeserializeObject<DelayTop>(jsonDelays);

            foreach (Delay item in jDelaysObject.delay)
            {
                delays.Add(item);
            }
            isInitialized = true;
        }
    }
}