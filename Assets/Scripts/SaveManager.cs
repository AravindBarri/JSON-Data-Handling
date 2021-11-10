using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public static class SaveManager 
{
    public static string directory = "/SaveData/";
    public static string fileName = "MyData.txt";
    public static string textFileName = "MyDataText.txt";
    public static string[] fileData;

    public static void Save(SaveObject so)
    {
        string dir = Application.persistentDataPath + directory;
        Debug.Log(Application.dataPath);
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        string json = JsonUtility.ToJson(so);
        File.WriteAllText(dir + fileName, json);
    }
    public static SaveObject Load()
    {
        string fullPath = Application.persistentDataPath + directory + fileName;
        SaveObject so = new SaveObject();
        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            Debug.Log(JsonUtility.FromJson<SaveObject>(json));
            so = JsonUtility.FromJson<SaveObject>(json);
            
        
        }
        else
        {
            Debug.Log("file does not exist");
        }
        return (so);
    }

    public static void PrintJsonData(SaveObject so)
    {
        Debug.Log(so.playerName);
        Debug.Log(so.playerLevel);
        Debug.Log(so.playerScore);
        Debug.Log(so.playerLocation);
    }

    public static SaveObject SaveJsonDataToText(SaveObject TextData, SaveObject so)
    {
        string dir = Application.persistentDataPath + directory;
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        so = TextData;
        fileData = new string[4];
        fileData[0] = "Player Name : " + so.playerName;
        fileData[1] = "Player Level : " + so.playerLevel.ToString();
        fileData[2] = "Player Score : " + so.playerScore.ToString();
        fileData[3] = "Player Location : " + so.playerLocation;
        File.WriteAllLines(dir + textFileName, fileData);
        return (so);
    }
}
