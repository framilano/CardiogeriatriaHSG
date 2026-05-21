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
            
            var anagraficaUserControl = new AnagraficaUserControl();
            anagraficaUserControl.LoadAnagraficaContent(currentVisit);
            var anamnesiGeriatricaUserControl = new AnamnesiGeriatricaUserControl();
            anamnesiGeriatricaUserControl.LoadAnamnesiGeriatricaContent(currentVisit);
            var raccordoClinicoUserControl = new RaccordoClinicoUserControl();
            raccordoClinicoUserControl.LoadRaccordoClinicoContent(currentVisit);
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