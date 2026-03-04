using System;

namespace AutoHitCounter.ViewModels;

public class GameFlagViewModel(string key, string displayName, bool currentValue, Action<string, bool> onChanged)
    : BaseViewModel
{
    private bool _isEnabled = currentValue;

    public string Key { get; } = key;
    public string DisplayName { get; } = displayName;

    public bool IsEnabled
    {
        get => _isEnabled;
        set
        {
            if (SetProperty(ref _isEnabled, value))
                onChanged(Key, value);
        }
    }
}
