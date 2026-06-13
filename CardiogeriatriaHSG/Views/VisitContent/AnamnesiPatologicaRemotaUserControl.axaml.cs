using System;
using Avalonia.Controls;
using Avalonia.Threading;
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
                _currentVisitApr = viewModel.CurrentVisitApr!;
            }
        };
    }
    
    private VisitApr? _currentVisitApr;

    
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
                _currentVisitApr!.Amyloidosis = value == "True";
                if (_currentVisitApr.Amyloidosis)
                {
                    _currentVisitApr.AmyloidosisType ??= StringChoices.AmyloidosisTypes[0];
                    _currentVisitApr.AmyloidosisDiagnosisDate ??= now;
                    _currentVisitApr.AmyloidosisDmt ??= false;
                    _currentVisitApr.AmyloidosisTherapyStartDate ??= now;
                    Dispatcher.UIThread.Post(() => AmyloidosisWrapPanel.IsVisible = true);
                }
                else
                {
                    _currentVisitApr.AmyloidosisType = null;
                    _currentVisitApr.AmyloidosisDiagnosisDate = null;
                    _currentVisitApr.AmyloidosisDmt = null;
                    _currentVisitApr.AmyloidosisTherapyStartDate = null;
                    Dispatcher.UIThread.Post(() => AmyloidosisWrapPanel.IsVisible = false);
                }
                break;
            case "Dementia":
                _currentVisitApr!.Dementia = value == "True";
                if (_currentVisitApr.Dementia)
                {
                    _currentVisitApr.DementiaType ??= StringChoices.DementiaTypes[0];
                    Dispatcher.UIThread.Post(() => DementiaTypeWrapPanel.IsVisible = true);
                }
                else
                {
                    _currentVisitApr.DementiaType = null;
                    Dispatcher.UIThread.Post(() => DementiaTypeWrapPanel.IsVisible = false);
                }
                break;
        }
    }
}