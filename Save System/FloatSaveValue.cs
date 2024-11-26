using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Float (please rename)", menuName = "Save Values/Float", order = 900)]
public class FloatSaveValue : SaveValue
{
    public float Value;

    public override string GetName()
    {
        return $"{this.name}_Float";
    }

    public override string GetValue()
    {
        return Value.ToString();
    }

    public override void SetValue(string RawValue)
    {
        Value = float.Parse(RawValue);
    }
}
