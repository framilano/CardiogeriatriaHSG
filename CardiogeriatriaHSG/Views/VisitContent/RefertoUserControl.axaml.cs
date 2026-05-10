using Avalonia.Controls;
using Avalonia.Threading;
using CardiogeriatriaHSG.ViewModels.VisitContent;

namespace CardiogeriatriaHSG.Views.VisitContent;

public partial class RefertoUserControl : UserControl
{
    public RefertoUserControl()
    {
        InitializeComponent();
        DataContextChanged += (_, __) =>
        {
            if (DataContext is not RefertoUserControlViewModel vm) return;
            var currentVisit = vm.CurrentVisit!;
            var currentPatient = vm.CurrentPatient!;
            
            var anagraficaUserControl = new AnagraficaUserControl();
            anagraficaUserControl.LoadAnagraficaContent(currentVisit, currentPatient);
            var anamnesiGeriatricaUserControl = new AnamnesiGeriatricaUserControl();
            anamnesiGeriatricaUserControl.LoadAnamnesiGeriatricaContent(currentVisit);
            Dispatcher.UIThread.Post(() => { 
                AnagraficaContent.Text = anagraficaUserControl.ColumnBDescription.Text;
                AnamnesiGeriatricaContent.Text = anamnesiGeriatricaUserControl.ColumnBDescription.Text;
                AnamnesiPatologicaRemotaContent.Text = currentVisit.VisitPersistedTexts!.AprText;
            });
        };
    }
}