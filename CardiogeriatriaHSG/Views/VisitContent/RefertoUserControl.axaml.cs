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
                //Anagrafica
                AnagraficaContent.Text = currentVisit.Patient!.PatientManualText is null || currentVisit.Patient!.PatientManualText.Trim().Length == 0 
                    ? anagraficaUserControl.AutomaticColumnB.Text : currentVisit.Patient!.PatientManualText;
                
                //Anamnesi Geriatrica
                AnamnesiGeriatricaContent.Text = currentVisit.VisitAg!.AgManualText is null || currentVisit.VisitAg!.AgManualText.Trim().Length == 0 
                    ? anamnesiGeriatricaUserControl.AutomaticColumnB.Text : currentVisit.VisitAg!.AgManualText;
                
                //Anamnesi Patologica
                AnamnesiPatologicaRemotaContent.Text = currentVisit.VisitApr!.AprText;
                
                //Terapia Domiciliare
                TerapiaDomiciliareContent.Text = currentVisit.VisitTd!.TdText;
                
                //Raccordo Clinico
                RaccordoClinicoContent.Text = currentVisit.VisitRc!.RcManualText is null || currentVisit.VisitRc!.RcManualText.Trim().Length == 0 
                    ? raccordoClinicoUserControl.AutomaticColumnB.Text : currentVisit.VisitRc!.RcManualText;
                
                //Esami Ematici
                EsamiEmaticiContent.Text = esamiEmaticiUserControl.AutomaticColumnB.Text;
                
                //Esami Obiettivo
                EsamiObiettivoContent.Text = esamiObiettivoUserControl.AutomaticColumnB.Text;
                
                //Ecografia Toracica
                EcografiaToracicaContent.Text = currentVisit.VisitEco!.EcoManualText is null || currentVisit.VisitEco!.EcoManualText.Trim().Length == 0 
                    ? ecografiaToracicaUserControl.AutomaticColumnB.Text : currentVisit.VisitEco!.EcoManualText;
            });
        };
    }
}