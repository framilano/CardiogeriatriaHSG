using System;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CardiogeriatriaHSG.Models;

public partial class VisitAg(string visitCode): ObservableObject
{
    
    [MaxLength(36)]
    public string? VisitCode { get; set; } = visitCode;
    public Visit? Visit { get; set; }
    
    //Anamnesi Geriatrica
    [ObservableProperty] private bool _assistanceAlone;
    [ObservableProperty] private bool _assistanceSpouse;
    [ObservableProperty] private bool _assistanceFamilyMembers;
    [ObservableProperty] private bool _careTaker;
    [ObservableProperty] private string? _motorSkill;
    [ObservableProperty] private string? _walkingType;
    [ObservableProperty] private string? _falls;
    [ObservableProperty] private string? _cognitiveDeficit;
    [ObservableProperty] private bool _bpsd;
    [ObservableProperty] private bool _hearingImpairment;
    [ObservableProperty] private bool _visualImpairment;
    [ObservableProperty] private string? _nights;
    [ObservableProperty] private string? _weightLoss;
    [ObservableProperty] private string? _appetite;
    [ObservableProperty] private string? _dysphagia;
    [ObservableProperty] private bool _nutrionalProblems;
    [ObservableProperty] private bool _constipation;
    [ObservableProperty] private bool _disability;
}