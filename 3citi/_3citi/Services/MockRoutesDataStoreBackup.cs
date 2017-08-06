using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using _3citi.Models;

using Xamarin.Forms;

using System.Net;
using Newtonsoft.Json;
using System.Net.Http;

[assembly: Dependency(typeof(_3citi.Services.MockRoutesDataStoreBackup))]
namespace _3citi.Services
{
    public class MockRoutesDataStoreBackup : IRoutesDataStore<Route>
    {
        bool isInitialized;
        List<Route> routes;

        public void Clear()
        {
            if (routes != null)
                routes.Clear();
        }
        
        public async Task<IEnumerable<Route>> GetItemsAsync(bool forceRefresh = false)
        {
            await InitializeAsync();

            return await Task.FromResult(routes);
        }
        
        public async Task InitializeAsync()
        {
            if (isInitialized)
                return;

            routes = new List<Route>();
            var client = new HttpClient();
            var jsonRouteUrl = "http://91.244.248.19/dataset/c24aa637-3619-4dc2-a171-a23eec8f2172/resource/4128329f-5adb-4082-b326-6e1aea7caddf/download/routes.json";
            var jsonRoute = await client.GetStringAsync(jsonRouteUrl);
            Dictionary<string, RouteTop> jRouteObject = JsonConvert.DeserializeObject<Dictionary<string, RouteTop>>(jsonRoute);
            RouteTop DayRoutes = new RouteTop();

            jRouteObject.TryGetValue(DateTime.Now.AddDays(0).Date.ToString("yyyy-MM-dd"), out DayRoutes);

            foreach (Route item in DayRoutes.routes)
            {
                routes.Add(item);
            }

            isInitialized = true;
        }
    }    
}