using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Integer (please rename)", menuName = "Save Values/Integer", order = 900)]
public class IntegerSaveValue : SaveValue
{
    public int Value;

    public override string GetName()
    {
        return $"{this.name}_Int";
    }

    public override string GetValue()
    {
        return Value.ToString();
    }

    public override void SetValue(string RawValue)
    {
        Value = int.Parse(RawValue);
    }
}
