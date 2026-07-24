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
        adlSentenceBuilder.Append(')');
        _adlSentence = adlSentenceBuilder.ToString();
    }
    
    public void LoadValutazioneGeriatricaCompletaContent(VisitCga currentVisitCga)
    {
        _currentVisitCga = currentVisitCga;
        UpdateAdlSentence();
        UpdateColumnBDescription();
    }

    private void UpdateColumnBDescription()
    {
        var columnBDescriptionStringBuilder = new StringBuilder();
        columnBDescriptionStringBuilder.Append(_adlSentence);

        Dispatcher.UIThread.Post(() => { AutomaticColumnB!.Text = columnBDescriptionStringBuilder.ToString(); });
    }
    
    private void CopyToManualText(object? sender, RoutedEventArgs routedEventArgs)
    {
        _currentVisitCga!.CgaManualText = AutomaticColumnB.Text;
    }
}