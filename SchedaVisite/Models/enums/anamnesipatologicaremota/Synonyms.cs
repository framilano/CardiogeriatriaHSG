using System.Collections.Generic;

namespace SchedaVisite.Models.enums.anamnesipatologicaremota;

public static class AnamnesiPatologicaRemotaSynonyms
{
    public static readonly List<string> IschemicHeartDiseaseSynonyms = ["cardiopatia ischemica", "stemi", "infarto", "ima", "nstemi"];
    public static readonly List<string> HeartFailureSynonyms = ["insufficienza cardiaca", "scompenso cardiaco", "scc"];
    public static readonly List<string> AtrialFibrillationSynonyms = ["fibrillazione atriale", "FA", "fap"];
    public static readonly List<string> CerebrovascularDiseaseSynonyms = ["malattia cerebrovascolare", "tia", "stroke", "ictus"];
    public static readonly List<string> NeoplasmSynonyms = ["neoplasia ", "tumore", "k", "carcinoma"];
    public static readonly List<string> ChronicObstructivePulmonaryDiseaseSynonyms = ["bpco", "enfisema", "bronchite cronica"];
    public static readonly List<string> ChronicKidneyDiseaseSynonyms = ["malattia renale cronica", "insufficienza renale cronica", "irc", "mrc"];
    public static readonly List<string> PeripheralVascularDiseaseSynonyms = ["malattia vascolare periferica"];
    public static readonly List<string> DiabetesSynonyms = ["diabete"];
    public static readonly List<string> ChronicSkinUlcersSynonyms = ["ulcere croniche cutanee"];
    public static readonly List<string> ParkinsonSynonyms = ["parkinson", "parkinsonismo"];
    public static readonly List<string> SchizophreniaSynonyms = ["schizofrenia"];
    public static readonly List<string> NeuromuscularDisordersSynonyms = ["paraplegia ", "atassia", "distonia", "miopatia"];
    public static readonly List<string> HipFractureSynonyms = ["frattura dell’anca", "frattura del femore", "pta"];
    public static readonly List<string> AnemiaSynonyms = ["anemia"];
    public static readonly List<string> BradycardiaSynonyms = ["bradicardia", "bav"];
    public static readonly List<string> ArterialHypertensionSynonyms = ["ipertensione arteriosa"];
    public static readonly List<string> SevereValvularDiseaseSmSynonyms = ["sm", "stenosi mitralica"];
    public static readonly List<string> SevereValvularDiseaseImSynonyms = ["im", "insufficienza mitralica"];
    public static readonly List<string> SevereValvularDiseaseIaoSynonyms = ["iao", "insufficienza aortica"];
    public static readonly List<string> SevereValvularDiseaseSaoSynonyms = ["sao", "stenosi aortica"];
    public static readonly List<string> SevereValvularDiseaseItrSynonyms = ["itr", "insufficienza tricuspidalica"];
    public static readonly List<string> DementiaSynonyms = ["deficit cognitivo", "demenza", "decadimento cognitivo", "disturbo cognitivo"];


    public static readonly List<string> CaseSensitiveFields = ["FA"];
}