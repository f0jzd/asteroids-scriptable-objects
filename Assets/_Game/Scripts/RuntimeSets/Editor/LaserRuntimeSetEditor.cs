using System;
using UnityEditor;
using UnityEngine;

namespace DefaultNamespace.RuntimeSets.Editor
{
    [CustomEditor(typeof(LaserRuntimeSet))]
    public class LaserRuntimeSetEditor : UnityEditor.Editor
    {
        private LaserRuntimeSet _target;
        private int _count;

        /*public void OnValidate()
        {
            _target = (LaserRuntimeSet)target;
            _count = _target.Amount;

        }*/

        public override bool RequiresConstantRepaint()
        {
            _target = (LaserRuntimeSet)target;
            if (_target.Amount == _count)
            {
                return false;
            }
            return true;
        }

        public override void OnInspectorGUI()
        {
            //base.OnInspectorGUI();

            //var myUnCastTarget = target;
            _target = (LaserRuntimeSet)target;
            _count = _target.Amount;

            using (new EditorGUILayout.HorizontalScope())//Same as EditorGUIlayout beginhorizonal and EndHorizontal.
            {
                EditorGUILayout.LabelField($"Amount of Lasers: {_count}" );
                //EditorGUILayout.LabelField(_count.ToString());
            }
            
            
            
        }
    }
}