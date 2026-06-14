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
            var esamiEmaticiUserControl = new EsamiEmaticiUserControl();
            esamiEmaticiUserControl.LoadEsamiEmaticiContent(currentVisit.VisitEe!);
            var esamiObiettivoUserControl = new EsamiObiettivoUserControl();
            esamiObiettivoUserControl.LoadEsamiObiettivoContent(currentVisit.VisitEo!);
            var ecografiaToracicaUserControl = new EcografiaToracicaUserControl();
            ecografiaToracicaUserControl.LoadEcografiaToracicaContent(currentVisit.VisitEco!);
            Dispatcher.UIThread.Post(() => { 
                AnagraficaContent.Text = anagraficaUserControl.ColumnBDescription.Text;
                AnamnesiGeriatricaContent.Text = anamnesiGeriatricaUserControl.ColumnBDescription.Text;
                AnamnesiPatologicaRemotaContent.Text = currentVisit.VisitApr!.AprText;
                TerapiaDomiciliareContent.Text = currentVisit.VisitTd!.TdText;
                RaccordoClinicoContent.Text = raccordoClinicoUserControl.ColumnBDescription.Text;
                EsamiEmaticiContent.Text = esamiEmaticiUserControl.ColumnBDescription.Text;
                EsamiObiettivoContent.Text = esamiObiettivoUserControl.ColumnBDescription.Text;
                EcografiaToracicaContent.Text = currentVisit.VisitEco!.EcoManualText is null || currentVisit.VisitEco!.EcoManualText.Trim().Length == 0 
                    ? ecografiaToracicaUserControl.AutomaticColumnB.Text : currentVisit.VisitEco!.EcoManualText;
            });
        };
    }
}