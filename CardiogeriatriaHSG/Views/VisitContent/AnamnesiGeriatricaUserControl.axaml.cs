using System.Text;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using CardiogeriatriaHSG.Models;
using CardiogeriatriaHSG.Models.enums;
using CardiogeriatriaHSG.ViewModels.VisitContent;

namespace CardiogeriatriaHSG.Views.VisitContent;

public partial class AnamnesiGeriatricaUserControl : UserControl
{
    public AnamnesiGeriatricaUserControl()
    {
        InitializeComponent();
        DataContextChanged += (_, __) =>
        {
            if (DataContext is not AnamnesiGeriatricaUserControlViewModel viewModel) return;
            _currentVisitAg = viewModel.CurrentVisitAg;
            LoadAnamnesiGeriatricaContent(_currentVisitAg);
        };
    }
    
    private VisitAg? _currentVisitAg;

    private string? _assistanceSentence;
    private string? _walkingSentence;
    private string? _fallsSentence;
    private string? _cognitiveDeficitSentence;
    private string? _bpsdSentence;
    private string? _impairmentSentence;
    private string? _nightsSentence;
    private string? _weightLossSentence;
    private string? _constipationSentence;
    private string? _disabilitySentence;

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
                _currentVisitAg!.AssistanceAlone = value == "True";
                UpdateAssistanceSentence();
                break;
            case "AssistanceSpouse":
                _currentVisitAg!.AssistanceSpouse = value == "True";
                UpdateAssistanceSentence();
                break;
            case "AssistanceFamilyMembers":
                _currentVisitAg!.AssistanceFamilyMembers = value == "True";
                UpdateAssistanceSentence();
                break;
            case "CareTaker":
                _currentVisitAg!.CareTaker = value == "True";
                UpdateAssistanceSentence();
                break;
            case "MotorSkill":
                _currentVisitAg!.MotorSkill = value!;
                if (_currentVisitAg!.MotorSkill != StringChoices.MotorSkillTypes[0])
                {
                    _currentVisitAg!.WalkingType ??= StringChoices.WalkingTypes[0];
                    Dispatcher.UIThread.Post(() => WalkingTypeWrapPanel.IsVisible = true);
                }
                else
                {
                    _currentVisitAg!.WalkingType = null;
                    Dispatcher.UIThread.Post(() => WalkingTypeWrapPanel.IsVisible = false);
                }
                UpdateWalkingSentence();
                break;
            case "WalkingType":
                _currentVisitAg!.WalkingType = value!;
                UpdateWalkingSentence();
                break;
            case "Falls":
                _currentVisitAg!.Falls = value!;
                UpdateFallsSentence();
                break;
            case "CognitiveDeficit":
                _currentVisitAg!.CognitiveDeficit = value!;
                UpdateCognitiveDeficitSentence();
                break;
            case "Bpsd":
                _currentVisitAg!.Bpsd = value == "True";
                UpdateBpsdSentence();
                break;
            case "HearingImpairment":
                _currentVisitAg!.HearingImpairment = value == "True";
                UpdateImpairmentSentence();
                break;
            case "VisualImpairment":
                _currentVisitAg!.VisualImpairment = value == "True";
                UpdateImpairmentSentence();
                break;
            case "Nights":
                _currentVisitAg!.Nights = value!;
                UpdateNightsSentence();
                break;
            case "WeightLoss":
                _currentVisitAg!.WeightLoss = value!;
                UpdateWeightLossSentence();
                break;
            case "Appetite":
                _currentVisitAg!.Appetite = value!;
                UpdateWeightLossSentence();
                break;
            case "Dysphagia":
                _currentVisitAg!.Dysphagia = value!;
                UpdateWeightLossSentence();
                break;
            case "Constipation":
                _currentVisitAg!.Constipation = value == "True";
                UpdateConstipationSentence();
                break;
            case "Disability":
                _currentVisitAg!.Disability = value == "True";
                UpdateDisabilitySentence();
                break;
        }
        
        UpdateColumnBDescription();
    }
    
    private void UpdateAssistanceSentence()
    {
        var assistanceSentenceBuilder = new StringBuilder();
        assistanceSentenceBuilder.Append("Vive a domicilio");
        if (_currentVisitAg!.AssistanceAlone) assistanceSentenceBuilder.Append(", da solo");
        if (_currentVisitAg!.AssistanceSpouse) assistanceSentenceBuilder.Append(", con coniuge");
        if (_currentVisitAg!.AssistanceFamilyMembers) assistanceSentenceBuilder.Append(", con familiari");
        if (_currentVisitAg!.CareTaker) assistanceSentenceBuilder.Append(" e con badante");
        assistanceSentenceBuilder.Append('.');
        assistanceSentenceBuilder.Append('\n');
        _assistanceSentence = assistanceSentenceBuilder.ToString();
    }
    
    private void UpdateWalkingSentence()
    {
        var walkingSentenceBuilder = new StringBuilder();
        switch (_currentVisitAg!.MotorSkill)
        {
            case "Solo letto-poltrona":
                walkingSentenceBuilder.Append("Vita di risparmio, spostamenti solo letto-poltrona");
                walkingSentenceBuilder.Append('.');
                walkingSentenceBuilder.Append('\n');
                _walkingSentence = walkingSentenceBuilder.ToString();
                return;
            case "Esce solo":
                walkingSentenceBuilder.Append("Esce di casa ");
                break;
            default:
                walkingSentenceBuilder.Append("Autonomo entro le mura domestiche ");
                break;
        }

        walkingSentenceBuilder.Append(" e ");
        walkingSentenceBuilder.Append("deambulazione ");
        walkingSentenceBuilder.Append(_currentVisitAg!.WalkingType!.ToLower());
        walkingSentenceBuilder.Append('.');
        walkingSentenceBuilder.Append('\n');
        _walkingSentence = walkingSentenceBuilder.ToString();
    }
    
    private void UpdateFallsSentence()
    {
        var fallsSentenceBuilder = new StringBuilder();
        if (_currentVisitAg!.Falls == "0") fallsSentenceBuilder.Append("Non riferite cadute negli ultimi 6 mesi");
        else if (_currentVisitAg!.Falls == "1") fallsSentenceBuilder.Append("Riferita 1 caduta negli ultimi 6 mesi");
        else if (_currentVisitAg!.Falls == "2") fallsSentenceBuilder.Append("Riferite 2 cadute negli ultimi 6 mesi");
        else fallsSentenceBuilder.Append("Riferite 3 o più cadute negli ultimi 6 mesi");

        fallsSentenceBuilder.Append('.');
        fallsSentenceBuilder.Append('\n');
        _fallsSentence = fallsSentenceBuilder.ToString();
    }
    
    private void UpdateCognitiveDeficitSentence()
    {
        var cognitiveDeficitSentenceBuilder = new StringBuilder();
        if (_currentVisitAg!.CognitiveDeficit == "Nessuno") cognitiveDeficitSentenceBuilder.Append("Nessun decadimento cognitivo");
        else if (_currentVisitAg!.CognitiveDeficit == "Iniziali") cognitiveDeficitSentenceBuilder.Append("Iniziali deficit cognitivi");
        else cognitiveDeficitSentenceBuilder.Append("Noti deficit cognitivi");

        cognitiveDeficitSentenceBuilder.Append('.');
        cognitiveDeficitSentenceBuilder.Append('\n');
        _cognitiveDeficitSentence = cognitiveDeficitSentenceBuilder.ToString();
    }

    private void UpdateBpsdSentence()
    {
        var bpsdSentenceBuilder = new StringBuilder();
        if (_currentVisitAg!.Bpsd) bpsdSentenceBuilder.Append("Noti BPSD");
        else bpsdSentenceBuilder.Append("Non BPSD");

        bpsdSentenceBuilder.Append('.');
        bpsdSentenceBuilder.Append('\n');
        _bpsdSentence = bpsdSentenceBuilder.ToString();
    }
    
    private void UpdateImpairmentSentence()
    {
        var impairmentSentenceBuilder = new StringBuilder();
        if (_currentVisitAg!.HearingImpairment) impairmentSentenceBuilder.Append("Affetto da ipoacusia e ");
        else  impairmentSentenceBuilder.Append("Non affetto da ipoacusia e ");
        if (_currentVisitAg!.VisualImpairment) impairmentSentenceBuilder.Append("affetto da ipovisus");
        else  impairmentSentenceBuilder.Append("non affetto da ipovisus");
        impairmentSentenceBuilder.Append('.');
        impairmentSentenceBuilder.Append('\n');
        _impairmentSentence = impairmentSentenceBuilder.ToString();
    }
    
    private void UpdateNightsSentence()
    {
        var nightsSentenceBuilder = new StringBuilder();
        nightsSentenceBuilder.Append("Notti ");
        nightsSentenceBuilder.Append(_currentVisitAg!.Nights!.ToLower());
        nightsSentenceBuilder.Append('.');
        nightsSentenceBuilder.Append('\n');
        _nightsSentence = nightsSentenceBuilder.ToString();
    }
    
    private void UpdateWeightLossSentence()
    {
        var weightLossSentenceBuilder = new StringBuilder();
        //WeightLoss
        weightLossSentenceBuilder.Append("Negli ultimi 3 mesi ");
        if (_currentVisitAg!.WeightLoss == "No") weightLossSentenceBuilder.Append("nessuna perdita di peso, ");
        else if (_currentVisitAg!.WeightLoss == "1-3 Kg") weightLossSentenceBuilder.Append("persi dagli 1 ai 3 Kg, ");
        else if (_currentVisitAg!.WeightLoss == "Non noto") weightLossSentenceBuilder.Append("non è nota alcuna perdita di peso, ");
        else  weightLossSentenceBuilder.Append("sono stati persi più di 3 Kg, ");
        
        //Appetite
        weightLossSentenceBuilder.Append("con appetito ");
        weightLossSentenceBuilder.Append(_currentVisitAg!.Appetite!.ToLower());
        weightLossSentenceBuilder.Append(", ");

        //Dysphagia
        if (_currentVisitAg!.Dysphagia == "No") weightLossSentenceBuilder.Append("nessuna disfagia");
        else
        {
            weightLossSentenceBuilder.Append("disfagia ");
            weightLossSentenceBuilder.Append(_currentVisitAg!.Dysphagia!.ToLower());
        }

        weightLossSentenceBuilder.Append('.');
        weightLossSentenceBuilder.Append('\n');
        _weightLossSentence = weightLossSentenceBuilder.ToString();
    }

    private void UpdateConstipationSentence()
    {        
        var constipationSentenceBuilder = new StringBuilder();
        
        constipationSentenceBuilder.Append("Alvo ");
        if (_currentVisitAg!.Constipation) constipationSentenceBuilder.Append("stitico");
        else constipationSentenceBuilder.Append("regolare");
        
        constipationSentenceBuilder.Append('.');
        constipationSentenceBuilder.Append('\n');
        _constipationSentence = constipationSentenceBuilder.ToString();
    }

    private void UpdateDisabilitySentence()
    {
        var disabilitySentenceBuilder = new StringBuilder();
        
        if (_currentVisitAg!.Disability) disabilitySentenceBuilder.Append("In possesso di IC");
        else disabilitySentenceBuilder.Append("Non in possesso di IC");
        
        disabilitySentenceBuilder.Append('.');
        _disabilitySentence = disabilitySentenceBuilder.ToString();
    }
    
    public void LoadAnamnesiGeriatricaContent(VisitAg currentVisitAg)
    {
        _currentVisitAg = currentVisitAg;
        UpdateAssistanceSentence();
        UpdateWalkingSentence();
        UpdateFallsSentence();
        UpdateCognitiveDeficitSentence();
        UpdateBpsdSentence();
        UpdateImpairmentSentence();
        UpdateNightsSentence();
        UpdateWeightLossSentence();
        UpdateConstipationSentence();
        UpdateDisabilitySentence();
        
        UpdateColumnBDescription();
    }

    private void UpdateColumnBDescription()
    {
        var columnBDescriptionStringBuilder = new StringBuilder();
        columnBDescriptionStringBuilder.Append(_assistanceSentence);
        columnBDescriptionStringBuilder.Append(_walkingSentence);
        columnBDescriptionStringBuilder.Append(_fallsSentence);
        columnBDescriptionStringBuilder.Append(_cognitiveDeficitSentence);
        columnBDescriptionStringBuilder.Append(_bpsdSentence);
        columnBDescriptionStringBuilder.Append(_impairmentSentence);
        columnBDescriptionStringBuilder.Append(_nightsSentence);
        columnBDescriptionStringBuilder.Append(_weightLossSentence);
        columnBDescriptionStringBuilder.Append(_constipationSentence);
        columnBDescriptionStringBuilder.Append(_disabilitySentence);

        Dispatcher.UIThread.Post(() => { AutomaticColumnB!.Text = columnBDescriptionStringBuilder.ToString(); });
    }
    
    private void CopyToManualText(object? sender, RoutedEventArgs routedEventArgs)
    {
        _currentVisitAg!.AgManualText = AutomaticColumnB.Text;
    }
}