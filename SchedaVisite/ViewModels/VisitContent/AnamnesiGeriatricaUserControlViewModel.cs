using System;
using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using SchedaVisite.Models;
using SchedaVisite.Models.enums.anamnesigeriatrica;

namespace SchedaVisite.ViewModels.VisitContent;

public partial class AnamnesiGeriatricaUserControlViewModel : ObservableObject
{
    //CONSTRUCTORS
    public AnamnesiGeriatricaUserControlViewModel(Visit currentVisit, Patient currentPatient)
    {
        CurrentVisit = currentVisit;
        CurrentPatient = currentPatient;
    }
    
    public Visit CurrentVisit { get; set; }
    public Patient CurrentPatient { get; set; }
    
    public IEnumerable<string> AppetitesValues => Appetite.getAllAppetites();
    public IEnumerable<string> CognitiveDeficitsValues => CognitiveDeficit.getAllCognitiveDeficits();
    public IEnumerable<string> DysphagiasValues => Dysphagia.getAllDysphagias();
    public IEnumerable<string> FallsValuesValues => Falls.getAllFalls();
    public IEnumerable<string> MotorSkillsValues => MotorSkill.getAllMotorSkills();
    public IEnumerable<string> NightsValues => Nights.getAllNights();
    public IEnumerable<string> WalkingTypesValues => WalkingType.getAllWalkingTypes();
    public IEnumerable<string> WeightLossesValues => WeightLoss.getAllWeightLosses();
}