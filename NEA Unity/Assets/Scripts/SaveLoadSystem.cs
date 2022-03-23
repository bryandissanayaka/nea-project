using UnityEngine;
using System.IO; 
public static class SaveLoadSystem
{
    private static string path = Application.dataPath + "/SaveFile.json"; //the path where the file will be saved and the name of the file

    public static void Save() {
        SaveData data = PersistentData.GetAllData(); //get the data from the current session
        string json = JsonUtility.ToJson(data); //parse the data into JSON format
        File.WriteAllText(path, json); //write the data into the file
    }

    public static void Load() {
        try { //attempt to load data
            string json = File.ReadAllText(path); //read the content of the save file (in JSON format)
            SaveData data = JsonUtility.FromJson<SaveData>(json); //parse the JSON file into a SaveData class
            PersistentData.LoadAllData(data); //load the data into the current session

        } //if loading fails (missing file)
        catch {
            Save(); //this will create a new save file
        }
    }
}
