using ReactiveUI;
using System.Reactive;

namespace TrademarkHub.Views;
public class AppsViewModel : ReactiveObject, IRoutableViewModel
{
    public string UrlPathSegment => "Apps";
    public IScreen HostScreen { get; }

    public ReactiveCommand<Unit, Unit> GoHome { get; }

    public AppsViewModel(IScreen host)
    {
        HostScreen = host;
        if (host is TrademarkHub.MainWindowViewModel mwvm)
        {
            // Proxy to MainWindowViewModel.GoHome
            GoHome = ReactiveCommand.CreateFromObservable(() => mwvm.GoHome.Execute());
        }
        else
        {
            GoHome = ReactiveCommand.Create(() => { });
        }
    }
}
