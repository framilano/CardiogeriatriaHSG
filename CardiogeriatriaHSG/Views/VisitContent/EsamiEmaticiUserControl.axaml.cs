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

    private string? _hemoglobineSentence;
    private string? _examDateSentence;

    public void OnColumnAChanged(object? sender, RoutedEventArgs routedEventArgs)
    {
        var tag = "";
        var value = "";
        switch (sender)
        {
            case NumericUpDown box:
                tag = (string)box.Tag!;
                value = box.Value?.ToString();
                value ??= box.Minimum.ToString(CultureInfo.InvariantCulture);
                break;
        }
        
        switch (tag) 
        {
            case "Hemoglobin":
                _currentVisitEe!.Hemoglobin = float.Parse(value!);
                UpdateHemoglobinSentence();
                break;
        }
        
        UpdateColumnBDescription();
    }
    
    private void OnColumnADatePickerChanged(object? sender, DatePickerSelectedValueChangedEventArgs e)
    {
        var datePicker = (DatePicker)sender!;
        _currentVisitEe!.ExamDate = (DateTimeOffset)datePicker.SelectedDate!;
        UpdateExamDateSentence();
        UpdateColumnBDescription();
    }
    
    private void UpdateExamDateSentence()
    {
        var examDateSentenceBuilder = new StringBuilder();
        examDateSentenceBuilder.Append("Esame del sangue effettuato il " + _currentVisitEe!.ExamDate.ToString("dd/MM/yyyy"));
        examDateSentenceBuilder.Append('.');
        examDateSentenceBuilder.Append('\n');
        _examDateSentence = examDateSentenceBuilder.ToString();
    }
    
    private void UpdateHemoglobinSentence()
    {
        var hemoglobinSentenceBuilder = new StringBuilder();
        hemoglobinSentenceBuilder.Append('.');
        hemoglobinSentenceBuilder.Append('\n');
        _hemoglobineSentence = hemoglobinSentenceBuilder.ToString();
    }
    
    public void LoadEsamiEmaticiContent(VisitEe currentVisitEe)
    {
        _currentVisitEe = currentVisitEe;
        UpdateExamDateSentence();
        UpdateHemoglobinSentence();
        
        UpdateColumnBDescription();
    }

    private void UpdateColumnBDescription()
    {
        var columnBDescriptionStringBuilder = new StringBuilder();
        columnBDescriptionStringBuilder.Append(_examDateSentence);
        columnBDescriptionStringBuilder.Append(_hemoglobineSentence);

        Dispatcher.UIThread.Post(() => { _columnBDescription!.Text = columnBDescriptionStringBuilder.ToString(); });
    }
}