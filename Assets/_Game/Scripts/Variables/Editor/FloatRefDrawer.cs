using Codice.CM.Common;
using UnityEditor;
using UnityEngine;

namespace Variables.Editor
{
    
    [CustomPropertyDrawer(typeof(FloatRef))] //Attribute
    public class FloatRefDrawer : UnityEditor.PropertyDrawer
    {
        
        //The names that will show up with the buttons popupOptions
        private readonly string[] popupOptions = {"use Simple", "Use variable"};

        private GUIStyle popupStyle;
        
        SerializedProperty useSimpleProperty;
        SerializedProperty variableProperty; 
        SerializedProperty simpleValueProperty; 

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            //EditorGUI.BeginChangeCheck();
            label = EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, label);
            
            
            //EditorGUI.LabelField(position,label);//Draws the name of the variable

            //Get Properties
            //void GetPropertiet()
            //{
            //PUT THE STUFF BELOW IN HERE
            //}


            GetProperties(property);

            


            //Draw button

            //Preset for how a button will look
            //Create style
            popupStyle ??= new GUIStyle(GUI.skin.GetStyle("PaneOptions"))
            {
                imagePosition = ImagePosition.ImageOnly
            };

            //Calculate Button rect
            var buttonRect = new Rect(position);

            //Move the yMin to the top of the margin, makes it so we only see the kebab thingy marker
            buttonRect.yMin += popupStyle.margin.top;

            //Here we set the width of the button ot the right margin, makes it so we only see the kebab thingy marker
            buttonRect.width = popupStyle.fixedWidth + popupStyle.margin.right;

            //Set the positin, actually updating the current position.
            position.xMin = buttonRect.xMax;


            //Creates a generic popup Menu.

            //int selectedIndex;
            //if (useSimpleProperty.boolValue)
            //{
            //    selectedIndex = 0;
            //}
            //else
            //{
            //    selectedIndex = 1;
            //}
            
            //^This is the same as 
            //useSimpleProperty.boolValue? 0 : 1;
            //

            //EditorGUI.BeginChangeCheck(); Start a change check in the UI to detect any changes.

            //Read what the user is doing.
            var result = EditorGUI.Popup(buttonRect, useSimpleProperty.boolValue ? 0 : 1, popupOptions, popupStyle);
            useSimpleProperty.boolValue = result == 0;

            var propertyToDraw = useSimpleProperty.boolValue ? simpleValueProperty : variableProperty;

            EditorGUI.PropertyField(position, propertyToDraw, GUIContent.none);


            //position = EditorGUI.PrefixLabel(position, label); //Creates a label and updates the position to where the label ends
            //Drawing the name of the variable, 


            //Draw bool
            //position.y += GetPropertyHeight(useSimpleProperty, GUIContent.none);
            //position.y += position.height;
            //position.height += position.height;
            //position.height += position.height;Scales the actual variable thingy


            //Draw Variable
            //EditorGUI.PropertyField(position, variableProperty, GUIContent.none);

            //EditorGUI.EndChangeCheck();
            EditorGUI.EndProperty();
            
            //EditorGUI.BeginProperty(position, label, property);
            //EditorGUI.PropertyField(position, property);
            //EditorGUI.EndProperty();


            //EditorGUI.BeginProperty();
            //We can edit stuff everywhere here
            // = change state
            //EditorGUI.EndProperty();

            //EditorGUI.LabelField(position,"my string");

            //EditorGUILayout.LabelField(label);//tries to use an autoamtic layout in a method that does not support it
            
            
            
        }

        private void GetProperties(SerializedProperty property)
        {
            useSimpleProperty = property.FindPropertyRelative(FloatRef.UseSimpleValue);
            variableProperty = property.FindPropertyRelative(FloatRef.VariableName);
            simpleValueProperty = property.FindPropertyRelative(FloatRef.UseSimpleValueName);
        }
    }
}