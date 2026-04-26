using System;
using System.Text;
using Avalonia.Controls;
using Avalonia.Interactivity;
using SchedaVisite.Models;
using SchedaVisite.ViewModels.VisitContent;

namespace SchedaVisite.Views.VisitContent;

public partial class AnagraficaUserControl : UserControl
{
    public AnagraficaUserControl()
    {
        InitializeComponent();
        _columnBDescription = this.Find<TextBlock>("ColumnBDescription");
        DataContextChanged += (_, __) =>
        {
            if (DataContext is not AnagraficaUserControlViewModel vm) return;
            _currentVisit = vm.CurrentVisit!;
            _currentPatient = vm.CurrentPatient!;
        };
    }
    
    private Visit? _currentVisit;
    private Patient? _currentPatient;

    private string _registrySentence;
    private readonly TextBlock? _columnBDescription;

    public void OnColumnADatePickerChanged(object? sender, DatePickerSelectedValueChangedEventArgs datePickerSelectedValueChangedEventArgs)
    {
        var datePicker = (DatePicker)sender!;
        _currentPatient!.DateOfBirth = (DateTimeOffset)datePicker.SelectedDate!;
        UpdateRegistrySentence();
    }

    
    public void OnColumnAGenderChanged(object? sender, RoutedEventArgs routedEventArgs)
    {
        var gender = (ComboBox)sender!;
        _currentPatient!.Gender = gender.SelectedValue!.ToString();
        UpdateRegistrySentence();
    }
    
    private void UpdateRegistrySentence()
    {
        var registrySentenceBuilder = new StringBuilder();
        
        var visitDate = _currentVisit!.Timestamp;
        
        registrySentenceBuilder.Append(_currentPatient!.Gender == "M" ? "Uomo di " : "Donna di ");
        var age = visitDate.Year - _currentPatient!.DateOfBirth.Year;
        if (_currentPatient!.DateOfBirth > visitDate.AddYears(-age))
            age--;
        registrySentenceBuilder.Append(age + " anni");
        
        registrySentenceBuilder.Append('.');
        registrySentenceBuilder.Append('\n');
        _registrySentence = registrySentenceBuilder.ToString();
        UpdateColumnBDescription();
    }

    public void LoadAnagraficaContent(Visit currentVisit, Patient currentPatient)
    {
        _currentVisit = currentVisit;
        _currentPatient = currentPatient;
        UpdateRegistrySentence();
    }

    private void UpdateColumnBDescription()
    {
        var columnBDescriptionStringBuilder = new StringBuilder();
        columnBDescriptionStringBuilder.Append(_registrySentence);
        _columnBDescription!.Text = columnBDescriptionStringBuilder.ToString();
    }
}