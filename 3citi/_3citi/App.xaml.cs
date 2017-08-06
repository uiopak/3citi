using _3citi.Views;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using _3citi.Models;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace _3citi
{
    public partial class App : Application  
    {
        public App()
        {
            InitializeComponent();
            SetMainPage();
        }

        public static void SetMainPage()
        {
            Current.MainPage = new TabbedPage
            {
                Children =
                {
                    new NavigationPage (new RoutesPage())
                    {
                        Title = "Linie",
                        Icon = Device.OnPlatform<string>("tab_feed.png",null,null)
                    },
                    new NavigationPage (new StopsPage())
                    {
                        Title = "Przystanki",
                        Icon = Device.OnPlatform<string>("tab_about.png",null,null)
                    },
                }
            };
        }
	}
}
