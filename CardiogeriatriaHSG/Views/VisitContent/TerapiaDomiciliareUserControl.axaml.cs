using Avalonia.Controls;
using Avalonia.Interactivity;
using CardiogeriatriaHSG.Models;
using CardiogeriatriaHSG.ViewModels.VisitContent;

namespace CardiogeriatriaHSG.Views.VisitContent;

public partial class TerapiaDomiciliareUserControl : UserControl
{
    public TerapiaDomiciliareUserControl()
    {
        InitializeComponent();
        DataContextChanged += (_, __) =>
        {
            if (DataContext is TerapiaDomiciliareUserControlViewModel viewModel)
            {
                _currentVisitTd = viewModel.CurrentVisitTd!;
            }
        };
    }
    
    private VisitTd? _currentVisitTd;

    
    public void OnColumnAChanged(object? sender, RoutedEventArgs routedEventArgs)
    {
        var box = sender as CheckBox;
        var value = box!.IsChecked.ToString();
        
        _currentVisitTd!.Furosemide = value == "True";
        if (_currentVisitTd.Furosemide)
        {
            _currentVisitTd.FurosemideDose ??= 0;
            FurosemideDoseWrapPanel.IsVisible = true;
        }
        else
        {
            _currentVisitTd.FurosemideDose = null;
            FurosemideDoseWrapPanel.IsVisible = false;
        }
    }
}