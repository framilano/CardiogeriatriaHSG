using System;
using System.Text;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using CardiogeriatriaHSG.Models;
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
        }
        UpdateColumnBDescription();
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
    
    
    public void LoadEcografiaToracicaContent(VisitEco currentVisitEco)
    {
        _currentVisitEco = currentVisitEco;
        UpdatePleuralLineSentence();
        UpdateBLinesSentence();
        UpdateColumnBDescription();
    }

    private void UpdateColumnBDescription()
    {
        var columnBDescriptionStringBuilder = new StringBuilder();
        columnBDescriptionStringBuilder.Append(_pleuralLineSentence);
        columnBDescriptionStringBuilder.Append(_bLinesSentence);
        Dispatcher.UIThread.Post(() => { AutomaticColumnB!.Text = columnBDescriptionStringBuilder.ToString(); });
    }
}