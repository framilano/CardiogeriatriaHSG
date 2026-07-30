using System;
using System.Text;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using CardiogeriatriaHSG.Models;
using CardiogeriatriaHSG.Models.enums;
using CardiogeriatriaHSG.ViewModels.VisitContent;

namespace CardiogeriatriaHSG.Views.VisitContent;

public partial class EcografiaToracicaUserControl : UserControl
{
    public EcografiaToracicaUserControl()
    {
        InitializeComponent();
        DataContextChanged += (_, __) =>
        {
            if (DataContext is not EcografiaToracicaUserControlViewModel viewModel) return;
            _currentVisitEco = viewModel.CurrentVisitEco;
            LoadEcografiaToracicaContent(_currentVisitEco);
        };
    }
    
    private VisitEco? _currentVisitEco;

    private string? _pleuralLineSentence;
    private string? _bLinesSentence;
    private string? _patternASentence;
    private string? _pefsSentence;
    private string? _vciSentence;


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
                //This check stops Non-Visible checkboxes to load, we don't have to do this for other Box types (Avalonia doesn't load all their components at start)
                if (!((WrapPanel)box.Parent!.Parent!).IsVisible) return;
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
            case "PleuralLine":
                _currentVisitEco!.PleuralLine = value == "True";
                UpdatePleuralLineSentence();
                break;
            case "IrregularPleuralLine":
                _currentVisitEco!.IrregularPleuralLine = value == "True";
                UpdatePleuralLineSentence();
                break;
            case "PatternA":
                _currentVisitEco!.PatternA = value == "True";
                UpdatePatternASentence();
                break;
            case "BLines":
                _currentVisitEco!.BLines = value == "True";
                if (_currentVisitEco.BLines)
                {
                    _currentVisitEco.CoalescentBLines ??= false;
                    _currentVisitEco.GradientDistributionBLines ??= false;
                    _currentVisitEco.ConsiderationBLines ??= false;
                    Dispatcher.UIThread.Post(() => { BLinesWrapPanel.IsVisible = true; });
                }
                else
                {
                    _currentVisitEco.CoalescentBLines = null;
                    _currentVisitEco.GradientDistributionBLines = null;
                    _currentVisitEco.ConsiderationBLines = null;
                    Dispatcher.UIThread.Post(() => { BLinesWrapPanel.IsVisible = false; });
                }
                UpdateBLinesSentence();
                break;
            case "CoalescentBLines":
                _currentVisitEco!.CoalescentBLines = value == "True";
                UpdateBLinesSentence();
                break;
            case "GradientDistributionBLines":
                _currentVisitEco!.GradientDistributionBLines = value == "True";
                UpdateBLinesSentence();
                break;
            case "RightPefs":
                _currentVisitEco!.RightPefs = value is null ? null : int.Parse(value);
                UpdatePefsSentence();
                break;
            case "LeftPefs":
                _currentVisitEco!.LeftPefs = value is null ? null : int.Parse(value);
                UpdatePefsSentence();
                break;
            case "MeasurableIvc":
                _currentVisitEco!.MeasurableIvc = value == "True";
                if (_currentVisitEco.MeasurableIvc)
                {
                    _currentVisitEco.IvcDiameter ??= StringChoices.IvcDiameterTypes[0];
                    _currentVisitEco.IvcCollapsibility ??= StringChoices.IvcCollapsibilityTypes[0];
                    Dispatcher.UIThread.Post(() => { VciWrapPanel.IsVisible = true; });
                }
                else
                {
                    _currentVisitEco.IvcDiameter = null;
                    _currentVisitEco.IvcCollapsibility = null;
                    Dispatcher.UIThread.Post(() => { VciWrapPanel.IsVisible = false; });
                }
                UpdateVciSentence();
                break;
            case "IvcCollapsibility":
                _currentVisitEco!.IvcCollapsibility = value;
                UpdateVciSentence();
                break;
            case "IvcDiameter":
                _currentVisitEco!.IvcDiameter = value;
                if (_currentVisitEco.IvcDiameter == StringChoices.IvcDiameterTypes[0])
                {
                    _currentVisitEco.Vexus ??= 0;
                    _currentVisitEco.PortalVeinPulsatility ??= StringChoices.PortalVeinPulsatilityTypes[0];
                    Dispatcher.UIThread.Post(() => { VciGreaterThanTwoWrapPanel.IsVisible = true; });
                }
                else
                {
                    _currentVisitEco.Vexus = null;
                    _currentVisitEco.PortalVeinPulsatility = null;
                    Dispatcher.UIThread.Post(() => { VciGreaterThanTwoWrapPanel.IsVisible = false; });
                }
                UpdateVciSentence();
                break;
            case "Vexus":
                _currentVisitEco!.Vexus = value is null ? null : int.Parse(value);
                UpdateVciSentence();
                break;
            case "PortalVeinPulsatility":
                _currentVisitEco!.PortalVeinPulsatility = value;
                UpdateVciSentence();
                break;
        }
        UpdateAutomaticColumnBDescription();
    }
    
    private void UpdatePleuralLineSentence()
    {
        var pleuralLineSentenceStringBuilder = new StringBuilder();
        pleuralLineSentenceStringBuilder.Append("Si esegue ecolung (paziente a 45°): ");

        pleuralLineSentenceStringBuilder.Append(_currentVisitEco!.PleuralLine
            ? "sliding pleurico presente in L1-R1, "
            : "sliding pleurico non presente in L1-R1, ");

        pleuralLineSentenceStringBuilder.Append("linea pleurica ");
        pleuralLineSentenceStringBuilder.Append(_currentVisitEco!.IrregularPleuralLine
            ? "irregolare.\n"
            : "regolare.\n");

        _pleuralLineSentence = pleuralLineSentenceStringBuilder.ToString();
    }
    
    private void UpdatePatternASentence()
    {
        var patternASentenceStringBuilder = new StringBuilder();
        patternASentenceStringBuilder.Append("Pattern A ");
        patternASentenceStringBuilder.Append(_currentVisitEco!.PatternA ? "presente.\n" : "non presente.\n");
        _patternASentence = patternASentenceStringBuilder.ToString();
    }
    
    private void UpdateBLinesSentence()
    {
        var bLinesSentenceStringBuilder = new StringBuilder();
        if (_currentVisitEco!.BLines)
        {
            bLinesSentenceStringBuilder.Append("Linee B presenti, ");
            bLinesSentenceStringBuilder.Append(_currentVisitEco!.CoalescentBLines.GetValueOrDefault()
                ? "coalescenti, "
                : "non coalescenti, ");
            bLinesSentenceStringBuilder.Append(_currentVisitEco!.GradientDistributionBLines.GetValueOrDefault()
                ? "con "
                : "senza ");
            bLinesSentenceStringBuilder.Append("gradiente di distribuzione.\n");
        } else bLinesSentenceStringBuilder.Append("Assenza di linee B.\n");
        
        _bLinesSentence = bLinesSentenceStringBuilder.ToString();
    }
    
    private void UpdatePefsSentence()
    {
        var pefsStringBuilder = new StringBuilder();
        if (_currentVisitEco!.RightPefs is null && _currentVisitEco.LeftPefs is null)
        {
            _pefsSentence = null;
            return;
        }
        
        if (_currentVisitEco!.RightPefs is null && _currentVisitEco.LeftPefs is not null) pefsStringBuilder.Append($"PEFS sinistro {_currentVisitEco!.LeftPefs}.\n");
        else if (_currentVisitEco!.RightPefs is not null && _currentVisitEco.LeftPefs is null) pefsStringBuilder.Append($"PEFS destro {_currentVisitEco!.RightPefs}.\n");
        else pefsStringBuilder.Append($"PEFS destro {_currentVisitEco!.RightPefs} e PEFS sinistro {_currentVisitEco!.LeftPefs}.\n");
        _pefsSentence = pefsStringBuilder.ToString();
    }
    
    private void UpdateVciSentence()
    {
        var vciSentenceStringBuilder = new StringBuilder();
        if (!_currentVisitEco!.MeasurableIvc)
        {
            _vciSentence = "VCI non campionabile.\n";
            return;
        }

        vciSentenceStringBuilder.Append("VCI campionabile, ");
        vciSentenceStringBuilder.Append("con diametro ");
        vciSentenceStringBuilder.Append(_currentVisitEco!.IvcDiameter);
        vciSentenceStringBuilder.Append(", collassabilità ");
        vciSentenceStringBuilder.Append(_currentVisitEco!.IvcCollapsibility);

        if (_currentVisitEco!.IvcDiameter != StringChoices.IvcDiameterTypes[0])
        {
            vciSentenceStringBuilder.Append(".\n");
            _vciSentence = vciSentenceStringBuilder.ToString();
            return;
        }

        if (_currentVisitEco!.Vexus is not null)
        {
            vciSentenceStringBuilder.Append(", VEXUS con valore ");
            vciSentenceStringBuilder.Append(_currentVisitEco!.Vexus);
        }
        vciSentenceStringBuilder.Append(" e pulsatilità portale ");
        vciSentenceStringBuilder.Append(_currentVisitEco!.PortalVeinPulsatility);
        vciSentenceStringBuilder.Append('.');
        _vciSentence = vciSentenceStringBuilder.ToString();
    }
    
    public void LoadEcografiaToracicaContent(VisitEco currentVisitEco)
    {
        _currentVisitEco = currentVisitEco;
        UpdatePleuralLineSentence();
        UpdatePatternASentence();
        UpdateBLinesSentence();
        UpdatePefsSentence();
        UpdateVciSentence();
        UpdateAutomaticColumnBDescription();
    }

    private void UpdateAutomaticColumnBDescription()
    {
        var columnBDescriptionStringBuilder = new StringBuilder();
        columnBDescriptionStringBuilder.Append(_pleuralLineSentence);
        columnBDescriptionStringBuilder.Append(_patternASentence);
        columnBDescriptionStringBuilder.Append(_bLinesSentence);
        columnBDescriptionStringBuilder.Append(_pefsSentence);
        columnBDescriptionStringBuilder.Append(_vciSentence);
        Dispatcher.UIThread.Post(() => { AutomaticColumnB!.Text = columnBDescriptionStringBuilder.ToString(); });
    }
    
    private void CopyToManualText(object? sender, RoutedEventArgs routedEventArgs)
    {
        _currentVisitEco!.EcoManualText = AutomaticColumnB.Text;
    }
}