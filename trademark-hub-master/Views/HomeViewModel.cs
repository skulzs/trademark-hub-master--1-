using ReactiveUI;

namespace TrademarkHub.Views;
public class HomeViewModel : ReactiveObject, IRoutableViewModel
{
    public string UrlPathSegment => "Home";
    public IScreen HostScreen { get; }
    public HomeViewModel(IScreen host) => HostScreen = host;
}
