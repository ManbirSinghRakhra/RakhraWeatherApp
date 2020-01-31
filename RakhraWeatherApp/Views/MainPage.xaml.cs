using System.ComponentModel;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using RakhraWeatherApp.Services.Interfaces;
using RakhraWeatherApp.ViewModels;
using ReactiveUI;
using ReactiveUI.XamForms;
using Splat;
using Xamarin.Forms;

namespace RakhraWeatherApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ReactiveContentPage<FavouriteWeatherViewModel>
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = ViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel = new FavouriteWeatherViewModel();
        }
    }
}