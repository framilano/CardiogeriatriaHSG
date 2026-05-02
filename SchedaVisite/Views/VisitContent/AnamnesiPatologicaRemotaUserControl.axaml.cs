using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using SchedaVisite.Models;
using SchedaVisite.ViewModels.VisitContent;

namespace SchedaVisite.Views.VisitContent;

public partial class AnamnesiPatologicaRemotaUserControl : UserControl
{
    public AnamnesiPatologicaRemotaUserControl()
    {
        InitializeComponent();
        _columnBDescription = this.Find<TextBox>("ColumnBDescription");
        DataContextChanged += (_, __) =>
        {
            if (DataContext is AnamnesiPatologicaRemotaUserControlViewModel viewModel)
            {
                _currentVisit = viewModel.CurrentVisit!;
            }
        };
    }
    
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
        }
        
        var now = DateTimeOffset.Now;
        
        switch (tag) 
        {
            case "Amyloidosis":
                _currentVisit!.Amyloidosis = value == "True";
                if (_currentVisit!.Amyloidosis)
                {
                    _currentVisit.AmyloidosisType ??= "ATTR-WT";
                    AmyloidosisTypeComboBox.IsVisible = true;
                    AmyloidosisTypeTextBlock.IsVisible = true;
                    
                    _currentVisit.AmyloidosisDiagnosisDate ??= now;
                    AmyloidosisDiagnosisDateDatePicker.IsVisible = true;
                    AmyloidosisDiagnosisDateTextBlock.IsVisible = true;
                    
                    _currentVisit.AmyloidosisDmt ??= false;
                    AmyloidosisDmtTextBlock.IsVisible = true;
                    AmyloidosisDmtCheckBox.IsVisible = true;
                    
                    _currentVisit.AmyloidosisTherapyStartDate ??= now;
                    AmyloidosisTherapyStartDateDatePicker.IsVisible = true;
                    AmyloidosisTherapyStartDateTextBlock.IsVisible = true;
                }
                else
                {
                    _currentVisit!.AmyloidosisType = null;
                    AmyloidosisTypeComboBox.IsVisible = false;
                    AmyloidosisTypeTextBlock.IsVisible = false;
                    
                    _currentVisit!.AmyloidosisDiagnosisDate = null;
                    AmyloidosisDiagnosisDateDatePicker.IsVisible = false;
                    AmyloidosisDiagnosisDateTextBlock.IsVisible = false;
                    
                    _currentVisit!.AmyloidosisDmt = null;
                    AmyloidosisDmtCheckBox.IsVisible = false;
                    AmyloidosisDmtTextBlock.IsVisible = false;
                    
                    _currentVisit!.AmyloidosisTherapyStartDate = null;
                    AmyloidosisTherapyStartDateDatePicker.IsVisible = false;
                    AmyloidosisTherapyStartDateTextBlock.IsVisible = false;
                }
                break;
            case "Dementia":
                _currentVisit!.Dementia = value == "True";
                if (_currentVisit!.Dementia)
                {
                    _currentVisit.DementiaType ??= "Neurodegenerativa";
                    DementiaTypeComboBox.IsVisible = true;
                    DementiaTypeTextBlock.IsVisible = true;
                }
                else
                {
                    _currentVisit!.DementiaType = null;
                    DementiaTypeComboBox.IsVisible = false;
                    DementiaTypeTextBlock.IsVisible = false;
                }
                break;
        }
    }
    
    private Visit? _currentVisit;
    private readonly TextBox? _columnBDescription;
}