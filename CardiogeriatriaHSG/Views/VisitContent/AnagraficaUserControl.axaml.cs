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
        _columnBDescription = this.Find<TextBlock>("ColumnBDescription");
        _registrySentence = "";
        DataContextChanged += (_, __) =>
        {
            if (DataContext is not AnagraficaUserControlViewModel vm) return;
            _currentVisit = vm.CurrentVisit;
            LoadAnagraficaContent(_currentVisit);
        };
    }
    
    private Visit? _currentVisit;

    private string _registrySentence;
    private readonly TextBlock? _columnBDescription;

    public void OnColumnAChanged(object? sender, RoutedEventArgs routedEventArgs)
    {
        var gender = (ComboBox)sender!;
        _currentVisit!.Patient!.Gender = gender.SelectedValue!.ToString();
        UpdateRegistrySentence();
    }
    
    private void OnColumnADatePickerChanged(object? sender, DatePickerSelectedValueChangedEventArgs e)
    {
        var datePicker = (DatePicker)sender!;
        _currentVisit!.Patient!.DateOfBirth = (DateTimeOffset)datePicker.SelectedDate!;
        UpdateRegistrySentence();
    }
    
    private void UpdateRegistrySentence()
    {
        var registrySentenceBuilder = new StringBuilder();
        
        var visitDate = _currentVisit!.Timestamp;
        
        registrySentenceBuilder.Append(_currentVisit!.Patient!.Gender == "M" ? "Uomo di " : "Donna di ");
        var age = visitDate.Year - _currentVisit!.Patient!.DateOfBirth!.Value.Year;
        if (_currentVisit!.Patient!.DateOfBirth > visitDate.AddYears(-age)) age--;
        registrySentenceBuilder.Append(age + " anni al momento della visita");
        
        registrySentenceBuilder.Append('.');
        registrySentenceBuilder.Append('\n');
        _registrySentence = registrySentenceBuilder.ToString();
        UpdateColumnBDescription();
    }

    public void LoadAnagraficaContent(Visit currentVisit)
    {
        _currentVisit = currentVisit;
        UpdateRegistrySentence();
    }

    private void UpdateColumnBDescription()
    {
        var columnBDescriptionStringBuilder = new StringBuilder();
        columnBDescriptionStringBuilder.Append(_registrySentence);
        Dispatcher.UIThread.Post(() => { _columnBDescription!.Text = columnBDescriptionStringBuilder.ToString(); });
    }
}