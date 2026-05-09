using System.Collections.Generic;

namespace SchedaVisite.Models.enums.anamnesipatologicaremota;

public static class AnamnesiPatologicaRemotaSynonyms
{
    public static readonly List<string> IschemicHeartDiseaseSynonyms = ["cardiopatia ischemica", "stemi", "infarto", "ima", "nstemi"];
    public static readonly List<string> HeartFailureSynonyms = ["insufficienza cardiaca", "scompenso cardiaco", "scc"];
    public static readonly List<string> AtrialFibrillationSynonyms = ["fibrillazione atriale", "FA", "fap"];
    public static readonly List<string> CerebrovascularDiseaseSynonyms = ["malattia cerebrovascolare", "vasculopatia cerebrale", "tia", "stroke", "ictus"];
    public static readonly List<string> NeoplasmSynonyms = ["neoplasia", "adenok", "tumore", "k", "carcinoma"];
    public static readonly List<string> ChronicObstructivePulmonaryDiseaseSynonyms = ["bpco", "copd", "enfisema", "bronchite cronica"];
    public static readonly List<string> ChronicKidneyDiseaseSynonyms = ["malattia renale cronica", "insufficienza renale cronica", "irc", "mrc"];
    public static readonly List<string> PeripheralVascularDiseaseSynonyms = ["malattia vascolare periferica", "AOCP", "pad", "ischemia acuta arto inferiore"];
    public static readonly List<string> DiabetesSynonyms = ["diabete", "dm"];
    public static readonly List<string> ChronicSkinUlcersSynonyms = [@"\bulcer\w*\b"];
    public static readonly List<string> ParkinsonSynonyms = [@"\bparkinson\w*\b"];
    public static readonly List<string> SchizophreniaSynonyms = ["schizofrenia"];
    public static readonly List<string> NeuromuscularDisordersSynonyms = ["paraplegia ", "atassia", "distonia", "miopatia"];
    public static readonly List<string> HipFractureSynonyms = [@"frattur\w*\b(?:\W+\w+){0,5}\W+\banca", @"frattur\w*\b(?:\W+\w+){0,5}\W+\bfemore", "pta"];
    public static readonly List<string> AnemiaSynonyms = ["anemia"];
    public static readonly List<string> BradycardiaSynonyms = ["bradicardia", "bav"];
    public static readonly List<string> ArterialHypertensionSynonyms = ["ipertensione arteriosa", "ia", "ipertensiva"];
    public static readonly List<string> SevereValvularDiseaseSmSynonyms = ["sm", "stenosi mitralica"];
    public static readonly List<string> SevereValvularDiseaseImSynonyms = ["im", "insufficienza mitralica"];
    public static readonly List<string> SevereValvularDiseaseIaoSynonyms = ["iao", "insufficienza aortica"];
    public static readonly List<string> SevereValvularDiseaseSaoSynonyms = ["sao", "stenosi aortica"];
    public static readonly List<string> SevereValvularDiseaseItrSynonyms = ["itr", "insufficienza tricuspidalica"];
    public static readonly List<string> AmyloidosisSynonyms = ["amiloidosi"];

    public static readonly List<string> DementiaSynonyms = ["deficit cognitivo", "demenza", "decadimento cognitivo", "disturbo cognitivo"," disturbo neurocognitivo", "mci", "lbd", "alzheimer"];
    
    public static readonly List<string> CaseSensitiveFields = ["FA"];
}