using System;
using System.Globalization;
using System.Text;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using CardiogeriatriaHSG.Models;
using CardiogeriatriaHSG.Models.enums;
using CardiogeriatriaHSG.ViewModels.VisitContent;
using Serilog;

namespace CardiogeriatriaHSG.Views.VisitContent;

public partial class ValutazioneGeriatricaCompletaUserControl : UserControl
{
    public ValutazioneGeriatricaCompletaUserControl()
    {
        InitializeComponent();
        DataContextChanged += (_, __) =>
        {
            if (DataContext is not ValutazioneGeriatricaCompletaUserControlViewModel viewModel) return;
            _currentVisitAg = viewModel.CurrentVisitAg;
            _currentVisitApr = viewModel.CurrentVisitApr;
            _currentVisitTd = viewModel.CurrentVisitTd;
            _currentVisitRc = viewModel.CurrentVisitRc;
            _currentVisitEo = viewModel.CurrentVisitEo;

            _currentVisitCga = viewModel.CurrentVisitCga;
            LoadValutazioneGeriatricaCompletaContent(_currentVisitAg, _currentVisitApr, _currentVisitTd, _currentVisitRc, _currentVisitEo, _currentVisitCga);
        };
    }
    private VisitAg? _currentVisitAg;
    private VisitApr? _currentVisitApr;
    private VisitTd? _currentVisitTd;
    private VisitRc? _currentVisitRc;
    private VisitEo? _currentVisitEo;
    private VisitCga? _currentVisitCga;

    private string? _adlSentence;
    private string? _iadlSentence;
    private string? _mmseSentence;
    private string? _mocaSentence;
    private string? _esSentence;
    private string? _borgSentence;
    private string? _sppbSentence;
    private string? _ergonomicsSentence;
    private string? _kccqSentence;
    private string? _mnaSentence;
    private string? _eftSentence;
    private string? _cfsSentence;
    private string? _pcfiSentence;
    private string? _necpaleSentence;
    
    private const decimal PcFiIncrementValue = 0.04m;

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
                UpdateMnaSentence();
                break;
            case "HeightNumber":
                _currentVisitCga!.Height = value is null ? null : float.Parse(value);
                UpdateErgonomicsSentence();
                UpdateMnaSentence();
                break;
            case "KccqNumber":
                _currentVisitCga!.Kccq = value is null ? null : int.Parse(value);
                UpdateKccqSentence();
                break;
            case "EftNumber":
                _currentVisitCga!.Eft = int.Parse(value!);
                UpdateEftSentence();
                break;
            case "CfsNumber":
                _currentVisitCga!.Cfs = int.Parse(value!);
                UpdateCfsSentence();
                break;
            case "OxygenPrescriptionForThePastSixMonths":
                _currentVisitCga!.OxygenPrescriptionForThePastSixMonths = value == "True";
                UpdatePcfiSentence();
                break;
            case "EbpmPrescriptionForThePastSixMonths":
                _currentVisitCga!.EbpmPrescriptionForThePastSixMonths = value == "True";
                UpdatePcfiSentence();
                break;
            case "OtherNeurologicalDiseases":
                _currentVisitCga!.OtherNeurologicalDiseases = value == "True";
                UpdatePcfiSentence();
                break;
            case "SurpriseQuestion":
                _currentVisitCga!.SurpriseQuestion = value == "True";
                if (!_currentVisitCga!.SurpriseQuestion)
                {
                    _currentVisitCga!.Necpal4 = null;
                    Dispatcher.UIThread.Post(() => SurpriseQuestionWrapPanel.IsVisible = true);
                }
                else
                {
                    _currentVisitCga!.Necpal4 = null;
                    Dispatcher.UIThread.Post(() => SurpriseQuestionWrapPanel.IsVisible = false);
                }
                UpdateNecpalSentence();
                break;
            case "Necpal4Number":
                _currentVisitCga!.Necpal4 = value is null ? null : int.Parse(value);
                UpdateNecpalSentence();
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
        var counter = ComputeAdlSum(
            _currentVisitCga!.Phone, 
            _currentVisitCga!.Shopping, 
            _currentVisitCga!.SenseOfMoney,
            _currentVisitCga!.Car, 
            _currentVisitCga!.Medicines, 
            _currentVisitCga!.Cooking,
            _currentVisitCga!.HouseholdChores, 
            _currentVisitCga!.Laundry);
        

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
        sppbSentenceBuilder.Append($"SPPB totale {total}\n");
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
            var bmi = ComputeBmi(_currentVisitCga.Weight.Value, _currentVisitCga.Height.Value);
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
    
    private void UpdateKccqSentence()
    {
        var kccqSentenceBuilder = new StringBuilder();
        if (_currentVisitCga!.Kccq is not null) kccqSentenceBuilder.Append($"KCCQ {_currentVisitCga.Kccq}\n");

        _kccqSentence = kccqSentenceBuilder.ToString();
    }
    
    private void UpdateMnaSentence()
    {
        //We need BMI first
        if (_currentVisitCga!.Weight is null ||
            _currentVisitCga!.Height is null ||
            _currentVisitCga!.Height == 0)
        {
            Log.Information("Missing data to compute MNA-SF");
            return;
        }
        
        Log.Information("Computing MNA-SF...");

        var mnaSentenceBuilder = new StringBuilder();
        var mnaValue =
            StringChoices.Appetites.FindIndex(s => s.Equals(_currentVisitAg!.Appetite)) +
            StringChoices.WeightLossTypes.FindIndex(s => s.Equals(_currentVisitAg!.WeightLoss)) +
            StringChoices.MotorSkillTypes.FindIndex(s => s.Equals(_currentVisitAg!.MotorSkill)) +
            (_currentVisitRc!.AcuteStressLast3Months ? 0 : 2) +
            StringChoices.CognitiveDeficits.FindIndex(s => s.Equals(_currentVisitAg!.CognitiveDeficit)) +
            ComputeBmi(_currentVisitCga.Weight.Value, _currentVisitCga.Height.Value) switch
            {
                < 19 => 0,
                >= 19 and < 21 => 1,
                >= 21 and < 23 => 2,
                >= 23 => 3,
                _ => -1
            };
        
        Log.Information("MNA-SF computed.");

            
        var category = mnaValue switch
        {
            >= 12 and <= 14 => "stato nutrizionale normale",
            >= 8 and <= 11 => "a rischio di malnutrizione",
            >= 0 and <= 7 => "malnutrito",
            _ => "Errore I guess?"
        };
            
        mnaSentenceBuilder.Append($"MNA {mnaValue} ({category})\n");
        _mnaSentence = mnaSentenceBuilder.ToString();
    }

    private void UpdateEftSentence()
    {
        var eftSentenceBuilder = new StringBuilder();

        var tavrValue = 0;
        var savrValue = 0;
        var eftValue = _currentVisitCga!.Eft;
        switch (eftValue)
        {
            case <= 1:
                tavrValue = 6; 
                savrValue = 3;
                break;
            case 2:
                tavrValue = 15;
                savrValue = 7;
                break;
            case 3:
                tavrValue = 28;
                savrValue = 16;
                break;
            case 4:
                tavrValue = 30;
                savrValue = 38;
                break;
            case 5:
                tavrValue = 65;
                savrValue = 50;
                break;
        }
        
        eftSentenceBuilder.Append($"EFT {_currentVisitCga!.Eft}, ");
        eftSentenceBuilder.Append($"TAVR {tavrValue}%, ");
        eftSentenceBuilder.Append($"SAVR {savrValue}%\n");

        _eftSentence = eftSentenceBuilder.ToString();

    }
    
    private void UpdateCfsSentence()
    {
        var cfsSentenceBuilder = new StringBuilder();
        cfsSentenceBuilder.Append($"CFS {_currentVisitCga!.Cfs}\n");
        _cfsSentence = cfsSentenceBuilder.ToString();
    }

    private void UpdatePcfiSentence()
    {
        Log.Information("Computing PC-FI...");

        if (!_currentVisitRc!.HospitalizationsSinceLastVisit ||
            _currentVisitRc!.HospitalizationsSinceLastVisitDays is null)
        {
            Log.Information("Missing data to compute PC-FI");
            return;
        }
        
        var pcfiSentenceBuilder = new StringBuilder();
        var pcfiValue =
            (_currentVisitApr!.Dementia ? PcFiIncrementValue : 0) +
            (ComputeAdlSum(
                _currentVisitCga!.Phone, 
                _currentVisitCga!.Shopping, 
                _currentVisitCga!.SenseOfMoney,
                _currentVisitCga!.Car, 
                _currentVisitCga!.Medicines, 
                _currentVisitCga!.Cooking,
                _currentVisitCga!.HouseholdChores, 
                _currentVisitCga!.Laundry) < 6 ? PcFiIncrementValue : 0) +
            (_currentVisitApr!.CerebrovascularDisease ? PcFiIncrementValue : 0) +
            (_currentVisitApr!.Neoplasm ? PcFiIncrementValue : 0) +
            (_currentVisitApr!.ChronicObstructivePulmonaryDisease ? PcFiIncrementValue : 0) +
            (_currentVisitApr!.IschemicHeartDisease ? PcFiIncrementValue : 0) +
            (_currentVisitApr!.HeartFailure ? PcFiIncrementValue : 0) +
            (_currentVisitApr!.ChronicKidneyDisease ? PcFiIncrementValue : 0) +
            (_currentVisitApr!.AtrialFibrillation ? PcFiIncrementValue : 0) +
            (_currentVisitApr!.Parkinson ? PcFiIncrementValue : 0) +
            (_currentVisitApr!.HipFracture ? PcFiIncrementValue : 0) +
            (_currentVisitApr!.Anemia ? PcFiIncrementValue : 0) +
            (_currentVisitAg!.Disability ? PcFiIncrementValue : 0) +
            (_currentVisitCga!.OxygenPrescriptionForThePastSixMonths ? PcFiIncrementValue : 0) +
            (_currentVisitRc!.HospitalizationsSinceLastVisitDays < 180 ? PcFiIncrementValue : 0) + //Uso 180 giorni come indicatore?
            (_currentVisitApr!.ChronicSkinUlcers ? PcFiIncrementValue : 0) +
            (_currentVisitApr!.Bradycardia ? PcFiIncrementValue : 0) +
            (_currentVisitCga!.OtherNeurologicalDiseases ? PcFiIncrementValue : 0) +
            (_currentVisitAg!.Constipation ? PcFiIncrementValue : 0) +
            (_currentVisitCga!.EbpmPrescriptionForThePastSixMonths ? PcFiIncrementValue : 0) +
            (_currentVisitApr!.PeripheralVascularDisease ? PcFiIncrementValue : 0) +
            (_currentVisitAg!.NutritionalProblems ? PcFiIncrementValue : 0) +
            (_currentVisitApr!.Diabetes ? PcFiIncrementValue : 0) +
            (_currentVisitApr!.Schizophrenia ? PcFiIncrementValue : 0) +
            (_currentVisitEo!.DependentEdema ? PcFiIncrementValue : 0);
            
        Log.Information("PC-FI computed.");
                
        pcfiSentenceBuilder.Append($"PC-FI {pcfiValue}\n"); 
        _pcfiSentence = pcfiSentenceBuilder.ToString();
    }
    
    private void UpdateNecpalSentence()
    {
        var necpalSentenceBuilder = new StringBuilder();
        if (_currentVisitCga!.Necpal4 is not null && _currentVisitCga!.Necpal4 > 0) necpalSentenceBuilder.Append($"NECPAL POSITIVO\n");
        _necpaleSentence = necpalSentenceBuilder.ToString();
    }
    
    private static double ComputeAdlSum(bool phone, bool shopping, bool senseOfMoney, bool car, bool medicines, bool cooking, bool householdChores, bool laundry)
    {
        var adlSum = 
             Convert.ToInt32(phone) + 
             Convert.ToInt32(shopping) +
             Convert.ToInt32(senseOfMoney) + 
             Convert.ToInt32(car) +
             Convert.ToInt32(medicines) + 
             Convert.ToInt32(cooking) +
             Convert.ToInt32(householdChores) +
             Convert.ToInt32(laundry);
        return adlSum;
    }
    
    private static double ComputeBmi(int weight, float height)
    {
        var bmi = weight / Math.Pow(height, 2);
        return bmi;
    }
    
    public void LoadValutazioneGeriatricaCompletaContent(VisitAg currentVisitAg, VisitApr currentVisitApr, VisitTd currentVisitTd, VisitRc currentVisitRc, VisitEo currentVisitEo, VisitCga currentVisitCga)
    {
        _currentVisitAg = currentVisitAg;
        _currentVisitApr = currentVisitApr;
        _currentVisitTd = currentVisitTd;
        _currentVisitRc = currentVisitRc;
        _currentVisitEo = currentVisitEo;
        _currentVisitCga = currentVisitCga;
        UpdateAdlSentence();
        UpdateIadlSentence();
        UpdateMmseSentence();
        UpdateMocaSentence();
        UpdateEsSentence();
        UpdateBorgSentence();
        UpdateSppbSentence();
        UpdateErgonomicsSentence();
        UpdateKccqSentence();
        UpdateMnaSentence();
        UpdateEftSentence();
        UpdateCfsSentence();
        UpdatePcfiSentence();
        UpdateNecpalSentence();
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
        columnBDescriptionStringBuilder.Append(_kccqSentence);
        columnBDescriptionStringBuilder.Append(_mnaSentence);
        columnBDescriptionStringBuilder.Append(_eftSentence);
        columnBDescriptionStringBuilder.Append(_cfsSentence);
        columnBDescriptionStringBuilder.Append(_pcfiSentence);
        columnBDescriptionStringBuilder.Append(_necpaleSentence);
        columnBDescriptionStringBuilder.Append(_mnaSentence);

        Dispatcher.UIThread.Post(() => { AutomaticColumnB!.Text = columnBDescriptionStringBuilder.ToString(); });
    }
    
    private void CopyToManualText(object? sender, RoutedEventArgs routedEventArgs)
    {
        _currentVisitCga!.CgaManualText = AutomaticColumnB.Text;
    }
}