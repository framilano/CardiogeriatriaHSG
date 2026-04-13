using System;
using System.Text;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using SchedaVisite.Models.enums.anagrafica;
using SchedaVisite.ViewModels.VisitContent;

namespace SchedaVisite.Views.VisitContent;

public partial class AnagraficaUserControl : UserControl
{
    public AnagraficaUserControl()
    {
        InitializeComponent();
        _columnBDescription = this.Find<TextBlock>("ColumnBDescription");
    }
    
    private TextBlock? _columnBDescription;

    public void OnGenderChanged(object? sender, RoutedEventArgs routedEventArgs)
    {
        var anagraficaUserControlViewModel = DataContext as AnagraficaUserControlViewModel;

        var gender = ((ComboBox)sender!).SelectedValue.ToString();
        var dateOfBirth = anagraficaUserControlViewModel.CurrentPatient.DateOfBirth;
        _updateColumnBDescription(gender, dateOfBirth);
    }

    private void OnDateOfBirthChanged(object? sender,
        DatePickerSelectedValueChangedEventArgs datePickerSelectedValueChangedEventArgs)
    {
        var anagraficaUserControlViewModel = DataContext as AnagraficaUserControlViewModel;

        var dateOfBirth = ((DatePicker)sender!).SelectedDate.Value;
        var gender = anagraficaUserControlViewModel.CurrentPatient.Gender;
        _updateColumnBDescription(gender, dateOfBirth);
    }

    private void _updateColumnBDescription(string gender, DateTimeOffset dateOfBirth)
    {
        var vm = DataContext as AnagraficaUserControlViewModel;
        
        var visitDate = vm.CurrentVisit.Timestamp;
        
        var stringBuilder = new StringBuilder();

        stringBuilder.Append(gender == "M" ? "Uomo di " : "Donna di ");
        var age = visitDate.Year - dateOfBirth.Year;
        if (dateOfBirth > visitDate.AddYears(-age))
            age--;
        stringBuilder.Append(age + " anni.");
        
        _columnBDescription.Text = stringBuilder.ToString();
    }
}