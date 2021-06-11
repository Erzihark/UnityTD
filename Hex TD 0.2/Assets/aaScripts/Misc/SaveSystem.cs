using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
   public static void SaveLevelProgress (LevelEndMenu levelEndMenu)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, "player.save");
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData(levelEndMenu);

        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("File Saved");
    }

    public static SaveData LoadData()
    {
        string path = Path.Combine(Application.persistentDataPath, "player.save");
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();
            Debug.Log("File Loaded");

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
