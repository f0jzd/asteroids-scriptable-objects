using System;
using UnityEngine;

[Serializable] public class FloatRef
{
    //Evaluate to string
    //public static string VariableName = nameof(_variable.Value);
    
    
    [SerializeField] private bool _useSimpleValue;
    [SerializeField] private FloatVariable _variable;
    [SerializeField] private float _simpleValue;

    public float Value => _useSimpleValue ? _simpleValue : _variable.Value;

    #if UNITY_EDITOR//ONly works in editor
    public static string VariableName = nameof(_variable);
    public static string UseSimpleValueName = nameof(_simpleValue);
    public static string UseSimpleValue = nameof(_useSimpleValue);
    #endif
    
    
}

public class FloatRefaNames : FloatRef
{
    /*public static string[] Names = {
        nameof(_variable),
        nameof(_simpleValue),
        nameof(_useSimpleValue)
    };*/
    
    
    /*public static string VariableName = nameof(_variable);
    public static string UseSimpleValueName = nameof(_simpleValue);
    public static string UseSimpleValue = nameof(_useSimpleValue);*/
}