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

    public void OnColumnAChanged(object? sender, RoutedEventArgs routedEventArgs)
    {
        var gender = (ComboBox)sender!;
        _currentPatient!.Gender = gender.SelectedValue!.ToString();
        UpdateRegistrySentence();
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
        registrySentenceBuilder.Append(age + " anni al momento della visita");
        
        registrySentenceBuilder.Append('.');
        _registrySentence = registrySentenceBuilder.ToString();
        UpdateColumnBDescription();
    }

    public void LoadAnagraficaContent(Patient currentPatient, DateTimeOffset visitTimestamp)
    {
        _currentPatient = currentPatient;
        _visitTimestamp = visitTimestamp;
        UpdateRegistrySentence();
    }

    private void UpdateColumnBDescription()
    {
        var columnBDescriptionStringBuilder = new StringBuilder();
        columnBDescriptionStringBuilder.Append(_registrySentence);
        Dispatcher.UIThread.Post(() => { AutomaticColumnB!.Text = columnBDescriptionStringBuilder.ToString(); });
    }

    private void CopyToManualText(object? sender, RoutedEventArgs routedEventArgs)
    {
        _currentPatient!.PatientManualText = AutomaticColumnB.Text;
    }
}