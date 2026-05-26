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
            _currentVisitRc = viewModel.CurrentVisitRc;
            LoadRaccordoClinicoContent(_currentVisitRc);
        };
    }
    
    private VisitRc? _currentVisitRc;
    private readonly TextBlock? _columnBDescription;

    private string? _reportsSentence;
    private string? _lastPeriodSentence;
    private string? _sleepingSentence;
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
                _currentVisitRc!.Reports = value;
                UpdateReportsSentence();
                break;
            case "DyspneaTypes":
                _currentVisitRc!.Dyspnea = value;
                UpdateLastPeriodSentence();
                break;
            case "AnginaTypes":
                _currentVisitRc!.Angina = value;
                UpdateLastPeriodSentence();
                break;
            case "Palpitations":
                _currentVisitRc!.Palpitations = value == "True";
                UpdateLastPeriodSentence();
                break;
            case "SleepingWithPillowsNumber":
                _currentVisitRc!.SleepingWithPillowsNumber = int.Parse(value!);
                UpdateSleepingSentence();
                break;
            case "SleepingSittingPosition":
                _currentVisitRc!.SleepingSittingPosition = value == "True";
                UpdateSleepingSentence();
                break;
            case "ParoxysmalNocturnalDyspnea":
                _currentVisitRc!.ParoxysmalNocturnalDyspnea = value == "True";
                UpdateSleepingSentence();
                break;
            case "AcuteStressLast3Months":
                _currentVisitRc!.AcuteStressLast3Months = value == "True";
                break;
            case "FallsSinceLastVisit":
                _currentVisitRc!.FallsSinceLastVisit = value == "True";
                if (_currentVisitRc!.FallsSinceLastVisit)
                {
                    _currentVisitRc!.FallsSinceLastVisitNumber ??= 0;
                    _currentVisitRc!.FallsSinceLastVisitType ??= StringChoices.FallsSinceLastVisitTypes[0];
                    _currentVisitRc!.FallsSinceLastVisitDiagnosis ??= StringChoices.FallsSinceLastVisitDiagnosis[0];;
                    FallsSinceLastVisitWrapPanel.IsVisible = true;
                }
                else
                {
                    _currentVisitRc!.FallsSinceLastVisitNumber ??= null;
                    _currentVisitRc!.FallsSinceLastVisitType ??= null;
                    _currentVisitRc!.FallsSinceLastVisitDiagnosis ??= null;
                    FallsSinceLastVisitWrapPanel.IsVisible = false;
                }
                UpdateFallsSinceLastVisitSentence();
                break;
            case "FallsSinceLastVisitNumber": 
                _currentVisitRc!.FallsSinceLastVisitNumber = int.Parse(value!);
                UpdateFallsSinceLastVisitSentence();
                break;
            case "FallsSinceLastVisitType":
                _currentVisitRc!.FallsSinceLastVisitType = value;
                UpdateFallsSinceLastVisitSentence();
                break;
            case "FallsSinceLastVisitDiagnosis":
                _currentVisitRc!.FallsSinceLastVisitDiagnosis = value;
                UpdateFallsSinceLastVisitSentence();
                break;
            case "EmergenciesSinceLastVisit":
                _currentVisitRc!.EmergenciesSinceLastVisit = value == "True";
                if (_currentVisitRc!.EmergenciesSinceLastVisit)
                {
                    _currentVisitRc!.EmergenciesSinceLastVisitNumber ??= 0;
                    _currentVisitRc!.EmergenciesSinceLastVisitCause ??= StringChoices.EmergenciesSinceLastVisitCauses[0];
                    EmergenciesSinceLastVisitWrapPanel.IsVisible = true;
                }
                else
                {
                    _currentVisitRc!.EmergenciesSinceLastVisitNumber ??= null;
                    _currentVisitRc!.EmergenciesSinceLastVisitCause ??= null;
                    EmergenciesSinceLastVisitWrapPanel.IsVisible = false;
                }
                UpdateEmergenciesSinceLastVisitSentence();
                break;
            case "EmergenciesSinceLastVisitNumber": 
                _currentVisitRc!.EmergenciesSinceLastVisitNumber = int.Parse(value!);
                UpdateEmergenciesSinceLastVisitSentence();
                break;
            case "EmergenciesSinceLastVisitCause":
                _currentVisitRc!.EmergenciesSinceLastVisitCause = value;
                UpdateEmergenciesSinceLastVisitSentence();
                break;
            case "HospitalizationsSinceLastVisit":
                _currentVisitRc!.HospitalizationsSinceLastVisit = value == "True";
                if (_currentVisitRc!.HospitalizationsSinceLastVisit)
                {
                    _currentVisitRc!.HospitalizationsSinceLastVisitNumber ??= 0;
                    _currentVisitRc!.HospitalizationsSinceLastVisitDays ??= 0;
                    _currentVisitRc!.HospitalizationsSinceLastVisitCause ??= StringChoices.HospitalizationsSinceLastVisitCauses[0];
                    HospitalizationsSinceLastVisitWrapPanel.IsVisible = true;
                }
                else
                {
                    _currentVisitRc!.HospitalizationsSinceLastVisitNumber ??= null;
                    _currentVisitRc!.HospitalizationsSinceLastVisitDays ??= null;
                    _currentVisitRc!.HospitalizationsSinceLastVisitCause ??= null;
                    HospitalizationsSinceLastVisitWrapPanel.IsVisible = false;
                }
                UpdateHospitalizationsSinceLastVisitSentence();
                break;
            case "HospitalizationsSinceLastVisitNumber": 
                _currentVisitRc!.HospitalizationsSinceLastVisitNumber = int.Parse(value!);
                UpdateHospitalizationsSinceLastVisitSentence();
                break;
            case "HospitalizationsSinceLastVisitDays":
                _currentVisitRc!.HospitalizationsSinceLastVisitDays = int.Parse(value!);
                UpdateHospitalizationsSinceLastVisitSentence();
                break;
            case "HospitalizationsSinceLastVisitCause":
                _currentVisitRc!.HospitalizationsSinceLastVisitCause = value;
                UpdateHospitalizationsSinceLastVisitSentence();
                break;
        }
        
        
        UpdateColumnBDescription();
    }
    
    private void UpdateReportsSentence()
    {
        var reportsSentenceBuilder = new StringBuilder();
        reportsSentenceBuilder.Append("Nell'ultimo periodo riferisce ");
        reportsSentenceBuilder.Append(_currentVisitRc!.Reports!.ToLower());
        reportsSentenceBuilder.Append('.');
        reportsSentenceBuilder.Append('\n');
        _reportsSentence = reportsSentenceBuilder.ToString();
    }
    
    private void UpdateLastPeriodSentence()
    {
        var lastPeriodSentenceBuilder = new StringBuilder();
        if (_currentVisitRc!.Dyspnea == "Non dispnea") lastPeriodSentenceBuilder.Append("Senza dispnea, ");
        else
        {
            lastPeriodSentenceBuilder.Append("Con dispnea ");
            lastPeriodSentenceBuilder.Append(_currentVisitRc.Dyspnea!.ToLower());
            lastPeriodSentenceBuilder.Append(", ");
        }

        lastPeriodSentenceBuilder.Append(_currentVisitRc.Angina == "Non angor"
            ? "senza angina e "
            : "con angina e ");
        lastPeriodSentenceBuilder.Append(_currentVisitRc.Palpitations
            ? "con palpitazioni"
            : "senza palpitazioni");
        lastPeriodSentenceBuilder.Append('.');
        lastPeriodSentenceBuilder.Append('\n');
        _lastPeriodSentence = lastPeriodSentenceBuilder.ToString();
    }

    private void UpdateSleepingSentence()
    {
        var sleepingSentenceBuilder = new StringBuilder();
        sleepingSentenceBuilder.Append("Riferisce riposo con ");
        sleepingSentenceBuilder.Append(_currentVisitRc!.SleepingWithPillowsNumber == 1 ? "un cuscino" : "due cuscini");
        if (_currentVisitRc.SleepingSittingPosition) sleepingSentenceBuilder.Append(", dormendo in posizione seduta");
        if (_currentVisitRc.ParoxysmalNocturnalDyspnea) sleepingSentenceBuilder.Append(" e riferisce ortopnea parossistica notturna");
        sleepingSentenceBuilder.Append('.');
        sleepingSentenceBuilder.Append('\n');
        _sleepingSentence = sleepingSentenceBuilder.ToString();
    }
    
    private void UpdateFallsSinceLastVisitSentence()
    {
       var fallsSentenceBuilder = new StringBuilder();
       if (_currentVisitRc!.FallsSinceLastVisit && 
           _currentVisitRc!.FallsSinceLastVisitNumber is not null &&
           _currentVisitRc!.FallsSinceLastVisitType is not null &&
           _currentVisitRc!.FallsSinceLastVisitDiagnosis is not null)
       {
           fallsSentenceBuilder.Append("Riferisce ");
           fallsSentenceBuilder.Append(_currentVisitRc!.FallsSinceLastVisitNumber);
           fallsSentenceBuilder.Append(' ');
           fallsSentenceBuilder.Append(_currentVisitRc!.FallsSinceLastVisitNumber == 1 ? "caduta" : "cadute");
           fallsSentenceBuilder.Append(" da ultima visita, ");
           fallsSentenceBuilder.Append(" per ");
           fallsSentenceBuilder.Append(_currentVisitRc!.FallsSinceLastVisitDiagnosis!.ToLower());
           fallsSentenceBuilder.Append(" e ");
           fallsSentenceBuilder.Append(_currentVisitRc!.FallsSinceLastVisitType!.ToLower());
           fallsSentenceBuilder.Append(".\n");
       }
       else
       {
           fallsSentenceBuilder.Append("Non riferisce cadute da ultima visita.\n");
       }
       _fallsSinceLastVisitSentence = fallsSentenceBuilder.ToString();
    }
    
    private void UpdateEmergenciesSinceLastVisitSentence()
    {
        var emergenciesSentenceBuilder = new StringBuilder();
        if (_currentVisitRc!.EmergenciesSinceLastVisit &&
            _currentVisitRc!.EmergenciesSinceLastVisitNumber is not null &&
            _currentVisitRc!.EmergenciesSinceLastVisitCause is not null)
        {
            emergenciesSentenceBuilder.Append("Riferisce ");
            emergenciesSentenceBuilder.Append(_currentVisitRc!.EmergenciesSinceLastVisitNumber);
            emergenciesSentenceBuilder.Append(' ');
            emergenciesSentenceBuilder.Append(_currentVisitRc!.EmergenciesSinceLastVisitNumber == 1 ? "accesso" : "accessi");
            emergenciesSentenceBuilder.Append(" in pronto soccorso da ultima visita, per causa ");
            emergenciesSentenceBuilder.Append(_currentVisitRc!.EmergenciesSinceLastVisitCause!.ToLower());
            emergenciesSentenceBuilder.Append(".\n");
        }
        else
        {
            emergenciesSentenceBuilder.Append("Non riferisce accessi in pronto soccorso da ultima visita.\n");
        }
        _emergenciesSinceLastVisitSentence = emergenciesSentenceBuilder.ToString();
    }
    
    private void UpdateHospitalizationsSinceLastVisitSentence()
    {
        var hospitalizationsSentenceBuilder = new StringBuilder();
        if (_currentVisitRc!.HospitalizationsSinceLastVisit &&
            _currentVisitRc!.HospitalizationsSinceLastVisitNumber is not null &&
            _currentVisitRc!.HospitalizationsSinceLastVisitDays is not null &&
            _currentVisitRc!.HospitalizationsSinceLastVisitCause is not null)
        {
            hospitalizationsSentenceBuilder.Append("Riferisce ");
            hospitalizationsSentenceBuilder.Append(_currentVisitRc!.HospitalizationsSinceLastVisitNumber);
            hospitalizationsSentenceBuilder.Append(' ');
            hospitalizationsSentenceBuilder.Append(_currentVisitRc!.HospitalizationsSinceLastVisitNumber == 1 ? "ricovero" : "ricoveri");
            hospitalizationsSentenceBuilder.Append(" da ultima visita, per un totale di ");
            hospitalizationsSentenceBuilder.Append(_currentVisitRc!.HospitalizationsSinceLastVisitDays);
            hospitalizationsSentenceBuilder.Append(' ');
            hospitalizationsSentenceBuilder.Append(_currentVisitRc!.HospitalizationsSinceLastVisitDays == 1 ? "giorno" : "giorni");
            hospitalizationsSentenceBuilder.Append(", per causa ");
            hospitalizationsSentenceBuilder.Append(_currentVisitRc!.HospitalizationsSinceLastVisitCause!.ToLower());
            hospitalizationsSentenceBuilder.Append(".\n");
        }
        else
        {
            hospitalizationsSentenceBuilder.Append("Non riferisce ricoveri da ultima visita.\n");
        }
        _hospitalizationsSinceLastVisitSentence = hospitalizationsSentenceBuilder.ToString();
    }
    
    public void LoadRaccordoClinicoContent(VisitRc currentVisitRc)
    {
        _currentVisitRc = currentVisitRc;
        UpdateReportsSentence();
        UpdateLastPeriodSentence();
        UpdateSleepingSentence();
        UpdateFallsSinceLastVisitSentence();
        UpdateEmergenciesSinceLastVisitSentence();
        UpdateHospitalizationsSinceLastVisitSentence();
        UpdateColumnBDescription();
    }

    private void UpdateColumnBDescription()
    {
        var columnBDescriptionStringBuilder = new StringBuilder();
        columnBDescriptionStringBuilder.Append(_reportsSentence);
        columnBDescriptionStringBuilder.Append(_lastPeriodSentence);
        columnBDescriptionStringBuilder.Append(_sleepingSentence);
        columnBDescriptionStringBuilder.Append(_fallsSinceLastVisitSentence);
        columnBDescriptionStringBuilder.Append(_emergenciesSinceLastVisitSentence);
        columnBDescriptionStringBuilder.Append(_hospitalizationsSinceLastVisitSentence);

        Dispatcher.UIThread.Post(() => { _columnBDescription!.Text = columnBDescriptionStringBuilder.ToString(); });
    }
}