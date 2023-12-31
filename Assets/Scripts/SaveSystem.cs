using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveGame(StatSystem statSystem)
    {
        statSystem.SetDT(DateTime.Now);

        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/data.save";

        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, statSystem);

        stream.Close();
    }

    public static StatSystem LoadGame()
    {
        string path = Application.persistentDataPath + "/data.save";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream(path, FileMode.Open);

            StatSystem statSystem = formatter.Deserialize(stream) as StatSystem;

            stream.Close();

            return statSystem;
        }
        else
        {
            return new StatSystem();
        }
    }
}
