using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public List<SaveValue> SaveValues;

    private void Start() => LoadGame("TestSave");
    private void OnApplicationQuit() => SaveGame("TestSave");

    public void SaveGame(string SaveName)
    {
        string SaveFile = string.Empty;

        foreach (SaveValue SaveValue in SaveValues)
        {
            SaveFile += $"{SaveValue.GetName()}:{SaveValue.GetValue()}";
            SaveFile += "|";
        }

        using (StreamWriter sw = File.CreateText($"{Application.dataPath}\\Save System\\Save Files\\{SaveName}.txt"))
        {
            sw.WriteLine(SaveFile);
        }

#if UNITY_EDITOR
        AssetDatabase.Refresh();
#endif
    }

    public void LoadGame(string SaveName)
    {
        if(!File.Exists($"{Application.dataPath}\\Save System\\Save Files\\{SaveName}.txt"))
        {
            Debug.LogError("Save File Does Not Exist, Please Add One");
            return;
        }

        Dictionary<string, string> SaveNamesAndValues = new Dictionary<string, string>();

        string SaveFile = File.ReadAllText($"{Application.dataPath}\\Save System\\Save Files\\{SaveName}.txt");

        foreach (SaveValue SaveValue in SaveValues)
        {
            SaveValue.SetValue(GetValueFromFileContents(SaveFile, SaveValue.GetName()));
        }

    }

    public static string GetValueFromFileContents(string contents, string key)
    {
        string[] entries = contents.Split('|', StringSplitOptions.RemoveEmptyEntries);

        foreach (string entry in entries)
        {
            string[] keyValue = entry.Split(':');
            if (keyValue.Length == 2 && keyValue[0].EndsWith(key))
            {
                return keyValue[1];
            }
        }

        return null;
    }
}