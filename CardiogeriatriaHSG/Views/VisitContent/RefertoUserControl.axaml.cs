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
            var currentVisit = vm.CurrentVisit;
            
            //Loading self text sections first
            var anagraficaUserControl = new AnagraficaUserControl();
            anagraficaUserControl.LoadAnagraficaContent(currentVisit.Patient!, currentVisit.Timestamp);
            var anamnesiGeriatricaUserControl = new AnamnesiGeriatricaUserControl();
            anamnesiGeriatricaUserControl.LoadAnamnesiGeriatricaContent(currentVisit.VisitAg!);
            var raccordoClinicoUserControl = new RaccordoClinicoUserControl();
            raccordoClinicoUserControl.LoadRaccordoClinicoContent(currentVisit.VisitRc!);
            Dispatcher.UIThread.Post(() => { 
                AnagraficaContent.Text = anagraficaUserControl.ColumnBDescription.Text;
                AnamnesiGeriatricaContent.Text = anamnesiGeriatricaUserControl.ColumnBDescription.Text;
                AnamnesiPatologicaRemotaContent.Text = currentVisit.VisitApr!.AprText;
                TerapiaDomiciliareContent.Text = currentVisit.VisitTd!.TdText;
                RaccordoClinicoContent.Text = raccordoClinicoUserControl.ColumnBDescription.Text;
            });
        };
    }
}