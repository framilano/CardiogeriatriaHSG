using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using CardiogeriatriaHSG.Models;
using CardiogeriatriaHSG.Models.enums;
using CardiogeriatriaHSG.ViewModels.VisitContent;

namespace CardiogeriatriaHSG.Views.VisitContent;

public partial class AnamnesiPatologicaRemotaUserControl : UserControl
{
    public AnamnesiPatologicaRemotaUserControl()
    {
        InitializeComponent();
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
                    _currentVisit.VisitApr.AmyloidosisType ??= StringChoices.AmyloidosisTypes[0];
                    _currentVisit.VisitApr.AmyloidosisDiagnosisDate ??= now;
                    _currentVisit.VisitApr.AmyloidosisDmt ??= false;
                    _currentVisit.VisitApr.AmyloidosisTherapyStartDate ??= now;
                    AmyloidosisWrapPanel.IsVisible = true;
                }
                else
                {
                    _currentVisit!.VisitApr!.AmyloidosisType = null;
                    _currentVisit!.VisitApr!.AmyloidosisDiagnosisDate = null;
                    _currentVisit!.VisitApr!.AmyloidosisDmt = null;
                    _currentVisit!.VisitApr!.AmyloidosisTherapyStartDate = null;
                    AmyloidosisWrapPanel.IsVisible = false;
                }
                break;
            case "Dementia":
                _currentVisit!.VisitApr!.Dementia = value == "True";
                if (_currentVisit!.VisitApr!.Dementia)
                {
                    _currentVisit.VisitApr.DementiaType ??= StringChoices.DementiaTypes[0];
                    DementiaTypeWrapPanel.IsVisible = true;
                }
                else
                {
                    _currentVisit!.VisitApr!.DementiaType = null;
                    DementiaTypeWrapPanel.IsVisible = false;
                }
                break;
        }
    }
    
    private Visit? _currentVisit;
}