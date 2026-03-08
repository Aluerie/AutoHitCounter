//

using System.ComponentModel;
using System.Runtime.CompilerServices;
using AutoHitCounter.Enums;

namespace AutoHitCounter.Models;

public class SplitEntry : INotifyPropertyChanged
{
    private uint? _eventId;

    public uint? EventId
    {
        get => _eventId;
        set
        {
            _eventId = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsAuto));
        }
    }

    public string Name { get; set; }
    public string DisplayName { get; set; }
    public int PersonalBest { get; set; }
    public SplitType Type { get; set; } = SplitType.Child;
    public string GroupId { get; set; }
    public string Notes { get; set; }

    public string Label => DisplayName ?? Name;
    public bool IsAuto => EventId.HasValue;

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}