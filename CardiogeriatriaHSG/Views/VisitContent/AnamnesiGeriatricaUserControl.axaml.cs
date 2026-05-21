using System.Text;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using CardiogeriatriaHSG.Models;
using CardiogeriatriaHSG.ViewModels.VisitContent;

namespace CardiogeriatriaHSG.Views.VisitContent;

public partial class AnamnesiGeriatricaUserControl : UserControl
{
    public AnamnesiGeriatricaUserControl()
    {
        InitializeComponent();
        _columnBDescription = this.Find<TextBlock>("ColumnBDescription");
        DataContextChanged += (_, __) =>
        {
            if (DataContext is not AnamnesiGeriatricaUserControlViewModel viewModel) return;
            _currentVisit = viewModel.CurrentVisit!;
            LoadAnamnesiGeriatricaContent(_currentVisit);
        };
    }
    
    private Visit? _currentVisit;
    private readonly TextBlock? _columnBDescription;

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
                _currentVisit!.VisitAg!.AssistanceAlone = value == "True";
                UpdateAssistanceSentence();
                break;
            case "AssistanceSpouse":
                _currentVisit!.VisitAg!.AssistanceSpouse = value == "True";
                UpdateAssistanceSentence();
                break;
            case "AssistanceFamilyMembers":
                _currentVisit!.VisitAg!.AssistanceFamilyMembers = value == "True";
                UpdateAssistanceSentence();
                break;
            case "CareTaker":
                _currentVisit!.VisitAg!.CareTaker = value == "True";
                UpdateAssistanceSentence();
                break;
            case "MotorSkill":
                _currentVisit!.VisitAg!.MotorSkill = value!;
                if (_currentVisit!.VisitAg!.MotorSkill is not "Solo letto-poltrona")
                {
                    _currentVisit.VisitAg.WalkingType ??= "Autonoma senza ausili";
                    WalkingTypeWrapPanel.IsVisible = true;
                }
                else
                {
                    _currentVisit!.VisitAg!.WalkingType = null;
                    WalkingTypeWrapPanel.IsVisible = false;
                }
                UpdateWalkingSentence();
                break;
            case "WalkingType":
                _currentVisit!.VisitAg!.WalkingType = value!;
                UpdateWalkingSentence();
                break;
            case "Falls":
                _currentVisit!.VisitAg!.Falls = value!;
                UpdateFallsSentence();
                break;
            case "CognitiveDeficit":
                _currentVisit!.VisitAg!.CognitiveDeficit = value!;
                UpdateCognitiveDeficitSentence();
                break;
            case "Bpsd":
                _currentVisit!.VisitAg!.Bpsd = value == "True";
                UpdateBpsdSentence();
                break;
            case "HearingImpairment":
                _currentVisit!.VisitAg!.HearingImpairment = value == "True";
                UpdateImpairmentSentence();
                break;
            case "VisualImpairment":
                _currentVisit!.VisitAg!.VisualImpairment = value == "True";
                UpdateImpairmentSentence();
                break;
            case "Nights":
                _currentVisit!.VisitAg!.Nights = value!;
                UpdateNightsSentence();
                break;
            case "WeightLoss":
                _currentVisit!.VisitAg!.WeightLoss = value!;
                UpdateWeightLossSentence();
                break;
            case "Appetite":
                _currentVisit!.VisitAg!.Appetite = value!;
                UpdateWeightLossSentence();
                break;
            case "Dysphagia":
                _currentVisit!.VisitAg!.Dysphagia = value!;
                UpdateWeightLossSentence();
                break;
            case "Constipation":
                _currentVisit!.VisitAg!.Constipation = value == "True";
                UpdateConstipationSentence();
                break;
            case "Disability":
                _currentVisit!.VisitAg!.Disability = value == "True";
                UpdateDisabilitySentence();
                break;
        }
        
        UpdateColumnBDescription();
    }
    
    private void UpdateAssistanceSentence()
    {
        var assistanceSentenceBuilder = new StringBuilder();
        assistanceSentenceBuilder.Append("Vive a domicilio");
        if (_currentVisit!.VisitAg!.AssistanceAlone) assistanceSentenceBuilder.Append(", da solo");
        if (_currentVisit!.VisitAg!.AssistanceSpouse) assistanceSentenceBuilder.Append(", con coniuge");
        if (_currentVisit!.VisitAg!.AssistanceFamilyMembers) assistanceSentenceBuilder.Append(", con familiari");
        if (_currentVisit!.VisitAg!.CareTaker) assistanceSentenceBuilder.Append(" e con badante");
        assistanceSentenceBuilder.Append('.');
        assistanceSentenceBuilder.Append('\n');
        _assistanceSentence = assistanceSentenceBuilder.ToString();
    }
    
    private void UpdateWalkingSentence()
    {
        var walkingSentenceBuilder = new StringBuilder();
        switch (_currentVisit!.VisitAg!.MotorSkill)
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
        walkingSentenceBuilder.Append(_currentVisit.VisitAg.WalkingType!.ToLower());
        walkingSentenceBuilder.Append('.');
        walkingSentenceBuilder.Append('\n');
        _walkingSentence = walkingSentenceBuilder.ToString();
    }
    
    private void UpdateFallsSentence()
    {
        var fallsSentenceBuilder = new StringBuilder();
        if (_currentVisit!.VisitAg!.Falls == "0") fallsSentenceBuilder.Append("Non riferite cadute negli ultimi 6 mesi");
        else if (_currentVisit!.VisitAg!.Falls == "1") fallsSentenceBuilder.Append("Riferita 1 caduta negli ultimi 6 mesi");
        else if (_currentVisit!.VisitAg!.Falls == "2") fallsSentenceBuilder.Append("Riferite 2 cadute negli ultimi 6 mesi");
        else fallsSentenceBuilder.Append("Riferite 3 o più cadute negli ultimi 6 mesi");

        fallsSentenceBuilder.Append('.');
        fallsSentenceBuilder.Append('\n');
        _fallsSentence = fallsSentenceBuilder.ToString();
    }
    
    private void UpdateCognitiveDeficitSentence()
    {
        var cognitiveDeficitSentenceBuilder = new StringBuilder();
        if (_currentVisit!.VisitAg!.CognitiveDeficit == "Nessuno") cognitiveDeficitSentenceBuilder.Append("Nessun decadimento cognitivo");
        else if (_currentVisit!.VisitAg!.CognitiveDeficit == "Iniziali") cognitiveDeficitSentenceBuilder.Append("Iniziali deficit cognitivi");
        else cognitiveDeficitSentenceBuilder.Append("Noti deficit cognitivi");

        cognitiveDeficitSentenceBuilder.Append('.');
        cognitiveDeficitSentenceBuilder.Append('\n');
        _cognitiveDeficitSentence = cognitiveDeficitSentenceBuilder.ToString();
    }

    private void UpdateBpsdSentence()
    {
        var bpsdSentenceBuilder = new StringBuilder();
        if (_currentVisit!.VisitAg!.Bpsd) bpsdSentenceBuilder.Append("Noti BPSD");
        else bpsdSentenceBuilder.Append("Non BPSD");

        bpsdSentenceBuilder.Append('.');
        bpsdSentenceBuilder.Append('\n');
        _bpsdSentence = bpsdSentenceBuilder.ToString();
    }
    
    private void UpdateImpairmentSentence()
    {
        var impairmentSentenceBuilder = new StringBuilder();
        if (_currentVisit!.VisitAg!.HearingImpairment) impairmentSentenceBuilder.Append("Affetto da ipoacusia e ");
        else  impairmentSentenceBuilder.Append("Non affetto da ipoacusia e ");
        if (_currentVisit!.VisitAg!.VisualImpairment) impairmentSentenceBuilder.Append("affetto da ipovisus");
        else  impairmentSentenceBuilder.Append("non affetto da ipovisus");
        impairmentSentenceBuilder.Append('.');
        impairmentSentenceBuilder.Append('\n');
        _impairmentSentence = impairmentSentenceBuilder.ToString();
    }
    
    private void UpdateNightsSentence()
    {
        var nightsSentenceBuilder = new StringBuilder();
        nightsSentenceBuilder.Append("Notti ");
        nightsSentenceBuilder.Append(_currentVisit!.VisitAg!.Nights!.ToLower());
        nightsSentenceBuilder.Append('.');
        nightsSentenceBuilder.Append('\n');
        _nightsSentence = nightsSentenceBuilder.ToString();
    }
    
    private void UpdateWeightLossSentence()
    {
        var weightLossSentenceBuilder = new StringBuilder();
        //WeightLoss
        weightLossSentenceBuilder.Append("Negli ultimi 3 mesi ");
        if (_currentVisit!.VisitAg!.WeightLoss == "No") weightLossSentenceBuilder.Append("nessuna perdita di peso, ");
        else if (_currentVisit!.VisitAg!.WeightLoss == "1-3 Kg") weightLossSentenceBuilder.Append("persi dagli 1 ai 3 Kg, ");
        else if (_currentVisit!.VisitAg!.WeightLoss == "Non noto") weightLossSentenceBuilder.Append("non è nota alcuna perdita di peso, ");
        else  weightLossSentenceBuilder.Append("sono stati persi più di 3 Kg, ");
        
        //Appetite
        weightLossSentenceBuilder.Append("con appetito ");
        weightLossSentenceBuilder.Append(_currentVisit!.VisitAg!.Appetite!.ToLower());
        weightLossSentenceBuilder.Append(", ");

        //Dysphagia
        if (_currentVisit!.VisitAg!.Dysphagia == "No") weightLossSentenceBuilder.Append("nessuna disfagia");
        else
        {
            weightLossSentenceBuilder.Append("disfagia ");
            weightLossSentenceBuilder.Append(_currentVisit!.VisitAg!.Dysphagia!.ToLower());
        }

        weightLossSentenceBuilder.Append('.');
        weightLossSentenceBuilder.Append('\n');
        _weightLossSentence = weightLossSentenceBuilder.ToString();
    }

    private void UpdateConstipationSentence()
    {        
        var constipationSentenceBuilder = new StringBuilder();
        
        constipationSentenceBuilder.Append("Alvo ");
        if (_currentVisit!.VisitAg!.Constipation) constipationSentenceBuilder.Append("stitico");
        else constipationSentenceBuilder.Append("regolare");
        
        constipationSentenceBuilder.Append('.');
        constipationSentenceBuilder.Append('\n');
        _constipationSentence = constipationSentenceBuilder.ToString();
    }

    private void UpdateDisabilitySentence()
    {
        var disabilitySentenceBuilder = new StringBuilder();
        
        if (_currentVisit!.VisitAg!.Disability) disabilitySentenceBuilder.Append("In possesso di IC");
        else disabilitySentenceBuilder.Append("Non in possesso di IC");
        
        disabilitySentenceBuilder.Append('.');
        _disabilitySentence = disabilitySentenceBuilder.ToString();
    }
    
    public void LoadAnamnesiGeriatricaContent(Visit currentVisit)
    {
        _currentVisit = currentVisit;
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

        Dispatcher.UIThread.Post(() => { _columnBDescription!.Text = columnBDescriptionStringBuilder.ToString(); });
    }
}