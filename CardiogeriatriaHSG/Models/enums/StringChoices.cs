using System.Collections.Generic;

namespace CardiogeriatriaHSG.Models.enums;

public class StringChoices
{
    //Header
    public static readonly List<string> VisitSubTypes = ["Hf", "Amiloidosi", "Cga Per Procedura", "Cardiopalliative"];
    public static readonly List<string> VisitTypes = ["Cardiogeriatrica", "Cardiologica"];
    //Anagrafica
    public static readonly List<string> GenderTypes = ["M", "F"];
    //Anamnesi Geriatrica
    public static readonly List<string> Appetites = [ "Conservato", "Lievemente ridotto", "Ridotto"];
    public static readonly List<string> CognitiveDeficits = ["Nessuno", "Iniziali", "Noti"];
    public static readonly List<string> DysphagiaTypes = ["No", "Iniziale ai liquidi", "Iniziale ai solidi", "Ai liquidi", "Ai solidi", "A liquidi e solidi"];
    public static readonly List<string> FallTypes = ["0", "1", "2", "più di 3"];
    public static readonly List<string> MotorSkillTypes = ["Solo letto-poltrona", "Esce solo", "Autonomo a domicilio"];
    public static readonly List<string> NightTypes = ["Riposate", "Con ipnoinducenti", "Poco riposate"];
    public static readonly List<string> WalkingTypes = ["Autonoma senza ausili", "Con Bastone", "Con Walker"];
    public static readonly List<string> WeightLossTypes = ["No", "1-3 Kg", "Non noto", "più di 3 Kg"]; 
    //Anamnesi Patologica Remota
    public static readonly List<string> AmyloidosisTypes = ["ATTR-WT", "ATTR-v"];
    public static readonly List<string> DementiaTypes = ["Neurodegenerativa", "Vascolare", "Mista", "Altro", "Non noto"];
    //Raccordo Clinico
    public static readonly List<string> ReportsTypes = ["Benessere", "Stabilità dei sintomi", "Peggioramento della dispnea", "Peggioramento dell’astenia"];  
    public static readonly List<string> DyspneaTypes = ["Non dispnea", "Per sforzi lievi", "Per sforzi moderati", "Per sforzi intensi"];   
    public static readonly List<string> AnginaTypes = ["Non angor", "Episodi di angina"];   
    public static readonly List<string> FallsSinceLastVisitTypes = ["Testimoniata", "Non testimoniata"];
    public static readonly List<string> FallsSinceLastVisitDiagnosis = ["Caduta accidentale", "Sincope"];  
    public static readonly List<string> EmergenciesSinceLastVisitCauses = ["Non cardiovascolare", "Scompenso", "Altra causa cardiovascolare"];
    public static readonly List<string> HospitalizationsSinceLastVisitCauses = ["Non cardiovascolare", "Scompenso", "Altra causa cardiovascolare"];
    //Esami Obiettivo
    public static readonly List<string> HeartSoundTypes = ["validi", "parafonici"];  
    public static readonly List<string> HeartSoundRhythmTypes = ["ritmici", "aritmici"];  
    public static readonly List<string> HeartSoundPausesTypes = ["pause libere", "SS 2/6", "SS 4/6", "SS 5/6"];
    public static readonly List<string> ChestMvTypes = ["presente", "ridotto", "abolito alle basi"];  
    public static readonly List<string> ChestNoisesTypes = ["senza rumori aggiunti", "crepitii alle basi", "crepitii ai campi mediobasali", "ronchi", "rumori da secrezione", "broncospasmo"];  
}