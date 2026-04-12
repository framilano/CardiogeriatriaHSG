using System.Collections.ObjectModel;

namespace SchedaVisite.ViewModels;

public class SidebarUserControlViewModel
{
    public ObservableCollection<string> VerticalMenu { get; } =
        new()
        {
            "Anagrafica", 
            "Anamnesi geriatrica", 
            "APR",
            "Terapia domiciliare", 
            "Raccordo clinico", 
            "EO + ECO",
            "CGA", 
            "Conclusioni", 
            "Terapia fine visita",
            "Consigli"
        };
}