using System.Runtime.CompilerServices;
using Codice.Client.BaseCommands;
using UnityEditor;
using UnityEngine;

namespace ScriptableEvents.Editor
{
    [CustomEditor(typeof(ScriptableEventBase),true)]
    public class ScriptableEventEditor : UnityEditor.Editor
    {
        private ScriptableEventBase _target;
        
        public override void OnInspectorGUI()//Note frequently called, if manby things are done it can slow down editor.
        {
            //as returns null if it fails, whereas regular casting would throw an exception
            //_target = target as ScriptableEvent;//A different way of casting an object
            _target = (ScriptableEventBase)target;
            
            
            
            base.OnInspectorGUI();
            
            if (GUILayout.Button("Debug Raise Event")) //Only needs thing, not posisiotn, not layout
            {
                _target.Raise();
            }

            //var pos = new Rect(Vector2.zero, new Vector2(10,10));
            //GUI.Button(pos, "My TOehr Button");

            //GUILayout
            //EditorGUI
            //EditorGUILayout

            //HArd to keep track of what is here, if it has layout it needs to be provided with a position.
        }
    }
}