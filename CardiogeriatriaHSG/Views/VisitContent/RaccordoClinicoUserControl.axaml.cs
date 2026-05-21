using System.Text;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using CardiogeriatriaHSG.Models;
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
            if (DataContext is not AnamnesiGeriatricaUserControlViewModel viewModel) return;
            _currentVisit = viewModel.CurrentVisit!;
            LoadRaccordoClinicoContent(_currentVisit);
        };
    }
    
    private Visit? _currentVisit;
    private readonly TextBlock? _columnBDescription;

    private string? _reportsSentence;

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
        
        switch (tag) 
        {
            case "AssistanceAlone":
                _currentVisit!.VisitAg!.AssistanceAlone = value == "True";
                UpdateReportsSentence();
                break;
            case "WalkingType":
                _currentVisit!.VisitAg!.WalkingType = value!;
                UpdateReportsSentence();
                break;
        }
        
        UpdateColumnBDescription();
    }
    
    private void UpdateReportsSentence()
    {
        var reportsSentenceBuilder = new StringBuilder();
        reportsSentenceBuilder.Append("Vive a domicilio");
        if (_currentVisit!.VisitAg!.AssistanceAlone) reportsSentenceBuilder.Append(", da solo");
        if (_currentVisit!.VisitAg!.AssistanceSpouse) reportsSentenceBuilder.Append(", con coniuge");
        if (_currentVisit!.VisitAg!.AssistanceFamilyMembers) reportsSentenceBuilder.Append(", con familiari");
        if (_currentVisit!.VisitAg!.CareTaker) reportsSentenceBuilder.Append(" e con badante");
        reportsSentenceBuilder.Append('.');
        reportsSentenceBuilder.Append('\n');
        _reportsSentence = reportsSentenceBuilder.ToString();
    }
    
    public void LoadRaccordoClinicoContent(Visit currentVisit)
    {
        _currentVisit = currentVisit;
        UpdateReportsSentence();
        
        UpdateColumnBDescription();
    }

    private void UpdateColumnBDescription()
    {
        var columnBDescriptionStringBuilder = new StringBuilder();
        columnBDescriptionStringBuilder.Append(_reportsSentence);

        Dispatcher.UIThread.Post(() => { _columnBDescription!.Text = columnBDescriptionStringBuilder.ToString(); });
    }
}