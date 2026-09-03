using System;
using System.Text;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using CardiogeriatriaHSG.Models;
using CardiogeriatriaHSG.ViewModels.VisitContent;

namespace CardiogeriatriaHSG.Views.VisitContent;

public partial class AnagraficaUserControl : UserControl
{
    public AnagraficaUserControl()
    {
        InitializeComponent();
        DataContextChanged += (_, __) =>
        {
            if (DataContext is not AnagraficaUserControlViewModel viewModel) return;
            _currentPatient = viewModel.CurrentPatient;
            _visitTimestamp = viewModel.CurrentVisitTimestamp;
            LoadAnagraficaContent(_currentPatient, _visitTimestamp);
        };
    }
    
    private Patient? _currentPatient;
    private DateTimeOffset _visitTimestamp;

    private string? _registrySentence;
    private string? _heartFailureSentence;

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
            case "Gender":
                _currentPatient!.Gender = value!;
                UpdateRegistrySentence();
                break;
            case "HeartFailureStadium":
                _currentPatient!.HeartFailureStadium = value!;
                UpdateHeartFailureSentence();
                break;
            case "HeartFailurePercentage":
                _currentPatient!.HeartFailurePercentage = value is null ? null : int.Parse(value);
                UpdateHeartFailureSentence();
                break;
            case "HeartFailureEjectionFraction":
                _currentPatient!.HeartFailureEjectionFraction = value!;
                UpdateHeartFailureSentence();
                break;
            case "HeartFailureEtiologyHypertensive":
                _currentPatient!.HeartFailureEtiologyHypertensive  = value == "True";
                UpdateHeartFailureSentence();
                break;
            case "HeartFailureEtiologyArrhythmic":
                _currentPatient!.HeartFailureEtiologyArrhythmic  = value == "True";
                UpdateHeartFailureSentence();
                break;
            case "HeartFailureEtiologyIschemic":
                _currentPatient!.HeartFailureEtiologyIschemic  = value == "True";
                UpdateHeartFailureSentence();
                break;
            case "HeartFailureEtiologyValvular":
                _currentPatient!.HeartFailureEtiologyValvular  = value == "True";
                UpdateHeartFailureSentence();
                break;
            case "HeartFailureEtiologyInfiltrative":
                _currentPatient!.HeartFailureEtiologyInfiltrative  = value == "True";
                UpdateHeartFailureSentence();
                break;
        }

        UpdateColumnBDescription();
    }
    
    private void OnColumnADatePickerChanged(object? sender, DatePickerSelectedValueChangedEventArgs e)
    {
        var datePicker = (DatePicker)sender!;
        _currentPatient!.DateOfBirth = (DateTimeOffset)datePicker.SelectedDate!;
        UpdateRegistrySentence();
    }
    
    private void UpdateRegistrySentence()
    {
        var registrySentenceBuilder = new StringBuilder();
        
        var visitDate = _visitTimestamp;
        
        registrySentenceBuilder.Append(_currentPatient!.Gender == "M" ? "Uomo di " : "Donna di ");
        var age = visitDate.Year - _currentPatient!.DateOfBirth!.Value.Year;
        if (_currentPatient!.DateOfBirth > visitDate.AddYears(-age)) age--;
        registrySentenceBuilder.Append(age + " anni al momento della visita.\n");
        _registrySentence = registrySentenceBuilder.ToString();
    }
    
    private void UpdateHeartFailureSentence()
    {
        var heartFailureSentenceBuilder = new StringBuilder();
        
        if (_currentPatient!.HeartFailureStadium is null || _currentPatient.HeartFailurePercentage is null || _currentPatient.HeartFailureEjectionFraction is null)
        {
            _heartFailureSentence = heartFailureSentenceBuilder.ToString();
            return;
        }
        
        heartFailureSentenceBuilder.Append("Paziente noto per insufficienza cardiaca stadio ");
        heartFailureSentenceBuilder.Append(_currentPatient.HeartFailureStadium);
        heartFailureSentenceBuilder.Append($" a frazione di eiezione {_currentPatient.HeartFailureEjectionFraction.ToLower()} ({_currentPatient.HeartFailurePercentage}%)");
        
        var heartFailureSubSentenceBuilder = new StringBuilder();
        if (_currentPatient!.HeartFailureEtiologyHypertensive) heartFailureSubSentenceBuilder.Append($"{HeartFailureEtiologyHypertensive.Text!.ToLower().Replace("    •", "")},");
        if (_currentPatient!.HeartFailureEtiologyArrhythmic) heartFailureSubSentenceBuilder.Append($"{HeartFailureEtiologyArrhythmic.Text!.ToLower().Replace("    •", "")},");
        if (_currentPatient!.HeartFailureEtiologyIschemic) heartFailureSubSentenceBuilder.Append($"{HeartFailureEtiologyIschemic.Text!.ToLower().Replace("    •", "")},");
        if (_currentPatient!.HeartFailureEtiologyValvular) heartFailureSubSentenceBuilder.Append($"{HeartFailureEtiologyValvular.Text!.ToLower().Replace("    •", "")},");
        if (_currentPatient!.HeartFailureEtiologyInfiltrative) heartFailureSubSentenceBuilder.Append($"{HeartFailureEtiologyInfiltrative.Text!.ToLower().Replace("    •", "")},");
        var heartFailureSub = heartFailureSubSentenceBuilder.ToString();

        if (heartFailureSub.Length == 0) heartFailureSentenceBuilder.Append(" a nessuna eziologia");
        else
        {
            heartFailureSentenceBuilder.Append(" a eziologia ");
            if (heartFailureSub.EndsWith(',')) heartFailureSub = heartFailureSub[..^1].Trim();
            heartFailureSentenceBuilder.Append(heartFailureSub);
        }
        heartFailureSentenceBuilder.Append(".\n");
        _heartFailureSentence = heartFailureSentenceBuilder.ToString();
    }

    public void LoadAnagraficaContent(Patient currentPatient, DateTimeOffset visitTimestamp)
    {
        _currentPatient = currentPatient;
        _visitTimestamp = visitTimestamp;
        UpdateRegistrySentence();
        UpdateHeartFailureSentence();
        UpdateColumnBDescription();
    }

    private void UpdateColumnBDescription()
    {
        var columnBDescriptionStringBuilder = new StringBuilder();
        columnBDescriptionStringBuilder.Append(_registrySentence);
        columnBDescriptionStringBuilder.Append(_heartFailureSentence);
        Dispatcher.UIThread.Post(() => { AutomaticColumnB!.Text = columnBDescriptionStringBuilder.ToString(); });
    }

    private void CopyToManualText(object? sender, RoutedEventArgs routedEventArgs)
    {
        _currentPatient!.PatientManualText = AutomaticColumnB.Text;
    }
}