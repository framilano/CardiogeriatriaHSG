using System;
using System.Globalization;
using System.Text;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using CardiogeriatriaHSG.Models;
using CardiogeriatriaHSG.Models.enums;
using CardiogeriatriaHSG.ViewModels.VisitContent;

namespace CardiogeriatriaHSG.Views.VisitContent;

public partial class EsamiEmaticiUserControl : UserControl
{
    public EsamiEmaticiUserControl()
    {
        InitializeComponent();
        _columnBDescription = this.Find<TextBlock>("ColumnBDescription");
        DataContextChanged += (_, __) =>
        {
            if (DataContext is not EsamiEmaticiUserControlViewModel viewModel) return;
            _currentVisitEe = viewModel.CurrentVisitEe;
            LoadEsamiEmaticiContent(_currentVisitEe);
        };
    }
    
    private VisitEe? _currentVisitEe;
    private readonly TextBlock? _columnBDescription;

    private string? _examDateSentence;
    private string? _hemoglobinSentence;
    private string? _creatinineSentence;
    private string? _ureaSentence;
    private string? _sodiumSentence;
    private string? _potassiumSentence;
    private string? _ntProBnpSentence;
    private string? _bnpSentence;
    private string? _albuminSentence;
    private string? _albuminuriaSentence;

    public void OnColumnAChanged(object? sender, RoutedEventArgs routedEventArgs)
    {
        var tag = "";
        var value = "";
        switch (sender)
        {
            case NumericUpDown box:
                tag = (string)box.Tag!;
                if (box.Value is null) value = null;
                else
                {
                    value = box.Value.ToString();
                    if (value.IsWhiteSpace() || value!.Length == 0) value = null;
                }
                break;
        }
        
        switch (tag) 
        {
            case "Hemoglobin":
                if (value is null) {  _currentVisitEe!.Hemoglobin = null; break; }
                _currentVisitEe!.Hemoglobin = float.Parse(value!);
                break;
            case "Creatinine":
                if (value is null) { _currentVisitEe!.Creatinine = null; break; }
                _currentVisitEe!.Creatinine = float.Parse(value!);
                break;
            case "Urea":
                if (value is null) { _currentVisitEe!.Urea = null; break; }
                _currentVisitEe!.Urea = float.Parse(value!);
                break;
            case "Sodium":
                if (value is null) { _currentVisitEe!.Sodium = null; break; }
                _currentVisitEe!.Sodium = float.Parse(value!);
                break;
            case "Potassium":
                if (value is null) { _currentVisitEe!.Potassium = null; break; }
                _currentVisitEe!.Potassium = float.Parse(value!);
                break;
            case "NtProBnp":
                if (value is null) { _currentVisitEe!.NtProBnp = null; break; }
                _currentVisitEe!.NtProBnp = float.Parse(value!);
                break;
            case "Bnp":
                if (value is null) { _currentVisitEe!.Bnp = null; break; }
                _currentVisitEe!.Bnp = float.Parse(value!);
                break;
            case "Albumin":
                if (value is null) { _currentVisitEe!.Albumin = null; break; }
                _currentVisitEe!.Albumin = float.Parse(value!);
                break;
            case "Albuminuria":
                if (value is null) { _currentVisitEe!.Albuminuria = null; break; }
                _currentVisitEe!.Albuminuria = float.Parse(value!);
                break;
        }
        UpdateAllSentences(tag);
        UpdateColumnBDescription();
    }
    
    private void OnColumnADatePickerChanged(object? sender, DatePickerSelectedValueChangedEventArgs e)
    {
        var datePicker = (DatePicker)sender!;
        _currentVisitEe!.ExamDate = (DateTimeOffset)datePicker.SelectedDate!;
        UpdateAllSentences("ExamDate");
        UpdateColumnBDescription();
    }
    
    //Doesn't make sense to have multiple update methods for these easy-to-build sentences
    private void UpdateAllSentences(string updatedField)
    {
        if (updatedField is "ExamDate" or "All") _examDateSentence = $"Data ultima esami del sangue {_currentVisitEe!.ExamDate:dd/MM/yyyy}\n";
        if (updatedField is "Hemoglobin" or "All") _hemoglobinSentence = _currentVisitEe!.Hemoglobin is null ? null : $"Emoglobina {_currentVisitEe!.Hemoglobin} g/dl\n";
        if (updatedField is "Creatinine" or "All") _creatinineSentence = _currentVisitEe!.Creatinine is null ? null : $"Creatinina {_currentVisitEe!.Creatinine} mg/dl\n";
        if (updatedField is "Urea" or "All") _ureaSentence = _currentVisitEe!.Urea is null ? null : $"Urea {_currentVisitEe!.Urea} mg/dl\n";
        if (updatedField is "Sodium" or "All") _sodiumSentence = _currentVisitEe!.Sodium is null ? null : $"Na {_currentVisitEe!.Sodium} mmol/L\n";
        if (updatedField is "Potassium" or "All") _potassiumSentence = _currentVisitEe!.Potassium is null ? null : $"K {_currentVisitEe!.Potassium} mmol/L\n";
        if (updatedField is "NtProBnp" or "All") _ntProBnpSentence = _currentVisitEe!.NtProBnp is null ? null : $"NTproBNP {_currentVisitEe!.NtProBnp} ng/L\n";
        if (updatedField is "Bnp" or "All") _bnpSentence = _currentVisitEe!.Bnp is null ? null : $"BNP {_currentVisitEe!.Bnp} ng/L\n";
        if (updatedField is "Albumin" or "All") _albuminSentence = _currentVisitEe!.Albumin is null ? null : $"Albumina {_currentVisitEe!.Albumin} -g/L\n";
        if (updatedField is "Albuminuria" or "All") _albuminuriaSentence = _currentVisitEe!.Albuminuria is null ? null : $"Albuminuria {_currentVisitEe!.Albuminuria} g\n";
    }
    
    public void LoadEsamiEmaticiContent(VisitEe currentVisitEe)
    {
        _currentVisitEe = currentVisitEe;
        UpdateAllSentences("All");
        UpdateColumnBDescription();
    }

    private void UpdateColumnBDescription()
    {
        var columnBDescriptionStringBuilder = new StringBuilder();
        columnBDescriptionStringBuilder.Append(_examDateSentence);
        columnBDescriptionStringBuilder.Append(_hemoglobinSentence);
        columnBDescriptionStringBuilder.Append(_creatinineSentence);
        columnBDescriptionStringBuilder.Append(_ureaSentence);
        columnBDescriptionStringBuilder.Append(_sodiumSentence);
        columnBDescriptionStringBuilder.Append(_potassiumSentence);
        columnBDescriptionStringBuilder.Append(_ntProBnpSentence);
        columnBDescriptionStringBuilder.Append(_bnpSentence);
        columnBDescriptionStringBuilder.Append(_albuminSentence);
        columnBDescriptionStringBuilder.Append(_albuminuriaSentence);

        Dispatcher.UIThread.Post(() => { _columnBDescription!.Text = columnBDescriptionStringBuilder.ToString(); });
    }
}