//

using System;
using System.Collections.Generic;
using System.Windows.Threading;
using AutoHitCounter.Interfaces;
using AutoHitCounter.Models;
using Stopwatch = System.Diagnostics.Stopwatch;

namespace AutoHitCounter.Games.Manual;

public class ManualGameModule : IGameModule, IDisposable
{
    private readonly Stopwatch _stopwatch = new();
    private readonly DispatcherTimer _timer;

    public event Action<int> OnHit;
    public event Action OnEventSet;
    public event Action<List<EventLogEntry>> OnEventLogEntriesReceived;
    public event Action<long> OnTimeChanged;

    public ManualGameModule()
    {
        _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
        _timer.Tick += (_, _) => OnTimeChanged?.Invoke(_stopwatch.ElapsedMilliseconds);
    }

    public void StartTimer()
    {
        _stopwatch.Start();
        _timer.Start();
    }

    public void StopTimer()
    {
        _stopwatch.Stop();
        _timer.Stop();
    }

    public void ResetTimer()
    {
        _stopwatch.Reset();
        OnTimeChanged?.Invoke(0);
    }

    public void UpdateEvents(Dictionary<uint, (string Name, int Required, int Hit)> events) { }
    public void ApplySettings(bool onlyEnabled = false) { }
    public void SetEventLogEnabled(bool enabled) { }

    public void Dispose()
    {
        _timer.Stop();
        OnHit = null;
        OnEventSet = null;
        OnEventLogEntriesReceived = null;
        OnTimeChanged = null;
    }
}
