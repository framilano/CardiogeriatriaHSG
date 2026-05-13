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
                _currentVisit = viewModel.CurrentVisit!;
            }
        };
    }
    
    public void OnColumnAChanged(object? sender, RoutedEventArgs routedEventArgs)
    {
        var box = sender as CheckBox;
        var value = box!.IsChecked.ToString();
        
        _currentVisit!.VisitTd!.Furosemide = value == "True";
        if (_currentVisit!.VisitTd!.Furosemide)
        {
            _currentVisit.VisitTd.FurosemideDose ??= 0;
            FurosemideDoseWrapPanel.IsVisible = true;
        }
        else
        {
            _currentVisit.VisitTd.FurosemideDose = null;
            FurosemideDoseWrapPanel.IsVisible = false;
        }
    }
    
    private Visit? _currentVisit;
}