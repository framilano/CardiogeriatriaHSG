using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CardiogeriatriaHSG.Models;

public partial class VisitTd(string visitCode): ObservableObject
{
    [MaxLength(36)]
    public string? VisitCode { get; set; } = visitCode;
    public Visit? Visit { get; set; }
    [ObservableProperty] private string? _tdText = "";
    partial void OnTdTextChanged(string? value) { if (value != null) TdText = value.Trim(); }
    
    //TD
    [ObservableProperty] private bool _proteinSupplementation;
    [ObservableProperty] private bool _physicalExercise;
    [ObservableProperty] private bool _furosemide;
    [ObservableProperty] private int? _furosemideDose;
    [ObservableProperty] private bool _betaBlocker;
    [ObservableProperty] private bool _mra;
    [ObservableProperty] private bool _aceInhibitor;
    [ObservableProperty] private bool _arb;
    [ObservableProperty] private bool _sglt2Inhibitor;
    [ObservableProperty] private bool _arni;
    [ObservableProperty] private bool _vericiguat;
    [ObservableProperty] private bool _otherLoopDiuretic;
    [ObservableProperty] private bool _doac;
    [ObservableProperty] private bool _vka;
    [ObservableProperty] private bool _acetazolamide;
    [ObservableProperty] private bool _hydrochlorothiazide;
    [ObservableProperty] private bool _acoramidis;
    [ObservableProperty] private bool _tafamidis;
    [ObservableProperty] private bool _vutrisiran;
    [ObservableProperty] private bool _calciumChannelBlockers;
    [ObservableProperty] private bool _ranolazine;
    [ObservableProperty] private bool _nitrates;
    [ObservableProperty] private bool _glp1;
    [ObservableProperty] private bool _doxazosin;
    [ObservableProperty] private bool _clonidine;
    [ObservableProperty] private bool _fibrates;
    [ObservableProperty] private bool _statins;
    [ObservableProperty] private bool _ezetimibe;
    [ObservableProperty] private bool _ppi;
    [ObservableProperty] private bool _acheInhibitorOrMemantine;
    [ObservableProperty] private bool _benzodiazepines;
    [ObservableProperty] private bool _zDrugs;
    [ObservableProperty] private bool _lowDoseTrazodone;
    [ObservableProperty] private bool _antidepressants;
    [ObservableProperty] private bool _antipsychotics;
    [ObservableProperty] private bool _paracetamol;
    [ObservableProperty] private bool _opioids;
    [ObservableProperty] private bool _otherAnalgesics;
}