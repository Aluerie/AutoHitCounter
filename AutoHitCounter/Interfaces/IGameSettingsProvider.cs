using System;

namespace AutoHitCounter.Interfaces;

public interface IGameSettingsProvider
{
    bool GetFlag(string key);
    event Action OnSettingsChanged;
}
