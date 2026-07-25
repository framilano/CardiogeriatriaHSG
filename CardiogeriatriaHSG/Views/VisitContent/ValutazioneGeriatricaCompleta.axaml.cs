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
                value = box.Value.ToString();
                value ??= box.Minimum.ToString(CultureInfo.InvariantCulture);
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
    
    public void LoadValutazioneGeriatricaCompletaContent(VisitCga currentVisitCga)
    {
        _currentVisitCga = currentVisitCga;
        UpdateAdlSentence();
        UpdateIadlSentence();
        UpdateColumnBDescription();
    }

    private void UpdateColumnBDescription()
    {
        var columnBDescriptionStringBuilder = new StringBuilder();
        columnBDescriptionStringBuilder.Append(_adlSentence);
        columnBDescriptionStringBuilder.Append(_iadlSentence);

        Dispatcher.UIThread.Post(() => { AutomaticColumnB!.Text = columnBDescriptionStringBuilder.ToString(); });
    }
    
    private void CopyToManualText(object? sender, RoutedEventArgs routedEventArgs)
    {
        _currentVisitCga!.CgaManualText = AutomaticColumnB.Text;
    }
}