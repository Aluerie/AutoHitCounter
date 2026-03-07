using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace AutoHitCounter.Utilities;

public static class EnumExtensions
{
    public static string GetDescription<T>(this T value) where T : Enum
    {
        var field = typeof(T).GetField(value.ToString());
        var attribute = field?.GetCustomAttribute<DescriptionAttribute>();
        return attribute?.Description ?? value.ToString();
    }
    
    public static IEnumerable<T> GetValues<T>()
    {
        return (T[])Enum.GetValues(typeof(T));
    }
}
