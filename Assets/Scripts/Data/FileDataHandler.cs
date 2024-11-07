using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class FileDataHandler
{

    public static void Save(GameData data)
    {
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + "/data.fun";
        Debug.Log("Path " + path);
        FileStream stream = new FileStream(path, FileMode.Create);
        bf.Serialize(stream, data);
        stream.Close();
    }
    public static GameData Load()
    {
        string path = Application.persistentDataPath + "/data.fun";
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            GameData gameData =  (GameData)bf.Deserialize(stream);
            stream.Close();
            return gameData;

        }
        else
        {
            Debug.LogError("Not load game");
            return null; 
        }
    }

}
