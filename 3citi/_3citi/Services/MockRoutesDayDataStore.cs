using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using _3citi.Models;

using Xamarin.Forms;

using System.Net;
using Newtonsoft.Json;
using System.Net.Http;

[assembly: Dependency(typeof(_3citi.Services.MockRoutesDayDataStore))]
namespace _3citi.Services
{
    public class MockRoutesDayDataStore : IRoutesDayDataStore<RouteDay>
    {
        bool isInitialized;
        List<RouteDay> routesWeek;
 
        public async Task<IEnumerable<RouteDay>> GetItemsAsync(bool forceRefresh = false)
        {
            await InitializeAsync();

            return await Task.FromResult(routesWeek);
        }

        public async Task InitializeAsync()
        {
            if (isInitialized)
                return;

            routesWeek = new List<RouteDay>();
            var client = new HttpClient();
            var jsonRouteUrl = "http://91.244.248.19/dataset/c24aa637-3619-4dc2-a171-a23eec8f2172/resource/4128329f-5adb-4082-b326-6e1aea7caddf/download/routes.json";
            var jsonRoute = await client.GetStringAsync(jsonRouteUrl);
            Dictionary<string, RouteTop> jRouteObject = JsonConvert.DeserializeObject<Dictionary<string, RouteTop>>(jsonRoute);
            RouteTop DayRoutes = new RouteTop();

            for (int i = 0; i < 7; i++)
            {
                List<Route> RoutesList = new List<Route>();
                RouteDay routeDay = new RouteDay();
                switch ((int)DateTime.Now.AddDays(i).DayOfWeek)
                {
                    case 1:
                        jRouteObject.TryGetValue(DateTime.Now.AddDays(i).Date.ToString("yyyy-MM-dd"), out DayRoutes);
                        foreach (Route item in DayRoutes.routes) RoutesList.Add(item);
                        routeDay.Day = "Poniedziałek";
                        routeDay.index = 1;
                        routeDay.routes = RoutesList;
                        routeDay.i = i;
                        routesWeek.Add(routeDay);
                        break;
                    case 2:
                        jRouteObject.TryGetValue(DateTime.Now.AddDays(i).Date.ToString("yyyy-MM-dd"), out DayRoutes);
                        foreach (Route item in DayRoutes.routes) RoutesList.Add(item);
                        routeDay.Day = "Wtorek";
                        routeDay.index =2;
                        routeDay.routes = RoutesList;
                        routeDay.i = i;
                        routesWeek.Add(routeDay);
                        break;
                    case 3:
                        jRouteObject.TryGetValue(DateTime.Now.AddDays(i).Date.ToString("yyyy-MM-dd"), out DayRoutes);
                        foreach (Route item in DayRoutes.routes) RoutesList.Add(item);
                        routeDay.Day = "Środa";
                        routeDay.index = 3;
                        routeDay.routes = RoutesList;
                        routeDay.i = i;
                        routesWeek.Add(routeDay);
                        break;
                    case 4:
                        jRouteObject.TryGetValue(DateTime.Now.AddDays(i).Date.ToString("yyyy-MM-dd"), out DayRoutes);
                        foreach (Route item in DayRoutes.routes) RoutesList.Add(item);
                        routeDay.Day = "Czwartek";
                        routeDay.index = 4;
                        routeDay.routes = RoutesList;
                        routeDay.i = i;
                        routesWeek.Add(routeDay);
                        break;
                    case 5:
                        jRouteObject.TryGetValue(DateTime.Now.AddDays(i).Date.ToString("yyyy-MM-dd"), out DayRoutes);
                        foreach (Route item in DayRoutes.routes) RoutesList.Add(item);
                        routeDay.Day = "Piątek";
                        routeDay.index = 5;
                        routeDay.routes = RoutesList;
                        routeDay.i = i;
                        routesWeek.Add(routeDay);
                        break;
                    case 6:
                        jRouteObject.TryGetValue(DateTime.Now.AddDays(i).Date.ToString("yyyy-MM-dd"), out DayRoutes);
                        foreach (Route item in DayRoutes.routes) RoutesList.Add(item);
                        routeDay.Day = "Sobota";
                        routeDay.index = 6;
                        routeDay.routes = RoutesList;
                        routeDay.i = i;
                        routesWeek.Add(routeDay);
                        break;
                    case 0:
                        jRouteObject.TryGetValue(DateTime.Now.AddDays(i).Date.ToString("yyyy-MM-dd"), out DayRoutes);
                        foreach (Route item in DayRoutes.routes) RoutesList.Add(item);
                        routeDay.Day = "Niedziela";
                        routeDay.index = 7;
                        routeDay.routes = RoutesList;
                        routeDay.i = i;
                        routesWeek.Add(routeDay);
                        break;
                }

            }
            routesWeek.Sort((x, y) => x.index.CompareTo(y.index));

            isInitialized = true;
        }
    }
    
}