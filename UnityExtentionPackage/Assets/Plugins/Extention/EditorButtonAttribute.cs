using System;
using UnityEngine;

[System.AttributeUsage(System.AttributeTargets.Method)]
public class EditorButtonAttribute : PropertyAttribute
{
    public readonly string buttonName;

    public EditorButtonAttribute(string name=null)
    {
        buttonName = name;
    }
}