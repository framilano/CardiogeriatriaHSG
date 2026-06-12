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
            case "PleuralLine":
                _currentVisitEco!.PleuralLine = value == "True";
                UpdatePleuralLineSentence();
                break;
            case "IrregularPleuralLine":
                _currentVisitEco!.IrregularPleuralLine = value == "True";
                UpdatePleuralLineSentence();
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
    
    
    public void LoadEcografiaToracicaContent(VisitEco currentVisitEco)
    {
        _currentVisitEco = currentVisitEco;
        UpdatePleuralLineSentence();
        UpdateColumnBDescription();
    }

    private void UpdateColumnBDescription()
    {
        var columnBDescriptionStringBuilder = new StringBuilder();
        columnBDescriptionStringBuilder.Append(_pleuralLineSentence);
        
        Dispatcher.UIThread.Post(() => { AutomaticColumnB!.Text = columnBDescriptionStringBuilder.ToString(); });
    }
}