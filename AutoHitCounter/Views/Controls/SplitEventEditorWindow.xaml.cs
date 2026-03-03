using System.Windows;
using AutoHitCounter.ViewModels;

namespace AutoHitCounter.Views.Controls;


public partial class SplitEventEditorWindow : Window
{
    public SplitEventEditorWindow()
    {
        InitializeComponent();
    }

    public void SetViewModel(SplitEventEditorViewModel vm)
    {
        DataContext = vm;
        vm.RequestClose = Close;
    }
}