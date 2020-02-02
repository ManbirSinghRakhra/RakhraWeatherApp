using System;
using System.ComponentModel;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
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
    public partial class MainPage : ContentPageBase<FavouriteWeatherViewModel>
    {
        public MainPage()
        {
            InitializeComponent();

            this.WhenActivated(disposable =>
            {
                this.OneWayBind(ViewModel, model => model.Items, page => page.listView.ItemsSource)
                    .DisposeWith(disposable);
                this.Bind(ViewModel, model => model.IsRefreshing, page => page.listView.IsRefreshing)
                    .DisposeWith(disposable);

                this.Refresh.Events().Clicked.Select(args => Unit.Default).InvokeCommand(ViewModel.PopulateDataCommand)
                    .DisposeWith(disposable);
                this.Clear.Events().Clicked.Select(args => Unit.Default).InvokeCommand(ViewModel.ClearDataCommand)
                    .DisposeWith(disposable);
                this.listView.Events().Refreshing.Select(args => Unit.Default)
                    .InvokeCommand(ViewModel.PopulateDataCommand).DisposeWith(disposable);
            });
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ViewModel.Init().ConfigureAwait(false);
        }
    }
}