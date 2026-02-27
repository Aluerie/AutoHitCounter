// 

using System;
using System.Collections.Generic;
using AutoHitCounter.Enums;
using AutoHitCounter.Interfaces;

namespace AutoHitCounter.Services;

public class StateService : IStateService
{
    private readonly Dictionary<State, List<Action>> _eventHandlers = new();

    public void Publish(State eventType)
    {
        if (_eventHandlers.ContainsKey(eventType))
        {
            foreach (var handler in _eventHandlers[eventType])
                handler.Invoke();
        }
    }

    public void Subscribe(State eventType, Action handler)
    {
        if (!_eventHandlers.ContainsKey(eventType))
            _eventHandlers[eventType] = new List<Action>();

        _eventHandlers[eventType].Add(handler);
    }

    public void Unsubscribe(State eventType, Action handler)
    {
        if (_eventHandlers.ContainsKey(eventType))
            _eventHandlers[eventType].Remove(handler);
    }
}