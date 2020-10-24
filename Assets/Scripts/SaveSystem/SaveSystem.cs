using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{

    //Highscore SaveStates
    public static void SaveHighscore (scr_Highscore Highscore)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Highscore.dab";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(Highscore);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadHighscore()
    {
        string path = Application.persistentDataPath + "/Highscore.dab";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);

            BinaryFormatter formatter = new BinaryFormatter();
            path = Application.persistentDataPath + "/Highscore.dab";
            FileStream stream = new FileStream(path, FileMode.Create);

            stream.Close();

            LoadHighscore();

            return null;
        }
    }


    //Volume SaveStates
    public static void SaveVolume(scr_VolumeOptions Volume)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Volume.dab";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(Volume);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadVolume()
    {
        string path = Application.persistentDataPath + "/Volume.dab";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);

            BinaryFormatter formatter = new BinaryFormatter();
            path = Application.persistentDataPath + "/Volume.dab";
            FileStream stream = new FileStream(path, FileMode.Create);

            stream.Close();

            LoadVolume();

            return null;
        }
    }
}
