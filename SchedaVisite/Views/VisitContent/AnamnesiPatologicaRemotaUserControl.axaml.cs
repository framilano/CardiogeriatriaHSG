using Avalonia.Controls;
using SchedaVisite.Models;
using SchedaVisite.ViewModels.VisitContent;

namespace SchedaVisite.Views.VisitContent;

public partial class AnamnesiPatologicaRemotaUserControl : UserControl
{
    public AnamnesiPatologicaRemotaUserControl()
    {
        InitializeComponent();
        _columnBDescription = this.Find<TextBox>("ColumnBDescription");
        DataContextChanged += (_, __) =>
        {
            if (DataContext is AnamnesiPatologicaRemotaUserControlViewModel viewModel)
            {
                _currentVisit = viewModel.CurrentVisit!;
            }
        };
    }
    
    private Visit? _currentVisit;
    private readonly TextBox? _columnBDescription;
}