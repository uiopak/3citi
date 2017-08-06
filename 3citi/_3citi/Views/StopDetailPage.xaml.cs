
using _3citi.ViewModels;

using Xamarin.Forms;

namespace _3citi.Views
{
    public partial class StopDetailPage : ContentPage
    {
        StopDetailViewModel viewModel;

        public StopDetailPage()
        {
            InitializeComponent();
        }

        public StopDetailPage(StopDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
    }
}