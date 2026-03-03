// 

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using AutoHitCounter.Enums;

namespace AutoHitCounter.Converters;

public class ParentChildMarginMultiConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        var isParent = values[0] switch
        {
            bool b => b,
            SplitType type => type == SplitType.Parent,
            _ => false
        };

        var hasGroups = values.Length > 1 && values[1] is true;

        if (isParent) return new Thickness(0, 0, 0, 0);
        return hasGroups ? new Thickness(20, 0, 0, 0) : new Thickness(4, 0, 0, 0);
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
    
}