using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;

/// <summary>
/// @author Mike Dobson
/// </summary>

public class LookChainWindowEditor : EditorWindow {

    float[] lockTimes;
    float[] rotationSpeed;
    GameObject[] targets;

    ScriptRailEngine railEngine;

    static int facingFocus = 0;



    public static void Init(int pFacingFocus)
    {
        LookChainWindowEditor window = (LookChainWindowEditor)EditorWindow.GetWindow(typeof(LookChainWindowEditor));
        window.Show();
        facingFocus = pFacingFocus;
    }

    void OnFocus()
    {
        railEngine = GameObject.FindWithTag("Player").GetComponent<ScriptRailEngine>();
        lockTimes = railEngine.facings[facingFocus].lockTimes;
        rotationSpeed = railEngine.facings[facingFocus].rotationSpeed;
        targets = railEngine.facings[facingFocus].targets;
    }

    //on the editor Window
    void OnGUI()
    {
        //minimum size for the display
        minSize = new Vector2(250, 300);

        //local variables
        Rect windowDisplay;
        float displayHeight = 17f;
        float displayHeightDif = 20f;
        float offsetX = 5;
        float offsetY = 5;

        for (int i = 0; i < targets.Length; i++ )
        {
            windowDisplay = new Rect(offsetX, offsetY, 100f, displayHeight);
            offsetX +=10;
            offsetY += displayHeightDif;
            EditorGUI.LabelField(windowDisplay, "Target " + (i + 1));
            windowDisplay = new Rect(offsetX, offsetY, 100f, displayHeight);
            offsetX += 100f;
            EditorGUI.LabelField(windowDisplay, "Look at Target");
            windowDisplay = new Rect(offsetX, offsetY, 100f, displayHeight);
            offsetX = 15f;
            offsetY += displayHeightDif;
            targets[i] = (GameObject)EditorGUI.ObjectField(windowDisplay, targets[i], typeof(GameObject));
            windowDisplay = new Rect(offsetX, offsetY, 150f, displayHeight);
            offsetX += 150f;
            EditorGUI.LabelField(windowDisplay, "Rotate to target over");
            windowDisplay = new Rect(offsetX, offsetY, 50f, displayHeight);
            offsetX += 50f;
            rotationSpeed[i] = EditorGUI.FloatField(windowDisplay, rotationSpeed[i]);
            windowDisplay = new Rect(offsetX, offsetY, 50f, displayHeight);
            offsetX = 15f;
            offsetY += displayHeightDif;
            EditorGUI.LabelField(windowDisplay, "secs");
            windowDisplay = new Rect(offsetX, offsetY, 150f, displayHeight);
            offsetX += 150f;
            EditorGUI.LabelField(windowDisplay, "Lock to target for");
            windowDisplay = new Rect(offsetX, offsetY, 50f, displayHeight);
            offsetX += 50f;
            lockTimes[i] = EditorGUI.FloatField(windowDisplay, lockTimes[i]);
            windowDisplay = new Rect(offsetX, offsetY, 50f, displayHeight);
            offsetY += displayHeightDif;
            offsetX = 5f;
            EditorGUI.LabelField(windowDisplay, "secs");
        }
        offsetY += displayHeightDif;
        windowDisplay = new Rect(offsetX, offsetY, 155f, displayHeight);
        offsetX += 155f;
        EditorGUI.LabelField(windowDisplay, "Rotate back to origin over");
        windowDisplay = new Rect(offsetX, offsetY, 50f, displayHeight);
        offsetX += 50f;
        rotationSpeed[rotationSpeed.Length - 1] = EditorGUI.FloatField(windowDisplay, rotationSpeed[rotationSpeed.Length - 1]);
        windowDisplay = new Rect(offsetX, offsetY, 50f, displayHeight);
        EditorGUI.LabelField(windowDisplay, "secs");
    }

    void OnLostFocus()
    {
		railEngine.facings [facingFocus].lockTimes = lockTimes;
		railEngine.facings [facingFocus].rotationSpeed = rotationSpeed;
		railEngine.facings [facingFocus].targets = targets;
    }
}
