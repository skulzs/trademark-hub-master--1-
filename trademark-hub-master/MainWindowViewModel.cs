using ReactiveUI;
using System.Reactive;

namespace TrademarkHub;
public class MainWindowViewModel : ReactiveObject, IScreen
{
    public RoutingState Router { get; } = new RoutingState();

    bool _isMainMenuVisible = true;
    public bool IsMainMenuVisible
    {
        get => _isMainMenuVisible;
        set => this.RaiseAndSetIfChanged(ref _isMainMenuVisible, value);
    }

    public ReactiveCommand<Unit, Unit> GoToApps { get; }
    public ReactiveCommand<Unit, Unit> GoHome { get; }

    public MainWindowViewModel()
    {
        GoToApps = ReactiveCommand.Create(() =>
        {
            Router.Navigate.Execute(new Views.AppsViewModel(this));
            IsMainMenuVisible = false;
        });

        GoHome = ReactiveCommand.Create(() =>
        {
            Router.Navigate.Execute(new Views.HomeViewModel(this));
            IsMainMenuVisible = true;
        });
    }
}
