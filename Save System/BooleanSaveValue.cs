using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Boolean (please rename)", menuName = "Save Values/Boolean", order = 900)]
public class BooleanSaveValue : SaveValue
{
    public bool Value;

    public override string GetName()
    {
        return $"{this.name}_Bool";
    }

    public override string GetValue()
    {
        return Value ? "true" : "false";
    }

    public override void SetValue(string RawValue)
    {
        Value = bool.Parse(RawValue);
    }
}
