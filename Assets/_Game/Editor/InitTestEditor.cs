using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InitTestEditor : MonoBehaviour
{
    
    [CustomEditor(typeof(InitTest))]
    // Start is called before the first frame update
    private void OnEnable()
    {
       // Debug.Log("<b> TESTING </b> added to Scripting Define Symbols in <b> Player Setting </b>");
       // PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone,"Testing");
    }
}
