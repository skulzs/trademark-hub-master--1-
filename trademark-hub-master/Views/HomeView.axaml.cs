using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;

namespace TrademarkHub.Views;
public partial class HomeView : ReactiveUserControl<HomeViewModel>
{
    public HomeView() => AvaloniaXamlLoader.Load(this);
}
