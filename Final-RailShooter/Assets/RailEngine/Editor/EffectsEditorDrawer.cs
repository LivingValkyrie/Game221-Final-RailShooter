using UnityEngine;
using System.Collections;
using UnityEditor;

/// <summary>
/// @author Mike Dobson
/// </summary>

[CustomPropertyDrawer(typeof(ScriptEffects))]
public class EffectsEditorDrawer : PropertyDrawer {

//    bool movementShow = false;
//    ScriptMovements waypointScript;
//    float extraHeight = 65f;
//    float displaySize = 20f;
//    float numDisplays = 0f;
		//asd
//    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
//    {
//        EditorGUI.BeginProperty(position, label, property);
//        //-------------------------------------------
//
//        //Common variables
//        SerializedProperty effectType = property.FindPropertyRelative("effectType");
//        SerializedProperty effectTime = property.FindPropertyRelative("effectTime");
//
//        //variables for fade & splatter
//        SerializedProperty fadeInTime = property.FindPropertyRelative("fadeInTime");
//        SerializedProperty fadeOutTime = property.FindPropertyRelative("fadeOutTime");
//
//        //variables for splatter
//        SerializedProperty imageScale = property.FindPropertyRelative("imageScale");
//
//        //variables for camera shake
//        SerializedProperty magnitude = property.FindPropertyRelative("magnitude");
//
//        //variables for editor window
//        SerializedProperty showInEditor = property.FindPropertyRelative("showInEditor");
//
//        float offsetX = position.x;
//        float offsetY = position.y;
//
//        Rect effectTypeDisplay = new Rect(offsetX, offsetY, position.width, 15f);
//        offsetY += 17f;
//        EditorGUI.PropertyField(effectTypeDisplay, effectType);
//
//        Rect effectTimeDisplay = new Rect(offsetX, offsetY, position.width, 15f);
//        offsetY += 17f;
//        EditorGUI.PropertyField(effectTimeDisplay, effectTime);
//
//        switch(effectType.enumValueIndex)
//        {
//            case (int)EffectTypes.SPLATTER:
//                Rect imageScaleDisplay = new Rect(offsetX, offsetY, position.width, 15f);
//                offsetY += 17f;
//                EditorGUI.PropertyField(imageScaleDisplay, imageScale);
//                goto case (int)EffectTypes.FADE;
//            case (int)EffectTypes.FADE:
//                Rect fadeInDisplay = new Rect(offsetX, offsetY, position.width / 2, 15f);
//                offsetX += position.width / 2;
//                EditorGUI.PropertyField(fadeInDisplay, fadeInTime);
//
//                Rect fadeOutDisplay = new Rect(offsetX, offsetY, position.width / 2, 15f);
//                offsetX = position.x;
//                offsetY = position.y + 34f;
//                EditorGUI.PropertyField(fadeOutDisplay, fadeOutTime);
//                break;
//            case (int)EffectTypes.SHAKE:
//                Rect magnitudeDisplay = new Rect(offsetX, offsetY, position.width, 15f);
//                EditorGUI.PropertyField(magnitudeDisplay, magnitude);
//                break;
//            case (int)EffectTypes.WAIT:
//                Rect waitLabelDisplay = new Rect(offsetX, offsetY, position.width, 15f);
//                EditorGUI.LabelField(waitLabelDisplay, "No other options for wait effect");
//                break;
//        }
//
//
//        //===========================================
//        EditorGUI.EndProperty();
//    }
//
//    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
//    {
//        return base.GetPropertyHeight(property, label) + (extraHeight);
//    }
}
