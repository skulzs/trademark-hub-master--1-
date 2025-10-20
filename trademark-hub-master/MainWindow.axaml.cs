using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TrademarkHub;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    private TextBlock? _clock, _day;
    private readonly CancellationTokenSource _cts = new();

    public MainWindow()
    {
        AvaloniaXamlLoader.Load(this);
        this.WhenActivated(_ => { });
        _clock = this.FindControl<TextBlock>("ClockText");
        _day   = this.FindControl<TextBlock>("DayText");
        _ = TickClock(_cts.Token);
    }

    protected override void OnClosing(WindowClosingEventArgs e)
    {
        _cts.Cancel();
        base.OnClosing(e);
    }

    private async Task TickClock(CancellationToken t)
    {
        while (!t.IsCancellationRequested)
        {
            var now = DateTime.Now;
            if (_day != null)   _day.Text   = now.ToString("dddd, MMMM d, yyyy");
            if (_clock != null) _clock.Text = now.ToString("h:mm:ss tt");
            try { await Task.Delay(1000, t); } catch { break; }
        }
    }
}
