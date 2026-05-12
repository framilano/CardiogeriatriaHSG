using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using CardiogeriatriaHSG.Models;
using CardiogeriatriaHSG.ViewModels.VisitContent;

namespace CardiogeriatriaHSG.Views.VisitContent;

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
                _currentVisit!.VisitApr!.Amyloidosis = value == "True";
                if (_currentVisit!.VisitApr!.Amyloidosis)
                {
                    _currentVisit.VisitApr.AmyloidosisType ??= "ATTR-WT";
                    AmyloidosisTypeComboBox.IsVisible = true;
                    AmyloidosisTypeTextBlock.IsVisible = true;
                    
                    _currentVisit.VisitApr.AmyloidosisDiagnosisDate ??= now;
                    AmyloidosisDiagnosisDateDatePicker.IsVisible = true;
                    AmyloidosisDiagnosisDateTextBlock.IsVisible = true;
                    
                    _currentVisit.VisitApr.AmyloidosisDmt ??= false;
                    AmyloidosisDmtTextBlock.IsVisible = true;
                    AmyloidosisDmtCheckBox.IsVisible = true;
                    
                    _currentVisit.VisitApr.AmyloidosisTherapyStartDate ??= now;
                    AmyloidosisTherapyStartDateDatePicker.IsVisible = true;
                    AmyloidosisTherapyStartDateTextBlock.IsVisible = true;
                }
                else
                {
                    _currentVisit!.VisitApr!.AmyloidosisType = null;
                    AmyloidosisTypeComboBox.IsVisible = false;
                    AmyloidosisTypeTextBlock.IsVisible = false;
                    
                    _currentVisit!.VisitApr!.AmyloidosisDiagnosisDate = null;
                    AmyloidosisDiagnosisDateDatePicker.IsVisible = false;
                    AmyloidosisDiagnosisDateTextBlock.IsVisible = false;
                    
                    _currentVisit!.VisitApr!.AmyloidosisDmt = null;
                    AmyloidosisDmtCheckBox.IsVisible = false;
                    AmyloidosisDmtTextBlock.IsVisible = false;
                    
                    _currentVisit!.VisitApr!.AmyloidosisTherapyStartDate = null;
                    AmyloidosisTherapyStartDateDatePicker.IsVisible = false;
                    AmyloidosisTherapyStartDateTextBlock.IsVisible = false;
                }
                break;
            case "Dementia":
                _currentVisit!.VisitApr!.Dementia = value == "True";
                if (_currentVisit!.VisitApr!.Dementia)
                {
                    _currentVisit.VisitApr.DementiaType ??= "Neurodegenerativa";
                    DementiaTypeComboBox.IsVisible = true;
                    DementiaTypeTextBlock.IsVisible = true;
                }
                else
                {
                    _currentVisit!.VisitApr!.DementiaType = null;
                    DementiaTypeComboBox.IsVisible = false;
                    DementiaTypeTextBlock.IsVisible = false;
                }
                break;
        }
    }
    
    private Visit? _currentVisit;
    private readonly TextBox? _columnBDescription;
}