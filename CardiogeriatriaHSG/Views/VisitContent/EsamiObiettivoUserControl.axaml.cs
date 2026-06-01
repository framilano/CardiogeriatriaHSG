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
                    EdemaWrapPanel.IsVisible = true;
                }
                else
                {
                    _currentVisitEo.DependentEdemaType = null;
                    _currentVisitEo.DependentEdemaLocation = null;
                    _currentVisitEo.DependentEdemaFovea = null;
                    EdemaWrapPanel.IsVisible = false;
                }
                UpdateEdemaSentence();
                break;
            case "PeripheralNeuropathy":
                _currentVisitEo!.PeripheralNeuropathy = value == "True";
                UpdateNeuropathyentence();
                break;
        }
        UpdateColumnBDescription();
    }
    
    //Doesn't make sense to have multiple update methods for these easy-to-build sentences
    private void UpdateBloodPressureSentence()
    {
       
    }
    
    private void UpdateTgAndRegSentence()
    {
       
    }
    
    private void UpdateHeartSoundSentence()
    {
       
    }
    
    private void UpdateChestMvSentence()
    {
       
    }
    
    private void UpdateEdemaSentence()
    {
       
    }
    
    private void UpdateNeuropathyentence()
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