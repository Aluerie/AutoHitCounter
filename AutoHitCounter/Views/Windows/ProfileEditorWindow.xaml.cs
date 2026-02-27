// 

using System.ComponentModel;
using System.Windows;
using AutoHitCounter.Utilities;
using AutoHitCounter.ViewModels;

namespace AutoHitCounter.Views.Windows;

public partial class ProfileEditorWindow : Window
{
    public ProfileEditorWindow()
    {
        InitializeComponent();
    }

    protected override void OnClosing(CancelEventArgs e)
    {
        if (DataContext is ProfileEditorViewModel { IsDirty: true })
        {
            var close = MsgBox.ShowOkCancel("You have unsaved changes. Close without saving?", "Unsaved Changes");
            if (!close)
                e.Cancel = true;
        }

        base.OnClosing(e);
    }
}