using System.Reactive.Disposables;
using ReactiveUI;
using Splat;

namespace RakhraWeatherApp.ViewModels
{
    public class ViewModelBase: ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment { get; set; }
        public IScreen HostScreen { get; set; }
        
        protected readonly CompositeDisposable SubscriptionDisposables = new CompositeDisposable();

        public ViewModelBase(IScreen hostScreen = null)
        {
            HostScreen = hostScreen ?? Locator.Current.GetService<IScreen>();
        }
    }
}