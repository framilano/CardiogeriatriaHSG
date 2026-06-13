using System;
using System.Globalization;
using System.Text;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using CardiogeriatriaHSG.Models;
using CardiogeriatriaHSG.Models.enums;
using CardiogeriatriaHSG.ViewModels.VisitContent;

namespace CardiogeriatriaHSG.Views.VisitContent;

public partial class EsamiObiettivoUserControl : UserControl
{
    public EsamiObiettivoUserControl()
    {
        InitializeComponent();
        _columnBDescription = this.Find<TextBlock>("ColumnBDescription");
        DataContextChanged += (_, __) =>
        {
            if (DataContext is not EsamiObiettivoUserControlViewModel viewModel) return;
            _currentVisitEo = viewModel.CurrentVisitEo;
            LoadEsamiObiettivoContent(_currentVisitEo);
        };
    }
    
    private VisitEo? _currentVisitEo;
    private readonly TextBlock? _columnBDescription;

    private string? _bloodPressureSentence;
    private string? _tgAndRegSentence;
    private string? _heartSoundSentence;
    private string? _chestMvSentence;
    private string? _edemaSentence;
    private string? _neuropathySentence;
    private string? _orthostaticHypotensionSentence;

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
            //This weird handling is needed because some numbers could be actually null on purpose
            case NumericUpDown box:
                tag = (string)box.Tag!;
                if (box.Value is null) value = null;
                else                {
                    value = box.Value.ToString();
                    if (value.IsWhiteSpace() || value!.Length == 0) value = null;
                }
                break;
        }
        
        switch (tag) 
        {
            case "MinimumBloodPressure":
                _currentVisitEo!.MinimumBloodPressure = value is null ? null : int.Parse(value);
                UpdateBloodPressureSentence();
                break;
            case "MaximumBloodPressure":
                _currentVisitEo!.MaximumBloodPressure = value is null ? null : int.Parse(value);
                UpdateBloodPressureSentence();
                break;
            case "HeartRate":
                _currentVisitEo!.HeartRate = value is null ? null : int.Parse(value);
                UpdateBloodPressureSentence();
                break;
            case "JugularVenousDistension":
                _currentVisitEo!.JugularVenousDistension = value == "True";
                UpdateTgAndRegSentence();
                break;
            case "Rheoencephalography":
                _currentVisitEo!.Rheoencephalography = value == "True";
                UpdateTgAndRegSentence();
                break;
            case "HeartSoundType":
                _currentVisitEo!.HeartSoundType = value;
                UpdateHeartSoundSentence();
                break;
            case "HeartSoundRhythm":
                _currentVisitEo!.HeartSoundRhythm = value;
                UpdateHeartSoundSentence();
                break;
            case "HeartSoundPauses":
                _currentVisitEo!.HeartSoundPauses = value;
                UpdateHeartSoundSentence();
                break;
            case "ChestMv":
                _currentVisitEo!.ChestMv = value;
                UpdateChestMvSentence();
                break;
            case "ChestNoises":
                _currentVisitEo!.ChestNoises = value;
                UpdateChestMvSentence();
                break;
            case "DependentEdema":
                _currentVisitEo!.DependentEdema = value == "True";
                if (_currentVisitEo.DependentEdema)
                {
                    _currentVisitEo.DependentEdemaType ??= StringChoices.DependentEdemaTypes[0];
                    _currentVisitEo.DependentEdemaLocation ??= StringChoices.DependentEdemaLocations[0];
                    _currentVisitEo.DependentEdemaFovea ??= StringChoices.DependentEdemaFoveas[0];
                    Dispatcher.UIThread.Post(() => EdemaWrapPanel.IsVisible = true);
                }
                else
                {
                    _currentVisitEo.DependentEdemaType = null;
                    _currentVisitEo.DependentEdemaLocation = null;
                    _currentVisitEo.DependentEdemaFovea = null;
                    Dispatcher.UIThread.Post(() => EdemaWrapPanel.IsVisible = false);
                }
                UpdateEdemaSentence();
                break;
            case "DependentEdemaType":
                _currentVisitEo!.DependentEdemaType = value;
                UpdateEdemaSentence();
                break;
            case "DependentEdemaLocation":
                _currentVisitEo!.DependentEdemaLocation = value;
                UpdateEdemaSentence();
                break;
            case "DependentEdemaFovea":
                _currentVisitEo!.DependentEdemaFovea = value;
                UpdateEdemaSentence();
                break;
            case "PeripheralNeuropathy":
                _currentVisitEo!.PeripheralNeuropathy = value == "True";
                UpdateNeuropathySentence();
                break;
            case "OrthostaticHypotension":
                _currentVisitEo!.OrthostaticHypotension = value == "True";
                UpdateOrthostaticHypotensionSentence();
                break;
        }
        UpdateColumnBDescription();
    }
    
    //Doesn't make sense to have multiple update methods for these easy-to-build sentences
    private void UpdateBloodPressureSentence()
    {
        var bloodPressureSentenceStringBuilder = new StringBuilder();
       if (_currentVisitEo!.MinimumBloodPressure is not null)  bloodPressureSentenceStringBuilder.Append($"PA min: {_currentVisitEo.MinimumBloodPressure} mmHg. ");
       if (_currentVisitEo!.MaximumBloodPressure is not null)  bloodPressureSentenceStringBuilder.Append($"PA max: {_currentVisitEo.MaximumBloodPressure} mmHg. ");
       if (_currentVisitEo!.HeartRate is not null)  bloodPressureSentenceStringBuilder.Append($"FC: {_currentVisitEo.HeartRate} bpm. ");
       _bloodPressureSentence = bloodPressureSentenceStringBuilder.ToString();
    }
    
    private void UpdateTgAndRegSentence()
    {
       var tgAndRegSentenceStringBuilder = new StringBuilder();
       tgAndRegSentenceStringBuilder.Append("Turgore giugulare ");
       tgAndRegSentenceStringBuilder.Append(_currentVisitEo!.JugularVenousDistension ? "presente. " : "assente. ");

       tgAndRegSentenceStringBuilder.Append("REG ");
       tgAndRegSentenceStringBuilder.Append(_currentVisitEo!.Rheoencephalography ? "presente.\n" : "assente.\n");
       _tgAndRegSentence = tgAndRegSentenceStringBuilder.ToString();
    }
    
    private void UpdateHeartSoundSentence()
    {
        var heartSoundSentenceStringBuilder = new StringBuilder();
        heartSoundSentenceStringBuilder.Append("Toni cardiaci ");
        heartSoundSentenceStringBuilder.Append($"{_currentVisitEo!.HeartSoundType}, con andamenti ");
        heartSoundSentenceStringBuilder.Append($"{_currentVisitEo.HeartSoundRhythm} e con pause ");
        heartSoundSentenceStringBuilder.Append($"{_currentVisitEo.HeartSoundPauses}.\n");
        
        _heartSoundSentence = heartSoundSentenceStringBuilder.ToString();
    }
    
    private void UpdateChestMvSentence()
    {
        var chestMvSentenceStringBuilder = new StringBuilder();
        chestMvSentenceStringBuilder.Append("Al torace risulta MV ");
        chestMvSentenceStringBuilder.Append($"{_currentVisitEo!.ChestMv}, {_currentVisitEo!.ChestNoises}.\n");
        _chestMvSentence = chestMvSentenceStringBuilder.ToString();
    }
    
    private void UpdateEdemaSentence()
    {
        var edemaSentenceStringBuilder = new StringBuilder();
        if (_currentVisitEo!.DependentEdema)
        {
            edemaSentenceStringBuilder.Append("Edemi declivi ");
            edemaSentenceStringBuilder.Append($"{_currentVisitEo.DependentEdemaType} a localizzazione ");
            edemaSentenceStringBuilder.Append($"{_currentVisitEo.DependentEdemaLocation} con fovea {_currentVisitEo.DependentEdemaFovea}.\n");
        }
        else
        {
            edemaSentenceStringBuilder.Append("Non edemi declivi.\n");
        }
        _edemaSentence = edemaSentenceStringBuilder.ToString();
    }
    
    private void UpdateNeuropathySentence()
    { 
        var neuropathySentenceStringBuilder = new StringBuilder();
        neuropathySentenceStringBuilder.Append("Neuropatia periferica ");
        neuropathySentenceStringBuilder.Append(_currentVisitEo!.PeripheralNeuropathy ? "presente.\n" : "assente.\n");
        _neuropathySentence = neuropathySentenceStringBuilder.ToString();
    }
    
    private void UpdateOrthostaticHypotensionSentence()
    { 
        var orthostaticHypotensionSentenceStringBuilder = new StringBuilder();
        orthostaticHypotensionSentenceStringBuilder.Append("Prove di ipotensione ortostatica: ");
        orthostaticHypotensionSentenceStringBuilder.Append(_currentVisitEo!.OrthostaticHypotension ? "positive." : "negative.");
        _orthostaticHypotensionSentence = orthostaticHypotensionSentenceStringBuilder.ToString();
    }
    
    public void LoadEsamiObiettivoContent(VisitEo currentVisitEo)
    {
        _currentVisitEo = currentVisitEo;
        UpdateBloodPressureSentence();
        UpdateTgAndRegSentence();
        UpdateHeartSoundSentence();
        UpdateChestMvSentence();
        UpdateEdemaSentence();
        UpdateNeuropathySentence();
        UpdateOrthostaticHypotensionSentence();
        UpdateColumnBDescription();
    }

    private void UpdateColumnBDescription()
    {
        var columnBDescriptionStringBuilder = new StringBuilder();
        columnBDescriptionStringBuilder.Append(_bloodPressureSentence);
        columnBDescriptionStringBuilder.Append(_tgAndRegSentence);
        columnBDescriptionStringBuilder.Append(_heartSoundSentence);
        columnBDescriptionStringBuilder.Append(_chestMvSentence);
        columnBDescriptionStringBuilder.Append(_edemaSentence);
        columnBDescriptionStringBuilder.Append(_neuropathySentence);
        columnBDescriptionStringBuilder.Append(_orthostaticHypotensionSentence);
        
        Dispatcher.UIThread.Post(() => { _columnBDescription!.Text = columnBDescriptionStringBuilder.ToString(); });
    }
}