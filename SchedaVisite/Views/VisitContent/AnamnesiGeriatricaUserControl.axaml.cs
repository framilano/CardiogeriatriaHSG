using System;
using System.Text;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using SchedaVisite.Models;
using SchedaVisite.Models.enums.anamnesigeriatrica;
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
            if (DataContext is AnamnesiGeriatricaUserControlViewModel viewModel)
            {
                _currentVisit = viewModel.CurrentVisit!;
                LoadAnamnesiGeriatricaContent(_currentVisit);
            }
        };
    }

    private AnamnesiGeriatricaUserControlViewModel _anamViewModel;

    private Visit? _currentVisit;
    private readonly TextBlock? _columnBDescription;

    private string _assistanceSentence;
    private string _walkingSentence;
    private string _fallsSentence;
    private string _cognitiveDeficitSentence;
    private string _bpsdSentence;
    private string _impairmentSentence;
    private string _nightsSentence;
    private string _weightLossSentence;
    private string _constipationSentence;
    private string _disabilitySentence;

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
            case "MotorSkill":
                _currentVisit!.MotorSkill = value!;
                if (_currentVisit!.MotorSkill is not "Solo letto-poltrona")
                {
                    _currentVisit.WalkingType ??= "Autonoma senza ausili";
                    WalkingTypeComboBox.SelectedItem = _currentVisit!.WalkingType;  //Forcing selected item value for spawned values
                    WalkingTypeComboBox.IsVisible = true;
                    WalkingTypeTextBlock.IsVisible = true;
                }
                else
                {
                    _currentVisit!.WalkingType = null;
                    WalkingTypeComboBox.IsVisible = false;
                    WalkingTypeTextBlock.IsVisible = false;

                }
                //UpdateWalkingSentence();
                break;
            case "WalkingType":
                _currentVisit!.WalkingType = value!;
                //UpdateWalkingSentence();
                break;
            case "Falls":
                _currentVisit!.Falls = value!;
                UpdateFallsSentence();
                break;
            case "CognitiveDeficit":
                _currentVisit!.CognitiveDeficit = value!;
                UpdateCognitiveDeficitSentence();
                break;
            case "Bpsd":
                _currentVisit!.Bpsd = value == "True";
                UpdateBpsdSentence();
                break;
            case "HearingImpairment":
                _currentVisit!.HearingImpairment = value == "True";
                UpdateImpairmentSentence();
                break;
            case "VisualImpairment":
                _currentVisit!.VisualImpairment = value == "True";
                UpdateImpairmentSentence();
                break;
            case "Nights":
                _currentVisit!.Nights = value!;
                UpdateNightsSentence();
                break;
            case "WeightLoss":
                _currentVisit!.WeightLoss = value!;
                UpdateWeightLossSentence();
                break;
            case "Appetite":
                _currentVisit!.Appetite = value!;
                UpdateWeightLossSentence();
                break;
            case "Dysphagia":
                _currentVisit!.Dysphagia = value!;
                UpdateWeightLossSentence();
                break;
            case "Constipation":
                _currentVisit!.Constipation = value == "True";
                UpdateConstipationSentence();
                break;
            case "Disability":
                _currentVisit!.Disability = value == "True";
                UpdateDisabilitySentence();
                break;
        }
        
        UpdateColumnBDescription();
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
        assistanceSentenceBuilder.Append('\n');
        _assistanceSentence = assistanceSentenceBuilder.ToString();
    }
    
    private void UpdateWalkingSentence()
    {
        var walkingSentenceBuilder = new StringBuilder();
        walkingSentenceBuilder.Append("Deambulazione ");
        walkingSentenceBuilder.Append(_currentVisit!.WalkingType.ToLower());
        walkingSentenceBuilder.Append(" e ");
        walkingSentenceBuilder.Append(_currentVisit!.MotorSkill.ToLower());
        walkingSentenceBuilder.Append('.');
        walkingSentenceBuilder.Append('\n');
        _walkingSentence = walkingSentenceBuilder.ToString();
    }
    
    private void UpdateFallsSentence()
    {
        var fallsSentenceBuilder = new StringBuilder();
        if (_currentVisit!.Falls == "0") fallsSentenceBuilder.Append("Non riferite cadute negli ultimi 6 mesi");
        else if (_currentVisit!.Falls == "1") fallsSentenceBuilder.Append("Riferita 1 caduta negli ultimi 6 mesi");
        else if (_currentVisit!.Falls == "2") fallsSentenceBuilder.Append("Riferite 2 cadute negli ultimi 6 mesi");
        else fallsSentenceBuilder.Append("Riferite 3 o più cadute negli ultimi 6 mesi");

        fallsSentenceBuilder.Append('.');
        fallsSentenceBuilder.Append('\n');
        _fallsSentence = fallsSentenceBuilder.ToString();
    }
    
    private void UpdateCognitiveDeficitSentence()
    {
        var cognitiveDeficitSentenceBuilder = new StringBuilder();
        if (_currentVisit!.CognitiveDeficit == "Nessuno") cognitiveDeficitSentenceBuilder.Append("Nessun decadimento cognitivo");
        else if (_currentVisit!.CognitiveDeficit == "Iniziali") cognitiveDeficitSentenceBuilder.Append("Iniziali deficit cognitivi");
        else cognitiveDeficitSentenceBuilder.Append("Noti deficit cognitivi");

        cognitiveDeficitSentenceBuilder.Append('.');
        cognitiveDeficitSentenceBuilder.Append('\n');
        _cognitiveDeficitSentence = cognitiveDeficitSentenceBuilder.ToString();
    }

    private void UpdateBpsdSentence()
    {
        var bpsdSentenceBuilder = new StringBuilder();
        if (_currentVisit!.Bpsd) bpsdSentenceBuilder.Append("Noti BPSD");
        else bpsdSentenceBuilder.Append("Non BPSD");

        bpsdSentenceBuilder.Append('.');
        bpsdSentenceBuilder.Append('\n');
        _bpsdSentence = bpsdSentenceBuilder.ToString();
    }
    
    private void UpdateImpairmentSentence()
    {
        var impairmentSentenceBuilder = new StringBuilder();
        if (_currentVisit!.HearingImpairment) impairmentSentenceBuilder.Append("Affetto da ipoacusia e ");
        else  impairmentSentenceBuilder.Append("Non affetto da ipoacusia e ");
        if (_currentVisit!.VisualImpairment) impairmentSentenceBuilder.Append("affetto da ipovisus");
        else  impairmentSentenceBuilder.Append("non affetto da ipovisus");
        impairmentSentenceBuilder.Append('.');
        impairmentSentenceBuilder.Append('\n');
        _impairmentSentence = impairmentSentenceBuilder.ToString();
    }
    
    private void UpdateNightsSentence()
    {
        var nightsSentenceBuilder = new StringBuilder();
        nightsSentenceBuilder.Append("Notti ");
        nightsSentenceBuilder.Append(_currentVisit!.Nights.ToLower());
        nightsSentenceBuilder.Append('.');
        nightsSentenceBuilder.Append('\n');
        _nightsSentence = nightsSentenceBuilder.ToString();
    }
    
    private void UpdateWeightLossSentence()
    {
        var weightLossSentenceBuilder = new StringBuilder();
        //WeightLoss
        weightLossSentenceBuilder.Append("Negli ultimi 3 mesi ");
        if (_currentVisit!.WeightLoss == "No") weightLossSentenceBuilder.Append("nessuna perdita di peso, ");
        else if (_currentVisit!.WeightLoss == "1-3 Kg") weightLossSentenceBuilder.Append("persi dagli 1 ai 3 Kg, ");
        else if (_currentVisit!.WeightLoss == "Non noto") weightLossSentenceBuilder.Append("non è nota alcuna perdita di peso, ");
        else  weightLossSentenceBuilder.Append("sono stati persi più di 3 Kg, ");
        
        //Appetite
        weightLossSentenceBuilder.Append("con appetito ");
        weightLossSentenceBuilder.Append(_currentVisit!.Appetite.ToLower());
        weightLossSentenceBuilder.Append(", ");

        //Dysphagia
        if (_currentVisit!.Dysphagia == "No") weightLossSentenceBuilder.Append("nessuna disfagia");
        else
        {
            weightLossSentenceBuilder.Append("disfagia ");
            weightLossSentenceBuilder.Append(_currentVisit!.Dysphagia.ToLower());
        }

        weightLossSentenceBuilder.Append('.');
        weightLossSentenceBuilder.Append('\n');
        _weightLossSentence = weightLossSentenceBuilder.ToString();
    }

    private void UpdateConstipationSentence()
    {        
        var constipationSentenceBuilder = new StringBuilder();
        
        constipationSentenceBuilder.Append("Alvo ");
        if (_currentVisit!.Constipation) constipationSentenceBuilder.Append("stitico");
        else constipationSentenceBuilder.Append("regolare");
        
        constipationSentenceBuilder.Append('.');
        constipationSentenceBuilder.Append('\n');
        _constipationSentence = constipationSentenceBuilder.ToString();
    }

    private void UpdateDisabilitySentence()
    {
        var disabilitySentenceBuilder = new StringBuilder();
        
        if (_currentVisit!.Disability) disabilitySentenceBuilder.Append("In possesso di IC");
        else disabilitySentenceBuilder.Append("Non in possesso di IC");
        
        disabilitySentenceBuilder.Append('.');
        disabilitySentenceBuilder.Append('\n');
        _disabilitySentence = disabilitySentenceBuilder.ToString();
    }
    
    public void LoadAnamnesiGeriatricaContent(Visit currentVisit)
    {
        _currentVisit = currentVisit;
        UpdateAssistanceSentence();
        //UpdateWalkingSentence();
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