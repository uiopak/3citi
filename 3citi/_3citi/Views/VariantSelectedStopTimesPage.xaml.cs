using _3citi.ViewModels;
using _3citi;

using Xamarin.Forms;

using Xamarin.Forms.Xaml;
using _3citi.Models;

namespace _3citi.Views
{

    public partial class VariantSelectedStopTimesPage : ContentPage
    {
        VariantSelectedStopTimesViewModel viewModel;

        public VariantSelectedStopTimesPage()
        {
            InitializeComponent();
        }

        public VariantSelectedStopTimesPage(VariantSelectedStopTimesViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }        
    }
}