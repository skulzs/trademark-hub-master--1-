using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;

namespace TrademarkHub.Views;
public partial class AppsView : ReactiveUserControl<AppsViewModel>
{
    public AppsView() => AvaloniaXamlLoader.Load(this);
}
