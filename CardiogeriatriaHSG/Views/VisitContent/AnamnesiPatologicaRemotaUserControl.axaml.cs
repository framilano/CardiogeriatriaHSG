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
                    AmyloidosisTypeWrapPanel.IsVisible = true;
                    
                    _currentVisit.VisitApr.AmyloidosisDiagnosisDate ??= now;
                    AmyloidosisDiagnosisDateWrapPanel.IsVisible = true;
                    
                    _currentVisit.VisitApr.AmyloidosisDmt ??= false;
                    AmyloidosisDmtWrapPanel.IsVisible = true;
                    
                    _currentVisit.VisitApr.AmyloidosisTherapyStartDate ??= now;
                    AmyloidosisTherapyStartDateWrapPanel.IsVisible = true;
                }
                else
                {
                    _currentVisit!.VisitApr!.AmyloidosisType = null;
                    AmyloidosisTypeWrapPanel.IsVisible = false;
                    
                    _currentVisit!.VisitApr!.AmyloidosisDiagnosisDate = null;
                    AmyloidosisDiagnosisDateWrapPanel.IsVisible = false;
                    
                    _currentVisit!.VisitApr!.AmyloidosisDmt = null;
                    AmyloidosisDmtWrapPanel.IsVisible = false;
                    
                    _currentVisit!.VisitApr!.AmyloidosisTherapyStartDate = null;
                    AmyloidosisTherapyStartDateWrapPanel.IsVisible = false;
                }
                break;
            case "Dementia":
                _currentVisit!.VisitApr!.Dementia = value == "True";
                if (_currentVisit!.VisitApr!.Dementia)
                {
                    _currentVisit.VisitApr.DementiaType ??= "Neurodegenerativa";
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