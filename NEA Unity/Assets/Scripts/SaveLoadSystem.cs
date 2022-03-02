using UnityEngine;
using System.IO;
public static class SaveLoadSystem {

    private static string path = Application.dataPath + "/SaveFile.json";

    public static void Save() {
        SaveData data = PersistentData.GetAllData();
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);
    }

    public static void Load() {
        try {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            PersistentData.LoadAllData(data);
            
        }
        catch {
            Save();
        }

    }
}
