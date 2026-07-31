using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using CardiogeriatriaHSG.Models;
using CardiogeriatriaHSG.ViewModels.VisitContent;

namespace CardiogeriatriaHSG.Views.VisitContent;

public partial class TerapiaFineVisitaUserControl : UserControl
{
    public TerapiaFineVisitaUserControl()
    {
        InitializeComponent();
        DataContextChanged += (_, __) =>
        {
            if (DataContext is TerapiaFineVisitaUserControlViewModel viewModel)
            {
                _currentVisitTfv = viewModel.CurrentVisitTfv!;
            }
        };
    }
    
    private VisitTfv? _currentVisitTfv;

    
    public void OnColumnAChanged(object? sender, RoutedEventArgs routedEventArgs)
    {
        var box = sender as CheckBox;
        var value = box!.IsChecked.ToString();
        
        _currentVisitTfv!.Furosemide = value == "True";
        if (_currentVisitTfv.Furosemide)
        {
            _currentVisitTfv.FurosemideDose ??= 0;
            Dispatcher.UIThread.Post(() => FurosemideDoseWrapPanel.IsVisible = true);
        }
        else
        {
            _currentVisitTfv.FurosemideDose = null;
            Dispatcher.UIThread.Post(() => FurosemideDoseWrapPanel.IsVisible = false);
        }
    }
}