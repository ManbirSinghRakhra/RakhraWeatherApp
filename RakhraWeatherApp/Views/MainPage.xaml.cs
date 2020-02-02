using System;
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
            ViewModel = new FavouriteWeatherViewModel();

            this.WhenActivated(disposable =>
            {
                this.OneWayBind(ViewModel, model => model.Items, page => page.listView.ItemsSource)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, model => model.IsRefreshing, page => page.listView.IsRefreshing)
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, model => model.PopulateDataCommand, page => page.Refresh)
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, model => model.PopulateDataCommand, page => page.listView,
                    nameof(listView.Refreshing))
                    .DisposeWith(disposable);
                this.BindCommand(ViewModel, model => model.ClearDataCommand, page => page.Clear)
                    .DisposeWith(disposable);
            });
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ViewModel.Init().ConfigureAwait(false);
        }
    }
}