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
        }
        UpdateColumnBDescription();
    }
    
    //Doesn't make sense to have multiple update methods for these easy-to-build sentences
    private void UpdateBloodPressureSentence()
    {
       
    }
    
    public void LoadEsamiObiettivoContent(VisitEo currentVisitEo)
    {
        _currentVisitEo = currentVisitEo;
        UpdateBloodPressureSentence();
        UpdateColumnBDescription();
    }

    private void UpdateColumnBDescription()
    {
        var columnBDescriptionStringBuilder = new StringBuilder();
        columnBDescriptionStringBuilder.Append(_bloodPressureSentence);

        Dispatcher.UIThread.Post(() => { _columnBDescription!.Text = columnBDescriptionStringBuilder.ToString(); });
    }
}