using System.Collections.Generic;

namespace SchedaVisite.Models.enums.anamnesipatologicaremota;

public static class AnamnesiPatologicaRemotaSynonyms
{
    public static List<string> getIschemicHeartDiseaseSynonyms() { return ["cardiopatia ischemica", "stemi", "infarto", "ima"]; }
    public static List<string> getHeartFailureSynonyms() { return ["insufficienza cardiaca", "scompenso cardiaco", "scc"]; }
    public static List<string> getAtrialFibrillationSynonyms() { return ["fibrillazione atriale", "fa", "fap"]; }
    public static List<string> getCerebrovascularDiseaseSynonyms() { return ["malattia cerebrovascolare", "tia", "stroke", "ictus"]; }
    public static List<string> getNeoplasmSynonyms() { return ["neoplasia ", "tumore", "k", "carcinoma"]; }
    public static List<string> getChronicObstructivePulmonaryDiseaseSynonyms() { return ["bpco", "enfisema", "bronchite cronica"]; }
    public static List<string> getChronicKidneyDiseaseSynonyms() { return ["malattia renale cronica", "insufficienza renale cronica", "irc", "mrc"]; }
    public static List<string> getPeripheralVascularDiseaseSynonyms() { return ["malattia vascolare periferica"]; }
    public static List<string> getDiabetesSynonyms() { return ["diabete"]; }
    public static List<string> getChronicSkinUlcersSynonyms() { return ["ulcere croniche cutanee"]; }
    public static List<string> getParkinsonSynonyms() { return ["parkinson", "parkinsonismo"]; }
    public static List<string> getSchizophreniaSynonyms() { return ["schizofrenia"]; }
    public static List<string> getNeuromuscularDisordersSynonyms() { return ["paraplegia ", "atassia", "distonia", "miopatia"]; }
    public static List<string> getHipFractureSynonyms() { return ["frattura dell’anca", "frattura del femore", "pta"]; }
    public static List<string> getAnemiaSynonyms() { return ["anemia"]; }
    public static List<string> getBradycardiaSynonyms() { return ["bradicardia", "bav"]; }
    public static List<string> getArterialHypertensionSynonyms() { return ["ipertensione arteriosa"]; }
    public static List<string> getSevereValvularDiseaseSmSynonyms() { return ["sm", "stenosi mitralica"]; }
    public static List<string> getSevereValvularDiseaseImSynonyms() { return ["im", "insufficienza mitralica"]; }
    public static List<string> getSevereValvularDiseaseIaoSynonyms() { return ["iao", "insufficienza aortica"]; }
    public static List<string> getSevereValvularDiseaseSaoSynonyms() { return ["sao", "stenosi aortica"]; }
    public static List<string> getSevereValvularDiseaseItrSynonyms() { return ["itr", "insufficienza tricuspidalica"]; }
    public static List<string> getDementiaSynonyms() { return ["deficit cognitivo", "demenza", "decadimento cognitivo", "disturbo cognitivo"]; }
    
}