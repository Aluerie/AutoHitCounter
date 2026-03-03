// 

using System;
using System.Collections.Generic;
using AutoHitCounter.Views.Windows;
using TarnishedTool.Views.Windows;

namespace AutoHitCounter.Utilities;

/// <summary>
/// Static helper class to show custom message boxes from anywhere in the application.
/// </summary>
public static class MsgBox
{
    /// <summary>
    /// Shows a message box with only an OK button.
    /// </summary>
    /// <param name="message">The message to display.</param>
    /// <param name="title"></param>
    public static void Show(string message, string title = "Message")
    {
        var box = new CustomMessageBox(message, title, showYesNo: false, showCancel: true);
        box.ShowDialog();
    }

    /// <summary>
    /// Shows a message box with OK and Cancel buttons.
    /// </summary>
    /// <param name="message">The message to display.</param>
    /// <param name="title"></param>
    /// <returns>True if OK was clicked, false if Cancel was clicked.</returns>
    public static bool ShowOkCancel(string message, string title = "Message")
    {
        var box = new CustomMessageBox(message, title, showYesNo: false, showCancel: true);
        box.ShowDialog();
        return box.Result ?? false;
    }

    /// <summary>
    /// Shows a single input dialog.
    /// </summary>
    public static string ShowInput(string prompt, string defaultValue = "", string title = "Input")
    {
        var box = new InputBox(prompt, defaultValue, title);
        box.ShowDialog();
        return box.Result ? box.InputValue : string.Empty;
    }

    /// <summary>
    /// Shows a multi-input dialog.
    /// </summary>
    /// <returns>Dictionary of key-value pairs, or null if cancelled.</returns>
    public static Dictionary<string, string>? ShowInputs(InputField[] fields, string title = "Input")
    {
        var box = new InputBox(fields, title);
        box.ShowDialog();
        return box.Result ? box.GetValues() : null;
    }

    /// <summary>
    /// Shows a message box with Yes and No buttons.
    /// </summary>
    /// <param name="message">The message to display.</param>
    /// <param name="title">The title of the message box.</param>
    /// <returns>True if Yes was clicked, false if No was clicked.</returns>
    public static bool ShowYesNo(string message, string title = "Message")
    {
        var box = new CustomMessageBox(message, title, showYesNo: true, showCancel: false);
        box.ShowDialog();
        return box.Result ?? false;
    }

    /// <summary>
    /// Shows a message box with Yes, No and Cancel buttons.
    /// </summary>
    /// <param name="message">The message to display.</param>
    /// <param name="title">The title of the message box.</param>
    /// <returns>True if Yes was clicked, false if No was clicked, null if Cancel was clicked.</returns>
    public static bool? ShowYesNoCancel(string message, string title = "Message")
    {
        var box = new CustomMessageBox(message, title, showYesNo: true, showCancel: true);
        box.ShowDialog();
        return box.Result;
    }

    public static CustomMessageBoxResult ShowImportConflict(string profileName)
    {
        var box = new CustomMessageBox(
            $"Profile \"{profileName}\" already exists.{Environment.NewLine}What would you like to do?",
            "Import Conflict",
            [CustomMessageBoxResult.Replace, CustomMessageBoxResult.Rename, CustomMessageBoxResult.Skip]);
        box.ShowDialog();
        return box.ResultValue;
    }

    public static CustomMessageBoxResult ShowExportScope(string gameName)
    {
        var box = new CustomMessageBox(
            $"Which profiles would you like to export?",
            "Export",
            [CustomMessageBoxResult.All, CustomMessageBoxResult.Current, CustomMessageBoxResult.Cancel]);
        box.ShowDialog();
        return box.ResultValue;
    }
}