using UnityEngine;
using System.Collections;
using UnityEditor;

/// <summary>
/// @author Mike Dobson
/// </summary>

[CustomPropertyDrawer(typeof(ScriptFacings))]
public class FacingEditorDrawer : PropertyDrawer {

//    float extraHeight = 65f;
//
//    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
//    {
//        EditorGUI.BeginProperty(position, label, property);
//        //-------------------------------------------
//        //common variables
//        SerializedProperty facingType = property.FindPropertyRelative("facingType");
//        //look at target and look chain variables
//        SerializedProperty targets = property.FindPropertyRelative("targets");
//        SerializedProperty rotationSpeed = property.FindPropertyRelative("rotationSpeed");
//        SerializedProperty lockTimes = property.FindPropertyRelative("lockTimes");
//        //wait variable
//        SerializedProperty facingTime = property.FindPropertyRelative("facingTime");
//        //inspector only variables
//        SerializedProperty showInEditor = property.FindPropertyRelative("showInEditor");
//
//        SerializedProperty targetsSize = property.FindPropertyRelative("targetSize");
//
//        //local variables
//        float displayHeight = 16f;
//        float displayHeightDif = 18f;
//        float offsetX = position.x;
//        float offsetY = position.y;
//
//        //display for facing type
//        Rect FacingDrawerDisplay = new Rect(offsetX, offsetY, position.width, displayHeight);
//        offsetY += displayHeightDif;
//        EditorGUI.PropertyField(FacingDrawerDisplay, facingType);
//
//        //switch on facing type
//        switch(facingType.enumValueIndex)
//        {
//            
//            case (int)FacingTypes.LOOKAT:
//                //display block for look at
//                FacingDrawerDisplay = new Rect(offsetX, offsetY, 70f, displayHeight);
//                offsetX += 70f;
//                EditorGUI.LabelField(FacingDrawerDisplay, "Look at");
//                //units
//                FacingDrawerDisplay = new Rect(offsetX, offsetY, position.width, displayHeight);
//                offsetX = position.x;
//                offsetY += displayHeightDif;
//                targets.InsertArrayElementAtIndex(0);
//                EditorGUI.ObjectField(FacingDrawerDisplay, targets.GetArrayElementAtIndex(0), GUIContent.none);
//
//                //display block for rotate time and lock time
//                //rotate over
//                FacingDrawerDisplay = new Rect(offsetX, offsetY, 160f, displayHeight);
//                offsetX += 145f;
//                EditorGUI.LabelField(FacingDrawerDisplay, "Rotate to target over");
//                //time
//                FacingDrawerDisplay = new Rect(offsetX, offsetY, 50f, displayHeight);
//                offsetX += 35f;
//                rotationSpeed.InsertArrayElementAtIndex(0);
//                EditorGUI.PropertyField(FacingDrawerDisplay, rotationSpeed.GetArrayElementAtIndex(0), GUIContent.none);
//                //units
//                FacingDrawerDisplay = new Rect(offsetX, offsetY, 55f, displayHeight);
//                offsetX = position.x;
//                offsetY += displayHeightDif;
//                EditorGUI.LabelField(FacingDrawerDisplay, "secs");
//
//                //Lock for
//                FacingDrawerDisplay = new Rect(offsetX, offsetY, 140f, displayHeight);
//                offsetX += 125f;
//                EditorGUI.LabelField(FacingDrawerDisplay, "Lock on target for");
//
//                //time
//                FacingDrawerDisplay = new Rect(offsetX, offsetY, 50f, displayHeight);
//                offsetX += 35f;
//                lockTimes.InsertArrayElementAtIndex(0);
//                EditorGUI.PropertyField(FacingDrawerDisplay, lockTimes.GetArrayElementAtIndex(0), GUIContent.none);
//                //units
//                FacingDrawerDisplay = new Rect(offsetX, offsetY, 50f, displayHeight);
//                offsetX = position.x;
//                offsetY += displayHeightDif;
//                EditorGUI.LabelField(FacingDrawerDisplay, "secs.");
//
//                //display block for return time
//                //return for
//                FacingDrawerDisplay = new Rect(offsetX, offsetY, 190f, displayHeight);
//                offsetX += 175f;
//                EditorGUI.LabelField(FacingDrawerDisplay, "Rotate back to origin over");
//                //time
//                FacingDrawerDisplay = new Rect(offsetX, offsetY, 50f, displayHeight);
//                offsetX += 40f;
//                rotationSpeed.InsertArrayElementAtIndex(1);
//                EditorGUI.PropertyField(FacingDrawerDisplay, rotationSpeed.GetArrayElementAtIndex(1), GUIContent.none);
//                //units
//                FacingDrawerDisplay = new Rect(offsetX, offsetY, 65f, displayHeight);
//                offsetX = position.x;
//                EditorGUI.LabelField(FacingDrawerDisplay, "secs.");
//                break;
//
//            case (int)FacingTypes.LOOKCHAIN:
//                FacingDrawerDisplay = new Rect(offsetX, offsetY, 150f, displayHeight);
//                offsetX += 135f;
//                EditorGUI.LabelField(FacingDrawerDisplay, "Amount of targets:");
//
//                FacingDrawerDisplay = new Rect(offsetX, offsetY, 50f, displayHeight);
//                offsetX = position.x;
//                EditorGUI.PropertyField(FacingDrawerDisplay, targetsSize, GUIContent.none);
//
//                if(GUILayout.Button("Edit Look Chain"))
//                {
//                    LookChainWindowEditor.Show(property);
//                }
//                //for (int i = 0; i < targetsSize.intValue; i++ )
//                //{
//                //    targets.InsertArrayElementAtIndex(i);
//                //    rotationSpeed.InsertArrayElementAtIndex(i);
//                //    lockTimes.InsertArrayElementAtIndex(i);
//                //}
//                //rotationSpeed.InsertArrayElementAtIndex(targetsSize.intValue);
//
//                    break;
//            case (int)FacingTypes.WAIT:
//                //display block for wait time to next facing
//                FacingDrawerDisplay = new Rect(offsetX, offsetY, 70f, displayHeight);
//                offsetX += 60f;
//                EditorGUI.LabelField(FacingDrawerDisplay, "Wait for");
//
//                FacingDrawerDisplay = new Rect(offsetX, offsetY, 50f, displayHeight);
//                offsetX += 40f;
//                EditorGUI.PropertyField(FacingDrawerDisplay, facingTime, GUIContent.none);
//
//                FacingDrawerDisplay = new Rect(offsetX, offsetY, 200f, displayHeight);
//                offsetX = position.x;
//                EditorGUI.LabelField(FacingDrawerDisplay, "seconds before next facing.");
//                break;
//        }
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
