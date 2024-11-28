using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// used to fix a unity bug where scriptable object data persists through runtime
[RequireComponent(typeof(SaveManager))]
public class SaveValueEditorFix : MonoBehaviour
{
    private Dictionary<SaveValue, string> OriginalEditorSaveValues = new Dictionary<SaveValue, string>();

    private SaveManager SaveManager;

    private void Awake()
    {
        SaveManager = GetComponent<SaveManager>();

        SaveManager.OnPreLoad += PreLoadFix;
        SaveManager.OnPostSave += PostSaveFix;
    }

    private void PreLoadFix()
    {
        foreach (SaveValue SaveValue in SaveManager.SaveValues)
        {
            OriginalEditorSaveValues.Add(SaveValue, SaveValue.GetValue());
        }
    }

    private void PostSaveFix()
    {
        foreach (KeyValuePair<SaveValue, string> SaveValue in OriginalEditorSaveValues)
        {
            SaveValue.Key.SetValue(SaveValue.Value);
        }
    }

}
