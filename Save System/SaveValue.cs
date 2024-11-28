using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveValue : ScriptableObject
{
    public virtual string GetName() { return ""; }

    public virtual string GetValue() { return ""; }

    public virtual void SetValue(string RawValue) {}
}
