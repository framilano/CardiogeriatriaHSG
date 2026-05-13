using System.Linq;
using System.Text.RegularExpressions;
using CommunityToolkit.Mvvm.ComponentModel;
using CardiogeriatriaHSG.Models;
using CardiogeriatriaHSG.Models.enums.terapiadomiciliare;

namespace CardiogeriatriaHSG.ViewModels.VisitContent;

public partial class TerapiaDomiciliareUserControlViewModel(Visit currentVisit) : ObservableObject
{
    [ObservableProperty]
    private Visit _currentVisit = currentVisit;
    

    public void InferColumnBValues()
    {
        if (CurrentVisit.VisitTd!.TdText is null  || string.IsNullOrEmpty(CurrentVisit.VisitTd.TdText)) return;
        
        if (Synonyms.IschemicHeartDiseaseSynonyms.Any(word => Regex.IsMatch(CurrentVisit.VisitApr.AprText, $@"\b{word}\b", RegexOptions.IgnoreCase)))
        { CurrentVisit.VisitApr.IschemicHeartDisease = true; }
    }
}