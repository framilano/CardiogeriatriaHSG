using Avalonia.Controls;
using Avalonia.Threading;
using SchedaVisite.Models;
using SchedaVisite.ViewModels;
using SchedaVisite.ViewModels.VisitContent;

namespace SchedaVisite.Views.VisitContent;

public partial class RefertoUserControl : UserControl
{
    public RefertoUserControl()
    {
        InitializeComponent();
        _columnDescription = this.Find<TextBlock>("ColumnDescription");
        DataContextChanged += (_, __) =>
        {
            if (DataContext is not RefertoUserControlViewModel vm) return;
            var currentVisit = vm.CurrentVisit!;
            var currentPatient = vm.CurrentPatient!;
            
            var anagraficaUserControl = new AnagraficaUserControl();
            anagraficaUserControl.LoadAnagraficaContent(currentVisit, currentPatient);
            _columnDescription!.Text = anagraficaUserControl.ColumnBDescription.Text;
            
            var anamnesiGeriatrica = new AnamnesiGeriatricaUserControl();
            anamnesiGeriatrica.LoadAnamnesiGeriatricaContent(currentVisit);
            Dispatcher.UIThread.Post(() => { _columnDescription!.Text = anagraficaUserControl.ColumnBDescription.Text +
                                                                        anamnesiGeriatrica.ColumnBDescription.Text; 
            });
        };
    }
    
    private readonly TextBlock? _columnDescription;
}