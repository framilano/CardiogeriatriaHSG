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

public partial class ValutazioneGeriatricaCompletaUserControl : UserControl
{
    public ValutazioneGeriatricaCompletaUserControl()
    {
        InitializeComponent();
        DataContextChanged += (_, __) =>
        {
            if (DataContext is not ValutazioneGeriatricaCompletaUserControlViewModel viewModel) return;
            _currentVisitCga = viewModel.CurrentVisitCga;
            LoadValutazioneGeriatricaCompletaContent(_currentVisitCga);
        };
    }
    
    private VisitCga? _currentVisitCga;

    private string? _adlSentence;
    private string? _iadlSentence;
    private string? _mmseSentence;
    private string? _mocaSentence;
    private string? _esSentence;
    private string? _borgSentence;
    private string? _sppbSentence;
    private string? _ergonomicsSentence;


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
            case NumericUpDown box:
                tag = (string)box.Tag!;
                if (box.Value is null) value = null;
                else {
                    value = box.Value.ToString();
                    if (value.IsWhiteSpace() || value!.Length == 0) value = null;
                }
                break;
        }
        
        switch (tag) 
        {
            case "Diet":
                _currentVisitCga!.Diet = value == "True";
                UpdateAdlSentence();
                break;
            case "Continence":
                _currentVisitCga!.Continence = value == "True";
                UpdateAdlSentence();
                break;
            case "Dressing":
                _currentVisitCga!.Dressing = value == "True";
                UpdateAdlSentence();
                break;
            case "Shower":
                _currentVisitCga!.Shower = value == "True";
                UpdateAdlSentence();
                break;
            case "PosturalPassages":
                _currentVisitCga!.PosturalPassages = value == "True";
                UpdateAdlSentence();
                break;
            case "Hygiene":
                _currentVisitCga!.Hygiene = value == "True";
                UpdateAdlSentence();
                break;
            case "Phone":
                _currentVisitCga!.Phone = value == "True";
                UpdateIadlSentence();
                break;
            case "Shopping":
                _currentVisitCga!.Shopping = value == "True";
                UpdateIadlSentence();
                break;
            case "SenseOfMoney":
                _currentVisitCga!.SenseOfMoney = value == "True";
                UpdateIadlSentence();
                break;
            case "Car":
                _currentVisitCga!.Car = value == "True";
                UpdateIadlSentence();
                break;
            case "Medicines":
                _currentVisitCga!.Medicines = value == "True";
                UpdateIadlSentence();
                break;
            case "Cooking":
                _currentVisitCga!.Cooking = value == "True";
                UpdateIadlSentence();
                break;
            case "HouseholdChores":
                _currentVisitCga!.HouseholdChores = value == "True";
                UpdateIadlSentence();
                break;
            case "Laundry":
                _currentVisitCga!.Laundry = value == "True";
                UpdateIadlSentence();
                break;
            case "MmseNumber":
                _currentVisitCga!.Mmse = value is null ? null : int.Parse(value);
                UpdateMmseSentence();
                break;
            case "MocaNumber":
                _currentVisitCga!.Moca = value is null ? null : int.Parse(value);
                UpdateMocaSentence();
                break;
            case "EsNumber":
                _currentVisitCga!.Es = value is null ? null : int.Parse(value);
                UpdateEsSentence();
                break;
            case "RestingBorgNumber":
                _currentVisitCga!.RestingBorg = value is null ? null : int.Parse(value);
                UpdateBorgSentence();
                break;
            case "PostSppbBorgNumber":
                _currentVisitCga!.PostSppbBorg = value is null ? null : int.Parse(value);
                UpdateBorgSentence();
                break;
            case "SppBalanceTypes":
                _currentVisitCga!.SppbBalance = value!;
                UpdateSppbSentence();
                break;
            case "SppbFourMetersTimeNumber":
                _currentVisitCga!.SppbFourMetersTime = value is null ? null : float.Parse(value);
                UpdateSppbSentence();
                break;
            case "SppbSitToStandTypes":
                _currentVisitCga!.SppbSitToStand = value!;
                UpdateSppbSentence();
                break;
            case "HandgripNumber":
                _currentVisitCga!.Handgrip = value is null ? null : int.Parse(value);
                UpdateErgonomicsSentence();
                break;
            case "WeightNumber":
                _currentVisitCga!.Weight = value is null ? null : int.Parse(value);
                UpdateErgonomicsSentence();
                break;
            case "HeightNumber":
                _currentVisitCga!.Height = value is null ? null : float.Parse(value);
                UpdateErgonomicsSentence();
                break;
        }
        
        UpdateColumnBDescription();
    }
    
    private void UpdateAdlSentence()
    {
        var adlSentenceBuilder = new StringBuilder();
        var counter = 
            Convert.ToInt32(_currentVisitCga!.Diet) + 
            Convert.ToInt32(_currentVisitCga!.Continence) +
            Convert.ToInt32(_currentVisitCga!.Dressing) + 
            Convert.ToInt32(_currentVisitCga!.Shower) +
            Convert.ToInt32(_currentVisitCga!.PosturalPassages) + 
            Convert.ToInt32(_currentVisitCga!.Hygiene);
        adlSentenceBuilder.Append($"ADL {counter}/6 (");
        var adlSubSentenceBuilder = new StringBuilder();
        if (_currentVisitCga!.Diet) adlSubSentenceBuilder.Append($"{Diet.Text!.ToLower().Replace("‣ ", "")},");
        if (_currentVisitCga!.Continence) adlSubSentenceBuilder.Append($" {Continence.Text!.ToLower().Replace("‣ ", "")},");
        if (_currentVisitCga!.Dressing) adlSubSentenceBuilder.Append($" {Dressing.Text!.ToLower().Replace("‣ ", "")},");
        if (_currentVisitCga!.Shower) adlSubSentenceBuilder.Append($" {Shower.Text!.ToLower().Replace("‣ ", "")},");
        if (_currentVisitCga!.PosturalPassages) adlSubSentenceBuilder.Append($" {PosturalPassages.Text!.ToLower().Replace("‣ ", "")},");
        if (_currentVisitCga!.Hygiene) adlSubSentenceBuilder.Append($" {Hygiene.Text!.ToLower().Replace("‣ ", "")},");
        var adlSubSentence = adlSubSentenceBuilder.ToString();
        if (adlSubSentence.EndsWith(',')) adlSubSentence = adlSubSentence[..^1].Trim();
        adlSentenceBuilder.Append(adlSubSentence);
        adlSentenceBuilder.Append(")\n");
        _adlSentence = adlSentenceBuilder.ToString();
    }
    
    private void UpdateIadlSentence()
    {
        var iadlSentenceBuilder = new StringBuilder();
        var counter = 
            Convert.ToInt32(_currentVisitCga!.Phone) + 
            Convert.ToInt32(_currentVisitCga!.Shopping) +
            Convert.ToInt32(_currentVisitCga!.SenseOfMoney) + 
            Convert.ToInt32(_currentVisitCga!.Car) +
            Convert.ToInt32(_currentVisitCga!.Medicines) + 
            Convert.ToInt32(_currentVisitCga!.Cooking) +
            Convert.ToInt32(_currentVisitCga!.HouseholdChores) +
            Convert.ToInt32(_currentVisitCga!.Laundry);

        iadlSentenceBuilder.Append($"IADL {counter}/8 (");
        var iadlSubSentenceBuilder = new StringBuilder();
        if (_currentVisitCga!.Phone) iadlSubSentenceBuilder.Append($"{Phone.Text!.ToLower().Replace("‣ ", "")},");
        if (_currentVisitCga!.Shopping) iadlSubSentenceBuilder.Append($" {Shopping.Text!.ToLower().Replace("‣ ", "")},");
        if (_currentVisitCga!.SenseOfMoney) iadlSubSentenceBuilder.Append($" {SenseOfMoney.Text!.ToLower().Replace("‣ ", "")},");
        if (_currentVisitCga!.Car) iadlSubSentenceBuilder.Append($" {Car.Text!.ToLower().Replace("‣ ", "")},");
        if (_currentVisitCga!.Medicines) iadlSubSentenceBuilder.Append($" {Medicines.Text!.ToLower().Replace("‣ ", "")},");
        if (_currentVisitCga!.Cooking) iadlSubSentenceBuilder.Append($" {Cooking.Text!.ToLower().Replace("‣ ", "")},");
        if (_currentVisitCga!.HouseholdChores) iadlSubSentenceBuilder.Append($" {HouseholdChores.Text!.ToLower().Replace("‣ ", "")},");
        if (_currentVisitCga!.Laundry) iadlSubSentenceBuilder.Append($" {Laundry.Text!.ToLower().Replace("‣ ", "")},");
        var iadlSubSentence = iadlSubSentenceBuilder.ToString();
        if (iadlSubSentence.EndsWith(',')) iadlSubSentence = iadlSubSentence[..^1].Trim();
        iadlSentenceBuilder.Append(iadlSubSentence);
        iadlSentenceBuilder.Append(")\n");
        _iadlSentence = iadlSentenceBuilder.ToString();
    }
    
    private void UpdateMmseSentence()
    {
        var mmseSentenceBuilder = new StringBuilder();
        if (_currentVisitCga!.Mmse is not null)  mmseSentenceBuilder.Append($"MMSE {_currentVisitCga.Mmse}/30\n");
        _mmseSentence = mmseSentenceBuilder.ToString();
    }
    
    private void UpdateMocaSentence()
    {
        var mocaSentenceBuilder = new StringBuilder();
        if (_currentVisitCga!.Moca is not null)  mocaSentenceBuilder.Append($"MoCA {_currentVisitCga.Moca}/30\n");
        _mocaSentence = mocaSentenceBuilder.ToString();
    }
    
    private void UpdateEsSentence()
    {
        var esSentenceBuilder = new StringBuilder();
        if (_currentVisitCga!.Es is not null)  esSentenceBuilder.Append($"ES {_currentVisitCga.Es}/4\n");
        _esSentence = esSentenceBuilder.ToString();
    }
    
    private void UpdateBorgSentence()
    {
        var bogSentenceBuilder = new StringBuilder();
        if (_currentVisitCga!.RestingBorg is not null) bogSentenceBuilder.Append($"BORG {_currentVisitCga.RestingBorg}/10\n");
        if (_currentVisitCga!.PostSppbBorg is not null) bogSentenceBuilder.Append($"BORG dopo SPPB {_currentVisitCga.PostSppbBorg}/10\n");
        _borgSentence = bogSentenceBuilder.ToString();
    }
    
    private void UpdateSppbSentence()
    {
        var sppbSentenceBuilder = new StringBuilder();

        var sppbFourMeterTimeValue = (double?)_currentVisitCga!.SppbFourMetersTime switch
        {
            null or 0 => 0,
            >= 7.5 => 1,
            < 7.5 and >= 5.4 => 2,
            < 5.4 and >= 4.1 => 3,
            < 4.1 => 4,
            _ => 0
        };
        
        var total = 
            StringChoices.SppbBalanceTypes.FindIndex(s => s.Equals(_currentVisitCga!.SppbBalance)) +
            sppbFourMeterTimeValue +
            StringChoices.SppbSitToStandTypes.FindIndex(s => s.Equals(_currentVisitCga!.SppbSitToStand));
        sppbSentenceBuilder.Append($"SPPD totale {total}\n");
        if (_currentVisitCga!.SppbFourMetersTime != null && _currentVisitCga.SppbFourMetersTime != 0) sppbSentenceBuilder.Append($"Velocità cammino {4/_currentVisitCga.SppbFourMetersTime:F1}m/s\n");

        _sppbSentence = sppbSentenceBuilder.ToString();
    }
    
    private void UpdateErgonomicsSentence()
    {
        var ergonomicsSentenceBuilder = new StringBuilder();
        if (_currentVisitCga!.Handgrip is not null) ergonomicsSentenceBuilder.Append($"Handgrip {_currentVisitCga.Handgrip}Kg\n");
        if (_currentVisitCga!.Weight is not null) ergonomicsSentenceBuilder.Append($"Peso {_currentVisitCga.Weight}Kg\n");
        if (_currentVisitCga!.Height is not null) ergonomicsSentenceBuilder.Append($"Altezza {_currentVisitCga.Height:F2}m\n");
        if (_currentVisitCga!.Height is not null && _currentVisitCga!.Weight is not null && _currentVisitCga!.Height != 0)
        {
            var bmi = _currentVisitCga.Weight / Math.Pow((double)_currentVisitCga.Height, 2);
            var category = bmi switch
            {
                < 18.5   => "sottopeso",
                >= 18.5 and < 25   => "normopeso",
                >= 25 and < 30   => "sovrappeso",
                >= 30 and < 40  => "obesità",
                >= 40  => "obesità estrema",
                _ => "Errore I guess?"
            };
            ergonomicsSentenceBuilder.Append($"BMI {bmi:F1}Kg/m² ({category})\n");
        }

        _ergonomicsSentence = ergonomicsSentenceBuilder.ToString();
    }
    
    public void LoadValutazioneGeriatricaCompletaContent(VisitCga currentVisitCga)
    {
        _currentVisitCga = currentVisitCga;
        UpdateAdlSentence();
        UpdateIadlSentence();
        UpdateMmseSentence();
        UpdateMocaSentence();
        UpdateEsSentence();
        UpdateBorgSentence();
        UpdateSppbSentence();
        UpdateErgonomicsSentence();
        UpdateColumnBDescription();
    }

    private void UpdateColumnBDescription()
    {
        var columnBDescriptionStringBuilder = new StringBuilder();
        columnBDescriptionStringBuilder.Append(_adlSentence);
        columnBDescriptionStringBuilder.Append(_iadlSentence);
        columnBDescriptionStringBuilder.Append(_mmseSentence);
        columnBDescriptionStringBuilder.Append(_mocaSentence);
        columnBDescriptionStringBuilder.Append(_esSentence);
        columnBDescriptionStringBuilder.Append(_borgSentence);
        columnBDescriptionStringBuilder.Append(_sppbSentence);
        columnBDescriptionStringBuilder.Append(_ergonomicsSentence);

        Dispatcher.UIThread.Post(() => { AutomaticColumnB!.Text = columnBDescriptionStringBuilder.ToString(); });
    }
    
    private void CopyToManualText(object? sender, RoutedEventArgs routedEventArgs)
    {
        _currentVisitCga!.CgaManualText = AutomaticColumnB.Text;
    }
}