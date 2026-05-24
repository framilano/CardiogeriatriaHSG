using System.Text;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using CardiogeriatriaHSG.Models;
using CardiogeriatriaHSG.Models.enums;
using CardiogeriatriaHSG.ViewModels.VisitContent;

namespace CardiogeriatriaHSG.Views.VisitContent;

public partial class RaccordoClinicoUserControl : UserControl
{
    public RaccordoClinicoUserControl()
    {
        InitializeComponent();
        _columnBDescription = this.Find<TextBlock>("ColumnBDescription");
        DataContextChanged += (_, __) =>
        {
            if (DataContext is not RaccordoClinicoUserControlViewModel viewModel) return;
            _currentVisit = viewModel.CurrentVisit;
            LoadRaccordoClinicoContent(_currentVisit);
        };
    }
    
    private Visit? _currentVisit;
    private readonly TextBlock? _columnBDescription;

    private string? _reportsSentence;
    private string? _fallsSinceLastVisitSentence;
    private string? _emergenciesSinceLastVisitSentence;
    private string? _hospitalizationsSinceLastVisitSentence;


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
                value = box.Value.ToString();
                break;
        }
        
        switch (tag) 
        {
            case "ReportTypes":
                _currentVisit!.VisitRc!.Reports = value;
                UpdateReportsSentence();
                break;
            case "FallsSinceLastVisit":
                _currentVisit!.VisitRc!.FallsSinceLastVisit = value == "True";
                if (_currentVisit!.VisitRc!.FallsSinceLastVisit)
                {
                    _currentVisit.VisitRc.FallsSinceLastVisitNumber ??= 0;
                    _currentVisit.VisitRc.FallsSinceLastVisitType ??= StringChoices.FallsSinceLastVisitTypes[0];
                    FallsSinceLastVisitWrapPanel.IsVisible = true;
                }
                else
                {
                    _currentVisit.VisitRc.FallsSinceLastVisitNumber ??= null;
                    _currentVisit.VisitRc.FallsSinceLastVisitType ??= null;
                    FallsSinceLastVisitWrapPanel.IsVisible = false;
                }
                UpdateFallsSinceLastVisitSentence();
                break;
            case "EmergenciesSinceLastVisit":
                _currentVisit!.VisitRc!.EmergenciesSinceLastVisit = value == "True";
                if (_currentVisit!.VisitRc!.EmergenciesSinceLastVisit)
                {
                    _currentVisit.VisitRc.EmergenciesSinceLastVisitNumber ??= 0;
                    _currentVisit.VisitRc.EmergenciesSinceLastVisitCause ??= StringChoices.EmergenciesSinceLastVisitCauses[0];
                    EmergenciesSinceLastVisitWrapPanel.IsVisible = true;
                }
                else
                {
                    _currentVisit.VisitRc.EmergenciesSinceLastVisitNumber ??= null;
                    _currentVisit.VisitRc.EmergenciesSinceLastVisitCause ??= null;
                    EmergenciesSinceLastVisitWrapPanel.IsVisible = false;
                }
                UpdateEmergenciesSinceLastVisitSentence();
                break;
            case "HospitalizationsSinceLastVisit":
                _currentVisit!.VisitRc!.HospitalizationsSinceLastVisit = value == "True";
                if (_currentVisit!.VisitRc!.HospitalizationsSinceLastVisit)
                {
                    _currentVisit.VisitRc.HospitalizationsSinceLastVisitNumber ??= 0;
                    _currentVisit.VisitRc.HospitalizationsSinceLastVisitDays ??= 0;
                    _currentVisit.VisitRc.HospitalizationsSinceLastVisitCause ??= StringChoices.HospitalizationsSinceLastVisitCauses[0];
                    HospitalizationsSinceLastVisitWrapPanel.IsVisible = true;
                }
                else
                {
                    _currentVisit.VisitRc.HospitalizationsSinceLastVisitNumber ??= null;
                    _currentVisit.VisitRc.HospitalizationsSinceLastVisitDays ??= null;
                    _currentVisit.VisitRc.HospitalizationsSinceLastVisitCause ??= null;
                    HospitalizationsSinceLastVisitWrapPanel.IsVisible = false;
                }
                UpdateHospitalizationsSinceLastVisitSentence();
                break;
        }
        
        
        UpdateColumnBDescription();
    }
    
    private void UpdateReportsSentence()
    {
        var reportsSentenceBuilder = new StringBuilder();
        reportsSentenceBuilder.Append("Riferisce ");
        reportsSentenceBuilder.Append(_currentVisit!.VisitRc!.Reports!.ToLower());
        reportsSentenceBuilder.Append('.');
        reportsSentenceBuilder.Append('\n');
        _reportsSentence = reportsSentenceBuilder.ToString();
    }
    
    
    private void UpdateFallsSinceLastVisitSentence()
    {
       
    }
    
    private void UpdateEmergenciesSinceLastVisitSentence()
    {

    }
    
    private void UpdateHospitalizationsSinceLastVisitSentence()
    {

    }
    
    public void LoadRaccordoClinicoContent(Visit currentVisit)
    {
        _currentVisit = currentVisit;
        UpdateReportsSentence();
        UpdateFallsSinceLastVisitSentence();
        UpdateEmergenciesSinceLastVisitSentence();
        UpdateHospitalizationsSinceLastVisitSentence();
        UpdateColumnBDescription();
    }

    private void UpdateColumnBDescription()
    {
        var columnBDescriptionStringBuilder = new StringBuilder();
        columnBDescriptionStringBuilder.Append(_reportsSentence);
        columnBDescriptionStringBuilder.Append(_fallsSinceLastVisitSentence);
        columnBDescriptionStringBuilder.Append(_emergenciesSinceLastVisitSentence);
        columnBDescriptionStringBuilder.Append(_hospitalizationsSinceLastVisitSentence);

        Dispatcher.UIThread.Post(() => { _columnBDescription!.Text = columnBDescriptionStringBuilder.ToString(); });
    }
}