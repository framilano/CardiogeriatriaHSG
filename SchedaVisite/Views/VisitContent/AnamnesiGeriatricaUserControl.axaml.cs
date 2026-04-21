using System;
using System.Text;
using Avalonia.Controls;
using Avalonia.Interactivity;
using SchedaVisite.Models;
using SchedaVisite.ViewModels.VisitContent;

namespace SchedaVisite.Views.VisitContent;

public partial class AnamnesiGeriatricaUserControl : UserControl
{
    public AnamnesiGeriatricaUserControl()
    {
        InitializeComponent();
        _columnBDescription = this.Find<TextBlock>("ColumnBDescription");
        DataContextChanged += (_, __) =>
        {
            if (DataContext is AnamnesiGeriatricaUserControlViewModel vm)
            {
                _currentVisit = vm.CurrentVisit!;
            }
        };
    }

    private Visit? _currentVisit;

    private string _assistanceSentence;
    public string WalkingSentence;
    public string FallsSentence;
    public string CognitiveDeficitSentence;
    public string BpsdSentence;
    public string VisualImpairmentSentence;
    public string HearingImpairmentSentence;
    public string NightsSentence;
    public string WeightLossSentence;
    public string AppetiteSentence;
    public string ConstipationSentence;
    public string DisabilitySentence;

    public void OnColumnAChanged(object? sender, RoutedEventArgs routedEventArgs)
    {
        var tag = "";
        var value = "";
        switch (sender)
        {
            case ComboBox box:
                tag = (string)box.Tag!;
                value = box.SelectedValue?.ToString();
                break;
            case CheckBox box:
                tag = (string)box.Tag!;
                value = box.IsChecked.ToString();
                break;
        }
        
        switch (tag) 
        {
            case "AssistanceAlone":
                _currentVisit!.AssistanceAlone = value == "True";
                UpdateAssistanceSentence();
                break;
            case "AssistanceSpouse":
               _currentVisit!.AssistanceSpouse = value == "True";
                UpdateAssistanceSentence();
                break;
            case "AssistanceFamilyMembers":
               _currentVisit!.AssistanceFamilyMembers = value == "True";
                UpdateAssistanceSentence();
                break;
            case "CareTaker":
               _currentVisit!.CareTaker = value == "True";
                UpdateAssistanceSentence();
                break;
            case "WalkingType":
               _currentVisit!.WalkingType = value!;
                break;
            case "MotorSkill":
               _currentVisit!.MotorSkill = value!;
                break;
            case "Falls":
               _currentVisit!.Falls = value!;
                break;
            case "CognitiveDeficit":
               _currentVisit!.CognitiveDeficit = value!;
                break;
            case "Bpsd":
               _currentVisit!.Bpsd = value == "True";
                break;
            case "HearingImpairment":
               _currentVisit!.HearingImpairment = value == "True";
                break;
            case "VisualImpairment":
               _currentVisit!.VisualImpairment = value == "True";
                break;
            case "Nights":
               _currentVisit!.Nights = value!;
                break;
            case "WeightLoss":
               _currentVisit!.WeightLoss = value!;
                break;
            case "Appetite":
               _currentVisit!.Appetite = value!;
                break;
            case "Dysphagia":
               _currentVisit!.Dysphagia = value!;
                break;
            case "NutrionalProblems":
               _currentVisit!.NutrionalProblems = value == "True";
                break;
            case "Constipation":
               _currentVisit!.Constipation = value == "True";
                break;
            case "Disability":
               _currentVisit!.Disability = value == "True";
                break;
        }
    }

    private void UpdateAssistanceSentence()
    {
        var assistanceSentenceBuilder = new StringBuilder();
        assistanceSentenceBuilder.Append("Vive a domicilio");
        if (_currentVisit!.AssistanceAlone) assistanceSentenceBuilder.Append(", da solo");
        if (_currentVisit!.AssistanceSpouse) assistanceSentenceBuilder.Append(", con coniuge");
        if (_currentVisit!.AssistanceFamilyMembers) assistanceSentenceBuilder.Append(", con familiari");
        if (_currentVisit!.CareTaker) assistanceSentenceBuilder.Append(" e con badante");
        assistanceSentenceBuilder.Append('.');
        _assistanceSentence = assistanceSentenceBuilder.ToString();

        UpdateColumnBDescription();
    }

    private void UpdateColumnBDescription()
    {
        var columnBDescriptionStringBuilder = new StringBuilder();
        columnBDescriptionStringBuilder.Append(_assistanceSentence);

        _columnBDescription!.Text = columnBDescriptionStringBuilder.ToString();
    }
    
    private TextBlock? _columnBDescription;
}