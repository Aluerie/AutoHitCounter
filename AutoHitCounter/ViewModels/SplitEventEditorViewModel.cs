using System.Collections.Generic;
using System.Collections.ObjectModel;
using AutoHitCounter.Core;
using AutoHitCounter.Models;

namespace AutoHitCounter.ViewModels;

public class SplitEventEditorViewModel : BaseViewModel
{
    private readonly Dictionary<uint, string> _allEvents;

    public SplitEventEditorViewModel(SplitEntry split, Dictionary<uint, string> allEvents)
    {
        _allEvents = allEvents;
        SplitName = split.Label;

        
        ConfirmCommand = new DelegateCommand(Confirm, () => IsValidEventId);
        ClearCommand = new DelegateCommand(Clear);

        
        EventIdText = split.EventId?.ToString() ?? string.Empty;

        foreach (var kvp in allEvents)
            AllEvents.Add(new SplitEntry { EventId = kvp.Key, Name = kvp.Value });

        FilteredEvents = new ObservableCollection<SplitEntry>(AllEvents);
    }

    public string SplitName { get; }
    public ObservableCollection<SplitEntry> AllEvents { get; } = new();
    public ObservableCollection<SplitEntry> FilteredEvents { get; }
    public uint? ResultEventId { get; private set; }
    public bool Confirmed { get; private set; }

    public DelegateCommand ConfirmCommand { get; }
    public DelegateCommand ClearCommand { get; }

    private string _eventIdText;

    public string EventIdText
    {
        get => _eventIdText;
        set
        {
            if (SetProperty(ref _eventIdText, value))
            {
                OnPropertyChanged(nameof(IsValidEventId));
                ConfirmCommand.RaiseCanExecuteChanged();
            }
        }
    }

    private SplitEntry _selectedEvent;

    public SplitEntry SelectedEvent
    {
        get => _selectedEvent;
        set
        {
            if (SetProperty(ref _selectedEvent, value) && value != null)
                EventIdText = value.EventId?.ToString() ?? string.Empty;
        }
    }

    private string _searchText;

    public string SearchText
    {
        get => _searchText;
        set
        {
            if (SetProperty(ref _searchText, value))
                FilterEvents();
        }
    }

    public bool IsValidEventId => string.IsNullOrEmpty(EventIdText) ||
                                  uint.TryParse(EventIdText, out _);

    private void Confirm()
    {
        if (!string.IsNullOrEmpty(EventIdText) &&
            uint.TryParse(EventIdText, out var id))
            ResultEventId = id;
        else
            ResultEventId = null;

        Confirmed = true;
        RequestClose?.Invoke();
    }

    private void Clear()
    {
        EventIdText = string.Empty;
        SelectedEvent = null;
        ResultEventId = null;
        Confirmed = true;
        RequestClose?.Invoke();
    }

    private void FilterEvents()
    {
        FilteredEvents.Clear();
        foreach (var e in AllEvents)
        {
            if (string.IsNullOrEmpty(_searchText) ||
                e.Name.ToLower().Contains(_searchText.ToLower()))
                FilteredEvents.Add(e);
        }
    }

    public System.Action RequestClose { get; set; }
}