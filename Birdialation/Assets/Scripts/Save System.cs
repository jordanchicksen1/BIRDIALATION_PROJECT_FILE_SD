using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

public static class SaveSystem 
{
   public static void Save(GameData data)
    {
        string path = Application.persistentDataPath + "/data.qnd";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fs = new FileStream(path, FileMode.Create);
        formatter.Serialize(fs, data);
        fs.Close();
    }

    public static GameData Load()
    {
        if (!File.Exists(GetPath()))
        {
            GameData emtyData = new GameData();
            Save(emtyData);
            return emtyData;
        }
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fs = new FileStream(GetPath(), FileMode.Open);
       GameData data =  formatter.Deserialize(fs) as GameData;

        return data;
    }

    private static string GetPath()
    {
        return Application.persistentDataPath + "/data.qnd";
    }
}
