using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// @author Mike Dobson
/// </summary>

public class EngineWindowEditor : EditorWindow {



    List<ScriptMovements> movements;
    List<ScriptEffects> effects;
    List<ScriptFacings> facings;
    ScriptRailEngine railEngine;

    //local Variables
    int movementFocus = 0;
    int effectFocus = 0;
    int facingFocus = 0;
    float offsetX;
    float offsetY;
    Rect windowDisplay;
    const float DISPLAY_HEIGHT = 17F;
    const float DISPLAY_DIF = 20F;
    const float ELEMENT_DISPLAY = 205F;
    GUIStyle miniRight = new GUIStyle(EditorStyles.miniButtonRight);
    GUIStyle miniLeft = new GUIStyle(EditorStyles.miniButtonLeft);
    GUIStyle miniMid = new GUIStyle(EditorStyles.miniButtonMid);

    void OnFocus()
    {
        railEngine = GameObject.FindWithTag("Player").GetComponent<ScriptRailEngine>();
        movements = railEngine.movements;
        effects = railEngine.effects;
        facings = railEngine.facings;

        if (effects.Count <= 0)
        {
            effects.Add(new ScriptEffects());
            effectFocus = 0;
        }
        if (facings.Count <= 0)
        {
            facings.Add(new ScriptFacings());
            facingFocus = 0;
        }
        if (movements.Count <= 0)
        {
            movements.Add(new ScriptMovements());
            movementFocus = 0;
        }

//		Debug.Log ("~~~ON FOCUS MOVEMENT COUNT~~~\n" +
//		           "\tENGINE: " + railEngine.movements.Count +
//		           "\t\tWINDOW: " + movements.Count);
    }

    void OnGUI()
    {
        minSize = new Vector2(750, 300);
        //display variables
        offsetX = 5f;
        offsetY = 10f;        
        GUI.color = Color.white;

        //Error Block
		if (movementFocus >= movements.Count)
			movementFocus = 0;
		if (effectFocus >= effects.Count)
			effectFocus = 0;
		if (facingFocus >= facings.Count)
			facingFocus = 0;

        MovementGUI();
        EffectGUI();
        FacingGUI();
        #region added to help browsing


        //----------------------------------
        ////Display block for movement
        ////Movement Square
        ////top
        //Vector2 movementPoint1 = new Vector2(-110, 6);
        //Vector2 movementPoint2 = new Vector2(117, 6);
        //Drawing.DrawLine(movementPoint1, movementPoint2, Color.black, 1f, true);
        ////right
        //Vector2 movementPoint3 = new Vector2(229, 8);
        //Vector2 movementPoint4 = new Vector2(229, 195);
        //Drawing.DrawLine(movementPoint3, movementPoint4, Color.black, 1f, true);
        ////bottom
        //Vector2 movementPoint5 = new Vector2(-110, 193);
        //Vector2 movementPoint6 = new Vector2(117, 193);
        //Drawing.DrawLine(movementPoint5, movementPoint6, Color.black, 1f, true);
        ////left
        //Vector2 movementPoint7 = new Vector2(4, 8);
        //Vector2 movementPoint8 = new Vector2(4, 195);
        //Drawing.DrawLine(movementPoint7, movementPoint8, Color.black, 1f, true);

        ////Movement element info
        //Rect windowDisplay = new Rect(offsetX, offsetY, ELEMENT_DISPLAY, DISPLAY_HEIGHT);
        //offsetX += 10f;
        //offsetY += DISPLAY_DIF;
        //EditorGUI.LabelField(windowDisplay, "Movement " + (movementFocus + 1));

        ////movement type
        //windowDisplay = new Rect(offsetX, offsetY, 100f, DISPLAY_HEIGHT);
        //offsetX += 100f;
        //EditorGUI.LabelField(windowDisplay, "Movement Type");
        //windowDisplay = new Rect(offsetX, offsetY, 110f, DISPLAY_HEIGHT);
        //offsetY += DISPLAY_DIF;
        //offsetX = 15f;
        //movements[movementFocus].moveType = (MovementTypes)EditorGUI.EnumPopup(windowDisplay, movements[movementFocus].moveType);


        //switch(movements[movementFocus].moveType)
        //{
        //    case MovementTypes.BEZIER:
        //        //movement time
        //        windowDisplay = new Rect(offsetX, offsetY, 120f, DISPLAY_HEIGHT);
        //        offsetX += 120f;
        //        EditorGUI.LabelField(windowDisplay, "Move to target over");
        //        windowDisplay = new Rect(offsetX, offsetY, 50f, DISPLAY_HEIGHT);
        //        offsetX += 50f;
        //        movements[movementFocus].movementTime = EditorGUI.FloatField(windowDisplay, movements[movementFocus].movementTime);
        //        windowDisplay = new Rect(offsetX, offsetY, 45f, DISPLAY_HEIGHT);
        //        offsetY += DISPLAY_DIF;
        //        offsetX = 15f;
        //        EditorGUI.LabelField(windowDisplay, "secs");
        //        //display curve target
        //        offsetY += DISPLAY_DIF;
        //        windowDisplay = new Rect(offsetX, offsetY, 80f, DISPLAY_HEIGHT);
        //        offsetX += 80f;
        //        EditorGUI.LabelField(windowDisplay, "Curve Target");
        //        windowDisplay = new Rect(offsetX, offsetY, 135f, DISPLAY_HEIGHT);
        //        offsetY -= DISPLAY_DIF;
        //        offsetX = 15f;
        //        movements[movementFocus].curveWaypoint = (GameObject) EditorGUI.ObjectField(windowDisplay, GUIContent.none, movements[movementFocus].curveWaypoint, typeof(GameObject));
        //        //display end target
        //        windowDisplay = new Rect(offsetX, offsetY, 80f, DISPLAY_HEIGHT);
        //        offsetX += 80f;
        //        EditorGUI.LabelField(windowDisplay, "End Target");
        //        windowDisplay = new Rect(offsetX, offsetY, 135f, DISPLAY_HEIGHT);
        //        offsetY = 120f;
        //        offsetX = 15f;
        //        movements[movementFocus].endWaypoint = (GameObject)EditorGUI.ObjectField(windowDisplay, GUIContent.none, movements[movementFocus].endWaypoint, typeof(GameObject));
        //        break;
        //    case MovementTypes.STRAIGHT:
        //        //movement time
        //        windowDisplay = new Rect(offsetX, offsetY, 120f, DISPLAY_HEIGHT);
        //        offsetX += 120f;
        //        EditorGUI.LabelField(windowDisplay, "Move to target over");
        //        windowDisplay = new Rect(offsetX, offsetY, 50f, DISPLAY_HEIGHT);
        //        offsetX += 50f;
        //        movements[movementFocus].movementTime = EditorGUI.FloatField(windowDisplay, movements[movementFocus].movementTime);
        //        windowDisplay = new Rect(offsetX, offsetY, 45f, DISPLAY_HEIGHT);
        //        offsetY += DISPLAY_DIF;
        //        offsetX = 15f;
        //        EditorGUI.LabelField(windowDisplay, "secs");
        //        //display end target
        //        windowDisplay = new Rect(offsetX, offsetY, 80f, DISPLAY_HEIGHT);
        //        offsetX += 80f;
        //        EditorGUI.LabelField(windowDisplay, "End Target");
        //        windowDisplay = new Rect(offsetX, offsetY, 130f, DISPLAY_HEIGHT);
        //        offsetY = 120f;
        //        offsetX = 15f;
        //        movements[movementFocus].endWaypoint = (GameObject) EditorGUI.ObjectField(windowDisplay, GUIContent.none, movements[movementFocus].endWaypoint, typeof(GameObject));
        //        break;
        //    case MovementTypes.WAIT:
        //        //movement time
        //        windowDisplay = new Rect(offsetX, offsetY, 120f, DISPLAY_HEIGHT);
        //        offsetX += 120f;
        //        EditorGUI.LabelField(windowDisplay, "Wait at location for");
        //        windowDisplay = new Rect(offsetX, offsetY, 50f, DISPLAY_HEIGHT);
        //        offsetX += 50f;
        //        movements[movementFocus].movementTime = EditorGUI.FloatField(windowDisplay, movements[movementFocus].movementTime);
        //        windowDisplay = new Rect(offsetX, offsetY, 45f, DISPLAY_HEIGHT);
        //        offsetY += DISPLAY_DIF;
        //        offsetX = 15f;
        //        EditorGUI.LabelField(windowDisplay, "secs");
        //        offsetY = 120f;
        //        offsetX = 15f;
        //        break;
        //}
        ////Movement Buttons Display
        //offsetY += DISPLAY_DIF;
        //offsetX += 40f;
        //windowDisplay = new Rect(offsetX, offsetY, 40f, DISPLAY_HEIGHT);
        //offsetX += 40f;

        //GUIStyle miniRight = new GUIStyle (EditorStyles.miniButtonRight);
        //GUIStyle miniLeft = new GUIStyle (EditorStyles.miniButtonLeft);
        //GUIStyle miniMid = new GUIStyle (EditorStyles.miniButtonMid);

        //if(GUI.Button(windowDisplay,"Prev", miniLeft))
        //{
        //    if (movementFocus > 0)
        //    {
        //        movementFocus--;
        //    }
        //}
        //windowDisplay = new Rect(offsetX, offsetY, 40f, DISPLAY_HEIGHT);
        //offsetX += 40f;
        //if(GUI.Button(windowDisplay, "Add", miniMid))
        //{
        //    movements.Insert(movementFocus + 1, new ScriptMovements());
        //    movementFocus++;
        //}
        //windowDisplay = new Rect(offsetX, offsetY, 40f, DISPLAY_HEIGHT);
        //offsetX -= 75f;
        //offsetY += 30f;
        //if(GUI.Button(windowDisplay, "Next", miniRight))
        //{
        //    if (movementFocus < movements.Count - 1)
        //    {
        //        movementFocus++;
        //    }
        //}
        //windowDisplay = new Rect(offsetX, offsetY, 110f, DISPLAY_HEIGHT);
        //offsetX += 210f;
        //offsetY = 10f;
        //GUI.color = Color.red;
        //if(GUI.Button(windowDisplay, "Delete Waypoint"))
        //{
        //    if (movementFocus == movements.Count - 1 && effects.Count > 1)
        //    {
        //        movements.RemoveAt(movementFocus);
        //        movementFocus--;
        //    }
        //    else if (movements.Count > 1)
        //    {
        //        movements.RemoveAt(movementFocus);
        //    }
        //    else
        //    {
        //        Debug.Log("Cannot remove last element from list");
        //    }
        //}
        //GUI.color = Color.white;

        ////Effect Display Block
        ////Effects Square
        ////Top
        //Vector2 effectsPoint1 = new Vector2(154f, 6f);
        //Vector2 effectsPoint2 = new Vector2(380f, 6f);
        //Drawing.DrawLine(effectsPoint1, effectsPoint2, Color.black, 1f, true);
        ////left
        //Vector2 effectsPoint3 = new Vector2(268, 8);
        //Vector2 effectsPoint4 = new Vector2(268, 195);
        //Drawing.DrawLine(effectsPoint3, effectsPoint4, Color.black, 1f, true);
        ////bottom
        //Vector2 effectsPoint5 = new Vector2(154, 193);
        //Vector2 effectsPoint6 = new Vector2(380, 193);
        //Drawing.DrawLine(effectsPoint5, effectsPoint6, Color.black, 1f, true);
        ////Right
        //Vector2 effectsPoint7 = new Vector2(491, 8);
        //Vector2 effectsPoint8 = new Vector2(491, 195);
        //Drawing.DrawLine(effectsPoint7, effectsPoint8, Color.black, 1f, true);
        //offsetX = 270f;
        //offsetY = 10f;
        ////Effects Info
        //windowDisplay = new Rect(offsetX, offsetY, ELEMENT_DISPLAY, DISPLAY_HEIGHT);
        //offsetY += DISPLAY_DIF;
        //offsetX = 280f;
        //EditorGUI.LabelField(windowDisplay, "Effect " + (effectFocus + 1));
        ////type
        //windowDisplay = new Rect(offsetX, offsetY, 100f, DISPLAY_HEIGHT);
        //offsetX += 100f;
        //EditorGUI.LabelField(windowDisplay, "Effect Type");
        //windowDisplay = new Rect(offsetX, offsetY, 105f, DISPLAY_HEIGHT);
        //offsetY += DISPLAY_DIF;
        //offsetX = 280f;
        //effects[effectFocus].effectType = (EffectTypes)EditorGUI.EnumPopup(windowDisplay, effects[effectFocus].effectType);

        ////switch on type
        //switch(effects[effectFocus].effectType)
        //{
        //    case EffectTypes.SPLATTER:
        //        //time
        //        windowDisplay = new Rect(offsetX, offsetY, 130f, DISPLAY_HEIGHT);
        //        offsetX += 130f;
        //        EditorGUI.LabelField(windowDisplay, "Effect lasts for");
        //        windowDisplay = new Rect(offsetX, offsetY, 40f, DISPLAY_HEIGHT);
        //        offsetX += 40f;
        //        effects[effectFocus].effectTime = EditorGUI.FloatField(windowDisplay, effects[effectFocus].effectTime);
        //        windowDisplay = new Rect(offsetX, offsetY, 40f, DISPLAY_HEIGHT);
        //        offsetY += DISPLAY_DIF;
        //        offsetX = 280f;
        //        EditorGUI.LabelField(windowDisplay, "secs");
        //        //FadeIn/out
        //        windowDisplay = new Rect(offsetX, offsetY, 45f, DISPLAY_HEIGHT);
        //        offsetX += 45f;
        //        EditorGUI.LabelField(windowDisplay, "Fade in");
        //        windowDisplay = new Rect(offsetX, offsetY, 20f, DISPLAY_HEIGHT);
        //        offsetX += 20f;
        //        effects[effectFocus].fadeInTime = EditorGUI.FloatField(windowDisplay, effects[effectFocus].fadeInTime);
        //        windowDisplay = new Rect(offsetX, offsetY, 80f, DISPLAY_HEIGHT);
        //        offsetX += 80f;
        //        EditorGUI.LabelField(windowDisplay, "secs, and out");
        //        windowDisplay = new Rect(offsetX, offsetY, 20f, DISPLAY_HEIGHT);
        //        offsetX += 20f;
        //        effects[effectFocus].fadeOutTime = EditorGUI.FloatField(windowDisplay, effects[effectFocus].fadeOutTime);
        //        windowDisplay = new Rect(offsetX, offsetY, 30f, DISPLAY_HEIGHT);
        //        EditorGUI.LabelField(windowDisplay, "secs");
        //        offsetY += DISPLAY_DIF;
        //        offsetX = 280f;
        //        //image scale
        //        windowDisplay = new Rect(offsetX, offsetY, 100f, DISPLAY_HEIGHT);
        //        offsetX += 130f;
        //        EditorGUI.LabelField(windowDisplay, "Image Scale");
        //        windowDisplay = new Rect(offsetX, offsetY, 50f, DISPLAY_HEIGHT);
        //        offsetY += DISPLAY_DIF;
        //        effects[effectFocus].imageScale = EditorGUI.FloatField(windowDisplay, effects[effectFocus].imageScale);
        //        offsetY = 120f;
        //        break;
        //    case EffectTypes.FADE:
        //        //time
        //        windowDisplay = new Rect(offsetX, offsetY, 130f, DISPLAY_HEIGHT);
        //        offsetX += 130f;
        //        EditorGUI.LabelField(windowDisplay, "Effect lasts for");
        //        windowDisplay = new Rect(offsetX, offsetY, 40f, DISPLAY_HEIGHT);
        //        offsetX += 40f;
        //        effects[effectFocus].effectTime = EditorGUI.FloatField(windowDisplay, effects[effectFocus].effectTime);
        //        windowDisplay = new Rect(offsetX, offsetY, 40f, DISPLAY_HEIGHT);
        //        offsetY += DISPLAY_DIF;
        //        offsetX = 280f;
        //        EditorGUI.LabelField(windowDisplay, "secs");
        //        //FadeIn/out
        //        windowDisplay = new Rect(offsetX, offsetY, 45f, DISPLAY_HEIGHT);
        //        offsetX += 45f;
        //        EditorGUI.LabelField(windowDisplay, "Fade in");
        //        windowDisplay = new Rect(offsetX, offsetY, 20f, DISPLAY_HEIGHT);
        //        offsetX += 20f;
        //        effects[effectFocus].fadeInTime = EditorGUI.FloatField(windowDisplay, effects[effectFocus].fadeInTime);
        //        windowDisplay = new Rect(offsetX, offsetY, 80f, DISPLAY_HEIGHT);
        //        offsetX += 80f;
        //        EditorGUI.LabelField(windowDisplay, "secs, and out");
        //        windowDisplay = new Rect(offsetX, offsetY, 20f, DISPLAY_HEIGHT);
        //        offsetX += 20f;
        //        effects[effectFocus].fadeOutTime = EditorGUI.FloatField(windowDisplay, effects[effectFocus].fadeOutTime);
        //        windowDisplay = new Rect(offsetX, offsetY, 30f, DISPLAY_HEIGHT);
        //        EditorGUI.LabelField(windowDisplay, "secs");
        //        offsetY = 120f;
        //        offsetX = 280f;
        //        break;
        //    case EffectTypes.SHAKE:
        //        //time
        //        windowDisplay = new Rect(offsetX, offsetY, 130f, DISPLAY_HEIGHT);
        //        offsetX += 130f;
        //        EditorGUI.LabelField(windowDisplay, "Effect lasts for");
        //        windowDisplay = new Rect(offsetX, offsetY, 40f, DISPLAY_HEIGHT);
        //        offsetX += 40f;
        //        effects[effectFocus].effectTime = EditorGUI.FloatField(windowDisplay, effects[effectFocus].effectTime);
        //        windowDisplay = new Rect(offsetX, offsetY, 40f, DISPLAY_HEIGHT);
        //        offsetY += DISPLAY_DIF;
        //        offsetX = 280f;
        //        EditorGUI.LabelField(windowDisplay, "secs");
        //        //magnitude
        //        windowDisplay = new Rect(offsetX, offsetY, 115f, DISPLAY_HEIGHT);
        //        offsetX += 115f;
        //        EditorGUI.LabelField(windowDisplay, "Magnitude of shake");
        //        windowDisplay = new Rect(offsetX, offsetY, 85f, DISPLAY_HEIGHT);
        //        offsetY = 120f;
        //        effects[effectFocus].magnitude = EditorGUI.FloatField(windowDisplay, effects[effectFocus].magnitude);
        //        //offsetX 
        //        break;
        //    case EffectTypes.WAIT:
        //        //time
        //        windowDisplay = new Rect(offsetX, offsetY, 130f, DISPLAY_HEIGHT);
        //        offsetX += 130f;
        //        EditorGUI.LabelField(windowDisplay, "Time until next effect");
        //        windowDisplay = new Rect(offsetX, offsetY, 40f, DISPLAY_HEIGHT);
        //        offsetX += 40f;
        //        effects[effectFocus].effectTime = EditorGUI.FloatField(windowDisplay, effects[effectFocus].effectTime);
        //        windowDisplay = new Rect(offsetX, offsetY, 40f, DISPLAY_HEIGHT);
        //        offsetY += DISPLAY_DIF;
        //        offsetX = 280f;
        //        EditorGUI.LabelField(windowDisplay, "secs");
        //        offsetY = 120f;
        //        break;
        //}
        ////Effects Buttons Display
        //offsetY += DISPLAY_DIF;
        //offsetX = 320f;
        //windowDisplay = new Rect(offsetX, offsetY, 40f, DISPLAY_HEIGHT);
        //offsetX += 40f;
        //if (GUI.Button(windowDisplay, "Prev", miniLeft))
        //{
        //    if (effectFocus > 0)
        //    {
        //        effectFocus--;
        //    }
        //}
        //windowDisplay = new Rect(offsetX, offsetY, 40f, DISPLAY_HEIGHT);
        //offsetX += 40f;
        //if (GUI.Button(windowDisplay, "Add", miniMid))
        //{
        //    effects.Insert(effectFocus + 1, new ScriptEffects());
        //    effectFocus++;
        //}
        //windowDisplay = new Rect(offsetX, offsetY, 40f, DISPLAY_HEIGHT);
        //offsetX -= 75f;
        //offsetY += 30f;
        //if (GUI.Button(windowDisplay, "Next", miniRight))
        //{
        //    if (effectFocus < effects.Count - 1)
        //    {
        //        effectFocus++;
        //    }
        //}
        //windowDisplay = new Rect(offsetX, offsetY, 110f, DISPLAY_HEIGHT);
        //offsetX += 205f;
        //offsetY = 10f;
        //GUI.color = Color.red;
        //if (GUI.Button(windowDisplay, "Delete Waypoint"))
        //{
        //    if (effectFocus == effects.Count - 1 && effects.Count > 1)
        //    {
        //        effects.RemoveAt(effectFocus);
        //        effectFocus--;
        //    }
        //    else if (effects.Count > 1)
        //    {
        //        effects.RemoveAt(effectFocus);
        //    }
        //    else
        //    {
        //        Debug.Log("Cannot remove last element from list");
        //    }
        //}
        //GUI.color = Color.white;

        ////Facings Display Block
        ////facings box
        ////top
        //Vector2 facingsPoint1 = new Vector2(412, 6);
        //Vector2 facingsPoint2 = new Vector2(634, 6);
        //Drawing.DrawLine(facingsPoint1, facingsPoint2, Color.black, 1f, true);
        ////left
        //Vector2 facingsPoint3 = new Vector2(524, 8);
        //Vector2 facingsPoint4 = new Vector2(524, 195);
        //Drawing.DrawLine(facingsPoint3, facingsPoint4, Color.black, 1f, true);
        ////bottom
        //Vector2 facingsPoint5 = new Vector2(412, 193);
        //Vector2 facingsPoint6 = new Vector2(634, 193);
        //Drawing.DrawLine(facingsPoint5, facingsPoint6, Color.black, 1f, true);
        ////right
        //Vector2 facingsPoint7 = new Vector2(744, 8);
        //Vector2 facingsPoint8 = new Vector2(744, 195);
        //Drawing.DrawLine(facingsPoint7, facingsPoint8, Color.black, 1f, true);


        ////facing info
        //offsetX = 525f;
        //offsetY = 10f;
        //windowDisplay = new Rect(offsetX, offsetY, ELEMENT_DISPLAY, DISPLAY_HEIGHT);
        //offsetX += 10f;
        //offsetY += DISPLAY_DIF;
        //EditorGUI.LabelField(windowDisplay, "Facing " + (facingFocus + 1));
        ////type
        //windowDisplay = new Rect(offsetX, offsetY, 100f, DISPLAY_HEIGHT);
        //offsetX += 100;
        //EditorGUI.LabelField(windowDisplay, "Facing Type");
        //windowDisplay = new Rect(offsetX, offsetY, 105f, DISPLAY_HEIGHT);
        //offsetX = 535;
        //offsetY += DISPLAY_DIF;
        //facings[facingFocus].facingType = (FacingTypes)EditorGUI.EnumPopup(windowDisplay, facings[facingFocus].facingType);
        ////switch on type
        //switch (facings[facingFocus].facingType)
        //{
        //    case FacingTypes.LOOKAT:
        //        //target
        //        if(facings[facingFocus].targets.Length != 1 || facings[facingFocus].targets == null)
        //        {
        //            facings[facingFocus].targets = new GameObject[1];
        //        }
        //        if(facings[facingFocus].lockTimes.Length != 1 || facings[facingFocus].lockTimes == null)
        //        {
        //            facings[facingFocus].lockTimes = new float[1];
        //        }
        //        if(facings[facingFocus].rotationSpeed.Length != 2 || facings[facingFocus].rotationSpeed == null)
        //        {
        //            facings[facingFocus].rotationSpeed = new float[2];
        //        }
        //        windowDisplay = new Rect(offsetX, offsetY, 100f, DISPLAY_HEIGHT);
        //        offsetX += 90f;
        //        EditorGUI.LabelField(windowDisplay, "Look At Target");
        //        windowDisplay = new Rect(offsetX, offsetY, 110f, DISPLAY_HEIGHT);
        //        offsetX = 535;
        //        offsetY += DISPLAY_DIF;
        //        facings[facingFocus].targets[0] = (GameObject)EditorGUI.ObjectField(windowDisplay, GUIContent.none, facings[facingFocus].targets[0], typeof(GameObject));
        //        //facing time
        //        windowDisplay = new Rect(offsetX, offsetY, 125f, DISPLAY_HEIGHT);
        //        offsetX += 125f;
        //        EditorGUI.LabelField(windowDisplay, "Rotate to target over");
        //        windowDisplay = new Rect(offsetX, offsetY, 30f, DISPLAY_HEIGHT);
        //        offsetX += 30f;
        //        facings[facingFocus].rotationSpeed[0] = EditorGUI.FloatField(windowDisplay, facings[facingFocus].rotationSpeed[0]);
        //        windowDisplay = new Rect(offsetX, offsetY, 30f, DISPLAY_HEIGHT);
        //        offsetX = 535;
        //        offsetY += DISPLAY_DIF;
        //        EditorGUI.LabelField(windowDisplay, "secs");
        //        //lock time
        //        windowDisplay = new Rect(offsetX, offsetY, 125f, DISPLAY_HEIGHT);
        //        offsetX += 110f;
        //        EditorGUI.LabelField(windowDisplay, "Lock to target for");
        //        windowDisplay = new Rect(offsetX, offsetY, 30f, DISPLAY_HEIGHT);
        //        offsetX += 30f;
        //        facings[facingFocus].lockTimes[0] = EditorGUI.FloatField(windowDisplay, facings[facingFocus].lockTimes[0]);
        //        windowDisplay = new Rect(offsetX, offsetY, 30f, DISPLAY_HEIGHT);
        //        offsetX = 535;
        //        offsetY += DISPLAY_DIF;
        //        EditorGUI.LabelField(windowDisplay, "secs");
        //        //return time
        //        windowDisplay = new Rect(offsetX, offsetY, 125f, DISPLAY_HEIGHT);
        //        offsetX += 125f;
        //        EditorGUI.LabelField(windowDisplay, "Rotate to origin over");
        //        windowDisplay = new Rect(offsetX, offsetY, 30f, DISPLAY_HEIGHT);
        //        offsetX += 30f;
        //        facings[facingFocus].rotationSpeed[1] = EditorGUI.FloatField(windowDisplay, facings[facingFocus].rotationSpeed[1]);
        //        windowDisplay = new Rect(offsetX, offsetY, 30f, DISPLAY_HEIGHT);
        //        offsetX = 535;
        //        offsetY += DISPLAY_DIF;
        //        EditorGUI.LabelField(windowDisplay, "secs");
        //        offsetY = 120f;
        //        break;
        //    case FacingTypes.LOOKCHAIN:
        //        //amount of targets
        //        windowDisplay = new Rect(offsetX, offsetY, 150f, DISPLAY_HEIGHT);
        //        offsetX += 150f;
        //        EditorGUI.LabelField(windowDisplay, "Amount of Targets");
        //        windowDisplay = new Rect(offsetX, offsetY, 50f, DISPLAY_HEIGHT);
        //        offsetX = 535f;
        //        offsetY += DISPLAY_DIF;
        //        facings[facingFocus].targetSize = EditorGUI.IntField(windowDisplay, facings[facingFocus].targetSize);
        //        if(facings[facingFocus].targets.Length != facings[facingFocus].targetSize)
        //        {
        //            facings[facingFocus].targets = new GameObject[facings[facingFocus].targetSize];
        //        }
        //        if(facings[facingFocus].lockTimes.Length != facings[facingFocus].targetSize)
        //        {
        //            facings[facingFocus].lockTimes = new float[facings[facingFocus].targetSize];
        //        }
        //        Debug.Log("target size " + facings[facingFocus].targetSize);
        //        Debug.Log("length before " + facings[facingFocus].rotationSpeed.Length);
        //        if(facings[facingFocus].rotationSpeed.Length != facings[facingFocus].targetSize + 1)
        //        {
        //            facings[facingFocus].rotationSpeed = new float[facings[facingFocus].targetSize + 1];
        //            Debug.Log("length after " + facings[facingFocus].rotationSpeed.Length);
        //        }
        //        //offsetX += 5f;
        //        //Vector2 lookChainPoint1 = new Vector2(437, 70);
        //        //Vector2 lookChainPoint2 = new Vector2(637, 70);
        //        //Drawing.DrawLine(lookChainPoint1, lookChainPoint2, Color.black, 1f, true);
        //        //lookChainPoint1 = new Vector2(537, 71);
        //        //lookChainPoint2 = new Vector2(537, 150);
        //        //Drawing.DrawLine(lookChainPoint1, lookChainPoint2, Color.black, 1f, true);
        //        //lookChainPoint1 = new Vector2(437, 147);
        //        //lookChainPoint2 = new Vector2(637, 147);
        //        //Drawing.DrawLine(lookChainPoint1, lookChainPoint2, Color.black, 1f, true);
        //        //lookChainPoint1 = new Vector2(737, 71);
        //        //lookChainPoint2 = new Vector2(737, 150);
        //        //Drawing.DrawLine(lookChainPoint1, lookChainPoint2, Color.black, 1f, true);
        //        //windowDisplay = new Rect(offsetX, offsetY, 100, DISPLAY_HEIGHT);
        //        //offsetX += 100f;
        //        //EditorGUI.LabelField(windowDisplay, "Look at Target");
        //        //windowDisplay = new Rect(offsetX, offsetY, 70, DISPLAY_HEIGHT);
        //        //offsetY += DISPLAY_DIF;
        //        //offsetX = 540f;

        //        windowDisplay = new Rect(offsetX, offsetY, ELEMENT_DISPLAY, DISPLAY_HEIGHT);
        //        if(GUI.Button(windowDisplay, "Edit Targets"))
        //        {
        //            LookChainWindowEditor.Init(facingFocus);
        //        }
        //        offsetY = 120f;
        //        break;
        //    case FacingTypes.FREELOOK:
        //        offsetY = 120f;
        //        break;
        //    case FacingTypes.WAIT:
        //        //time
        //        windowDisplay = new Rect(offsetX, offsetY, 130f, DISPLAY_HEIGHT);
        //        offsetX += 130f;
        //        EditorGUI.LabelField(windowDisplay, "Time until next facing");
        //        windowDisplay = new Rect(offsetX, offsetY, 40f, DISPLAY_HEIGHT);
        //        facings[facingFocus].facingTime = EditorGUI.FloatField(windowDisplay, facings[facingFocus].facingTime);
        //        offsetY = 120f;
        //        break;

        //}
        ////Facings Buttons Display
        //offsetY = 140;
        //offsetX = 570f;
        //windowDisplay = new Rect(offsetX, offsetY, 40f, DISPLAY_HEIGHT);
        //offsetX += 40f;
        //if (GUI.Button(windowDisplay, "Prev", miniLeft))
        //{
        //    if (facingFocus > 0)
        //    {
        //        facingFocus--;
        //    }
        //}
        //windowDisplay = new Rect(offsetX, offsetY, 40f, DISPLAY_HEIGHT);
        //offsetX += 40f;
        //if (GUI.Button(windowDisplay, "Add", miniMid))
        //{
        //    facings.Insert(facingFocus + 1, new ScriptFacings());
        //    facingFocus++;
        //}
        //windowDisplay = new Rect(offsetX, offsetY, 40f, DISPLAY_HEIGHT);
        //offsetX -= 75f;
        //offsetY += 30f;
        //if (GUI.Button(windowDisplay, "Next", miniRight))
        //{
        //    if (facingFocus < facings.Count - 1)
        //    {
        //        facingFocus++;
        //    }
        //}
        //windowDisplay = new Rect(offsetX, offsetY, 110f, DISPLAY_HEIGHT);
        //offsetX += 205f;
        //offsetY = 10f;
        //GUI.color = Color.red;
        //if (GUI.Button(windowDisplay, "Delete Waypoint"))
        //{
        //    if (facingFocus == facings.Count - 1 && facings.Count > 1)
        //    {
        //        facings.RemoveAt(facingFocus);
        //        facingFocus--;
        //    }
        //    else if (facings.Count > 1)
        //    {
        //        facings.RemoveAt(facingFocus);
        //    }
        //    else
        //    {
        //        Debug.Log("Cannot remove last element from list");
        //    }
        //}
        //GUI.color = Color.white;
        #endregion
    }

    void MovementGUI()
    {
        //Display block for movement
        //Movement Square
        //top
        Vector2 movementPoint1 = new Vector2(-110, 6);
        Vector2 movementPoint2 = new Vector2(117, 6);
        Drawing.DrawLine(movementPoint1, movementPoint2, Color.black, 1f, true);
        //right
        Vector2 movementPoint3 = new Vector2(229, 8);
        Vector2 movementPoint4 = new Vector2(229, 215);
        Drawing.DrawLine(movementPoint3, movementPoint4, Color.black, 1f, true);
        //bottom
        Vector2 movementPoint5 = new Vector2(-110, 213);
        Vector2 movementPoint6 = new Vector2(117, 213);
        Drawing.DrawLine(movementPoint5, movementPoint6, Color.black, 1f, true);
        //left
        Vector2 movementPoint7 = new Vector2(4, 8);
        Vector2 movementPoint8 = new Vector2(4, 215);
        Drawing.DrawLine(movementPoint7, movementPoint8, Color.black, 1f, true);

        //Movement element info
        windowDisplay = new Rect(offsetX, offsetY, ELEMENT_DISPLAY, DISPLAY_HEIGHT);
        offsetX += 10f;
        offsetY += DISPLAY_DIF;
        EditorGUI.LabelField(windowDisplay, "Movement " + (movementFocus + 1));

        //movement type
        windowDisplay = new Rect(offsetX, offsetY, 100f, DISPLAY_HEIGHT);
        offsetX += 100f;
        EditorGUI.LabelField(windowDisplay, "Movement Type");
        windowDisplay = new Rect(offsetX, offsetY, 110f, DISPLAY_HEIGHT);
        offsetY += DISPLAY_DIF;
        offsetX = 15f;
        movements[movementFocus].moveType = (MovementTypes)EditorGUI.EnumPopup(windowDisplay, movements[movementFocus].moveType);


        switch (movements[movementFocus].moveType)
        {
            case MovementTypes.BEZIER:
                //movement time
                windowDisplay = new Rect(offsetX, offsetY, 120f, DISPLAY_HEIGHT);
                offsetX += 120f;
                EditorGUI.LabelField(windowDisplay, "Move to target over");
                windowDisplay = new Rect(offsetX, offsetY, 50f, DISPLAY_HEIGHT);
                offsetX += 50f;
                movements[movementFocus].movementTime = EditorGUI.FloatField(windowDisplay, movements[movementFocus].movementTime);
                windowDisplay = new Rect(offsetX, offsetY, 45f, DISPLAY_HEIGHT);
                offsetY += DISPLAY_DIF;
                offsetX = 15f;
                EditorGUI.LabelField(windowDisplay, "secs");
                //display curve target
                offsetY += DISPLAY_DIF;
                windowDisplay = new Rect(offsetX, offsetY, 80f, DISPLAY_HEIGHT);
                offsetX += 80f;
                EditorGUI.LabelField(windowDisplay, "Curve Target");
                windowDisplay = new Rect(offsetX, offsetY, 135f, DISPLAY_HEIGHT);
                offsetY -= DISPLAY_DIF;
                offsetX = 15f;
                movements[movementFocus].curveWaypoint = (GameObject)EditorGUI.ObjectField(windowDisplay, GUIContent.none, movements[movementFocus].curveWaypoint, typeof(GameObject));
                //display end target
                windowDisplay = new Rect(offsetX, offsetY, 80f, DISPLAY_HEIGHT);
                offsetX += 80f;
                EditorGUI.LabelField(windowDisplay, "End Target");
                windowDisplay = new Rect(offsetX, offsetY, 135f, DISPLAY_HEIGHT);
                offsetY = 140f;
                offsetX = 15f;
                movements[movementFocus].endWaypoint = (GameObject)EditorGUI.ObjectField(windowDisplay, GUIContent.none, movements[movementFocus].endWaypoint, typeof(GameObject));
                break;
            case MovementTypes.STRAIGHT:
                //movement time
                windowDisplay = new Rect(offsetX, offsetY, 120f, DISPLAY_HEIGHT);
                offsetX += 120f;
                EditorGUI.LabelField(windowDisplay, "Move to target over");
                windowDisplay = new Rect(offsetX, offsetY, 50f, DISPLAY_HEIGHT);
                offsetX += 50f;
                movements[movementFocus].movementTime = EditorGUI.FloatField(windowDisplay, movements[movementFocus].movementTime);
                windowDisplay = new Rect(offsetX, offsetY, 45f, DISPLAY_HEIGHT);
                offsetY += DISPLAY_DIF;
                offsetX = 15f;
                EditorGUI.LabelField(windowDisplay, "secs");
                //display end target
                windowDisplay = new Rect(offsetX, offsetY, 80f, DISPLAY_HEIGHT);
                offsetX += 80f;
                EditorGUI.LabelField(windowDisplay, "End Target");
                windowDisplay = new Rect(offsetX, offsetY, 130f, DISPLAY_HEIGHT);
                offsetY = 140f;
                offsetX = 15f;
                movements[movementFocus].endWaypoint = (GameObject)EditorGUI.ObjectField(windowDisplay, GUIContent.none, movements[movementFocus].endWaypoint, typeof(GameObject));
                break;
            case MovementTypes.WAIT:
                //movement time
                windowDisplay = new Rect(offsetX, offsetY, 120f, DISPLAY_HEIGHT);
                offsetX += 120f;
                EditorGUI.LabelField(windowDisplay, "Wait at location for");
                windowDisplay = new Rect(offsetX, offsetY, 50f, DISPLAY_HEIGHT);
                offsetX += 50f;
                movements[movementFocus].movementTime = EditorGUI.FloatField(windowDisplay, movements[movementFocus].movementTime);
                windowDisplay = new Rect(offsetX, offsetY, 45f, DISPLAY_HEIGHT);
                offsetY += DISPLAY_DIF;
                offsetX = 15f;
                EditorGUI.LabelField(windowDisplay, "secs");
                offsetY = 140f;
                offsetX = 15f;
                break;
        }
        //Movement Buttons Display
        offsetY += DISPLAY_DIF;
        offsetX += 40f;
        windowDisplay = new Rect(offsetX, offsetY, 40f, DISPLAY_HEIGHT);
        offsetX += 40f;


        if (GUI.Button(windowDisplay, "Prev", miniLeft))
        {
            if (movementFocus > 0)
            {
                movementFocus--;
            }
        }
        windowDisplay = new Rect(offsetX, offsetY, 40f, DISPLAY_HEIGHT);
        offsetX += 40f;
        if (GUI.Button(windowDisplay, "Add", miniMid))
        {
            movements.Insert(movementFocus + 1, new ScriptMovements());
            movementFocus++;
        }
        windowDisplay = new Rect(offsetX, offsetY, 40f, DISPLAY_HEIGHT);
        offsetX -= 75f;
        offsetY += 30f;
        if (GUI.Button(windowDisplay, "Next", miniRight))
        {
            if (movementFocus < movements.Count - 1)
            {
                movementFocus++;
            }
        }
        windowDisplay = new Rect(offsetX, offsetY, 110f, DISPLAY_HEIGHT);
        offsetX += 210f;
        offsetY = 10f;
        GUI.color = Color.red;
        if (GUI.Button(windowDisplay, "Delete Waypoint"))
        {
            if (movementFocus == movements.Count - 1 && effects.Count > 1)
            {
                movements.RemoveAt(movementFocus);
                movementFocus--;
            }
            else if (movements.Count > 1)
            {
                movements.RemoveAt(movementFocus);
            }
            else
            {
                Debug.Log("Cannot remove last element from list");
            }
        }
        GUI.color = Color.white;

    }

    void EffectGUI()
    {
        //Effect Display Block
        //Effects Square
        //Top
        Vector2 effectsPoint1 = new Vector2(154f, 6f);
        Vector2 effectsPoint2 = new Vector2(380f, 6f);
        Drawing.DrawLine(effectsPoint1, effectsPoint2, Color.black, 1f, true);
        //left
        Vector2 effectsPoint3 = new Vector2(268, 8);
        Vector2 effectsPoint4 = new Vector2(268, 215);
        Drawing.DrawLine(effectsPoint3, effectsPoint4, Color.black, 1f, true);
        //bottom
        Vector2 effectsPoint5 = new Vector2(154, 213);
        Vector2 effectsPoint6 = new Vector2(380, 213);
        Drawing.DrawLine(effectsPoint5, effectsPoint6, Color.black, 1f, true);
        //Right
        Vector2 effectsPoint7 = new Vector2(491, 8);
        Vector2 effectsPoint8 = new Vector2(491, 215);
        Drawing.DrawLine(effectsPoint7, effectsPoint8, Color.black, 1f, true);
        offsetX = 270f;
        offsetY = 10f;
        //Effects Info
        windowDisplay = new Rect(offsetX, offsetY, ELEMENT_DISPLAY, DISPLAY_HEIGHT);
        offsetY += DISPLAY_DIF;
        offsetX = 280f;
        EditorGUI.LabelField(windowDisplay, "Effect " + (effectFocus + 1));
        //type
        windowDisplay = new Rect(offsetX, offsetY, 100f, DISPLAY_HEIGHT);
        offsetX += 100f;
        EditorGUI.LabelField(windowDisplay, "Effect Type");
        windowDisplay = new Rect(offsetX, offsetY, 105f, DISPLAY_HEIGHT);
        offsetY += DISPLAY_DIF;
        offsetX = 280f;
        effects[effectFocus].effectType = (EffectTypes)EditorGUI.EnumPopup(windowDisplay, effects[effectFocus].effectType);

        //switch on type
        switch (effects[effectFocus].effectType)
        {
            case EffectTypes.SPLATTER:
                //time
                windowDisplay = new Rect(offsetX, offsetY, 130f, DISPLAY_HEIGHT);
                offsetX += 130f;
                EditorGUI.LabelField(windowDisplay, "Effect lasts for");
                windowDisplay = new Rect(offsetX, offsetY, 40f, DISPLAY_HEIGHT);
                offsetX += 40f;
                effects[effectFocus].effectTime = EditorGUI.FloatField(windowDisplay, effects[effectFocus].effectTime);
                windowDisplay = new Rect(offsetX, offsetY, 40f, DISPLAY_HEIGHT);
                offsetY += DISPLAY_DIF;
                offsetX = 280f;
                EditorGUI.LabelField(windowDisplay, "secs");
                //FadeIn/out
                windowDisplay = new Rect(offsetX, offsetY, 45f, DISPLAY_HEIGHT);
                offsetX += 45f;
                EditorGUI.LabelField(windowDisplay, "Fade in");
                windowDisplay = new Rect(offsetX, offsetY, 20f, DISPLAY_HEIGHT);
                offsetX += 20f;
                effects[effectFocus].fadeInTime = EditorGUI.FloatField(windowDisplay, effects[effectFocus].fadeInTime);
                windowDisplay = new Rect(offsetX, offsetY, 80f, DISPLAY_HEIGHT);
                offsetX += 80f;
                EditorGUI.LabelField(windowDisplay, "secs, and out");
                windowDisplay = new Rect(offsetX, offsetY, 20f, DISPLAY_HEIGHT);
                offsetX += 20f;
                effects[effectFocus].fadeOutTime = EditorGUI.FloatField(windowDisplay, effects[effectFocus].fadeOutTime);
                windowDisplay = new Rect(offsetX, offsetY, 30f, DISPLAY_HEIGHT);
                EditorGUI.LabelField(windowDisplay, "secs");
                offsetY += DISPLAY_DIF;
                offsetX = 280f;
                //image scale
                windowDisplay = new Rect(offsetX, offsetY, 100f, DISPLAY_HEIGHT);
                offsetX += 130f;
                EditorGUI.LabelField(windowDisplay, "Image Scale");
                windowDisplay = new Rect(offsetX, offsetY, 50f, DISPLAY_HEIGHT);
                offsetY += DISPLAY_DIF;
                effects[effectFocus].imageScale = EditorGUI.FloatField(windowDisplay, effects[effectFocus].imageScale);
                offsetY = 140f;
                break;
            case EffectTypes.FADE:
                //time
                windowDisplay = new Rect(offsetX, offsetY, 130f, DISPLAY_HEIGHT);
                offsetX += 130f;
                EditorGUI.LabelField(windowDisplay, "Effect lasts for");
                windowDisplay = new Rect(offsetX, offsetY, 40f, DISPLAY_HEIGHT);
                offsetX += 40f;
                effects[effectFocus].effectTime = EditorGUI.FloatField(windowDisplay, effects[effectFocus].effectTime);
                windowDisplay = new Rect(offsetX, offsetY, 40f, DISPLAY_HEIGHT);
                offsetY += DISPLAY_DIF;
                offsetX = 280f;
                EditorGUI.LabelField(windowDisplay, "secs");
                //FadeIn/out
                windowDisplay = new Rect(offsetX, offsetY, 45f, DISPLAY_HEIGHT);
                offsetX += 45f;
                EditorGUI.LabelField(windowDisplay, "Fade in");
                windowDisplay = new Rect(offsetX, offsetY, 20f, DISPLAY_HEIGHT);
                offsetX += 20f;
                effects[effectFocus].fadeInTime = EditorGUI.FloatField(windowDisplay, effects[effectFocus].fadeInTime);
                windowDisplay = new Rect(offsetX, offsetY, 80f, DISPLAY_HEIGHT);
                offsetX += 80f;
                EditorGUI.LabelField(windowDisplay, "secs, and out");
                windowDisplay = new Rect(offsetX, offsetY, 20f, DISPLAY_HEIGHT);
                offsetX += 20f;
                effects[effectFocus].fadeOutTime = EditorGUI.FloatField(windowDisplay, effects[effectFocus].fadeOutTime);
                windowDisplay = new Rect(offsetX, offsetY, 30f, DISPLAY_HEIGHT);
                EditorGUI.LabelField(windowDisplay, "secs");
                offsetY = 140f;
                offsetX = 280f;
                break;
            case EffectTypes.SHAKE:
                //time
                windowDisplay = new Rect(offsetX, offsetY, 130f, DISPLAY_HEIGHT);
                offsetX += 130f;
                EditorGUI.LabelField(windowDisplay, "Effect lasts for");
                windowDisplay = new Rect(offsetX, offsetY, 40f, DISPLAY_HEIGHT);
                offsetX += 40f;
                effects[effectFocus].effectTime = EditorGUI.FloatField(windowDisplay, effects[effectFocus].effectTime);
                windowDisplay = new Rect(offsetX, offsetY, 40f, DISPLAY_HEIGHT);
                offsetY += DISPLAY_DIF;
                offsetX = 280f;
                EditorGUI.LabelField(windowDisplay, "secs");
                //magnitude
                windowDisplay = new Rect(offsetX, offsetY, 115f, DISPLAY_HEIGHT);
                offsetX += 115f;
                EditorGUI.LabelField(windowDisplay, "Magnitude of shake");
                windowDisplay = new Rect(offsetX, offsetY, 85f, DISPLAY_HEIGHT);
                offsetY = 140f;
                effects[effectFocus].magnitude = EditorGUI.FloatField(windowDisplay, effects[effectFocus].magnitude);
                //offsetX 
                break;
            case EffectTypes.WAIT:
                //time
                windowDisplay = new Rect(offsetX, offsetY, 130f, DISPLAY_HEIGHT);
                offsetX += 130f;
                EditorGUI.LabelField(windowDisplay, "Time until next effect");
                windowDisplay = new Rect(offsetX, offsetY, 40f, DISPLAY_HEIGHT);
                offsetX += 40f;
                effects[effectFocus].effectTime = EditorGUI.FloatField(windowDisplay, effects[effectFocus].effectTime);
                windowDisplay = new Rect(offsetX, offsetY, 40f, DISPLAY_HEIGHT);
                offsetY += DISPLAY_DIF;
                offsetX = 280f;
                EditorGUI.LabelField(windowDisplay, "secs");
                offsetY = 140f;
                break;
        }
        //Effects Buttons Display
        offsetY += DISPLAY_DIF;
        offsetX = 320f;
        windowDisplay = new Rect(offsetX, offsetY, 40f, DISPLAY_HEIGHT);
        offsetX += 40f;
        if (GUI.Button(windowDisplay, "Prev", miniLeft))
        {
            if (effectFocus > 0)
            {
                effectFocus--;
            }
        }
        windowDisplay = new Rect(offsetX, offsetY, 40f, DISPLAY_HEIGHT);
        offsetX += 40f;
        if (GUI.Button(windowDisplay, "Add", miniMid))
        {
            effects.Insert(effectFocus + 1, new ScriptEffects());
            effectFocus++;
        }
        windowDisplay = new Rect(offsetX, offsetY, 40f, DISPLAY_HEIGHT);
        offsetX -= 75f;
        offsetY += 30f;
        if (GUI.Button(windowDisplay, "Next", miniRight))
        {
            if (effectFocus < effects.Count - 1)
            {
                effectFocus++;
            }
        }
        windowDisplay = new Rect(offsetX, offsetY, 110f, DISPLAY_HEIGHT);
        offsetX += 205f;
        offsetY = 10f;
        GUI.color = Color.red;
        if (GUI.Button(windowDisplay, "Delete Waypoint"))
        {
            if (effectFocus == effects.Count - 1 && effects.Count > 1)
            {
                effects.RemoveAt(effectFocus);
                effectFocus--;
            }
            else if (effects.Count > 1)
            {
                effects.RemoveAt(effectFocus);
            }
            else
            {
                Debug.Log("Cannot remove last element from list");
            }
        }
        GUI.color = Color.white;
    }

    void FacingGUI()
    {
        //Facings Display Block
        //facings box
        //top
        Vector2 facingsPoint1 = new Vector2(412, 6);
        Vector2 facingsPoint2 = new Vector2(634, 6);
        Drawing.DrawLine(facingsPoint1, facingsPoint2, Color.black, 1f, true);
        //left
        Vector2 facingsPoint3 = new Vector2(524, 8);
        Vector2 facingsPoint4 = new Vector2(524, 215);
        Drawing.DrawLine(facingsPoint3, facingsPoint4, Color.black, 1f, true);
        //bottom
        Vector2 facingsPoint5 = new Vector2(412, 213);
        Vector2 facingsPoint6 = new Vector2(634, 213);
        Drawing.DrawLine(facingsPoint5, facingsPoint6, Color.black, 1f, true);
        //right
        Vector2 facingsPoint7 = new Vector2(744, 8);
        Vector2 facingsPoint8 = new Vector2(744, 215);
        Drawing.DrawLine(facingsPoint7, facingsPoint8, Color.black, 1f, true);


        //facing info
        offsetX = 525f;
        offsetY = 10f;
        windowDisplay = new Rect(offsetX, offsetY, ELEMENT_DISPLAY, DISPLAY_HEIGHT);
        offsetX += 10f;
        offsetY += DISPLAY_DIF;
        EditorGUI.LabelField(windowDisplay, "Facing " + (facingFocus + 1));
        //type
        windowDisplay = new Rect(offsetX, offsetY, 100f, DISPLAY_HEIGHT);
        offsetX += 100;
        EditorGUI.LabelField(windowDisplay, "Facing Type");
        windowDisplay = new Rect(offsetX, offsetY, 105f, DISPLAY_HEIGHT);
        offsetX = 535;
        offsetY += DISPLAY_DIF;
        facings[facingFocus].facingType = (FacingTypes)EditorGUI.EnumPopup(windowDisplay, facings[facingFocus].facingType);
        //switch on type
        switch (facings[facingFocus].facingType)
        {
            case FacingTypes.LOOKAT:
                //target
                if (facings[facingFocus].targets.Length != 1 || facings[facingFocus].targets == null)
                {
                    facings[facingFocus].targets = new GameObject[1];
                }
                if (facings[facingFocus].lockTimes.Length != 1 || facings[facingFocus].lockTimes == null)
                {
                    facings[facingFocus].lockTimes = new float[1];
                }
                if (facings[facingFocus].rotationSpeed.Length != 2 || facings[facingFocus].rotationSpeed == null)
                {
                    facings[facingFocus].rotationSpeed = new float[2];
                }
                windowDisplay = new Rect(offsetX, offsetY, 100f, DISPLAY_HEIGHT);
                offsetX += 90f;
                EditorGUI.LabelField(windowDisplay, "Look At Target");
                windowDisplay = new Rect(offsetX, offsetY, 110f, DISPLAY_HEIGHT);
                offsetX = 535;
                offsetY += DISPLAY_DIF;
                facings[facingFocus].targets[0] = (GameObject)EditorGUI.ObjectField(windowDisplay, GUIContent.none, facings[facingFocus].targets[0], typeof(GameObject), true);
                //facing time
                windowDisplay = new Rect(offsetX, offsetY, 125f, DISPLAY_HEIGHT);
                offsetX += 125f;
                EditorGUI.LabelField(windowDisplay, "Rotate to target over");
                windowDisplay = new Rect(offsetX, offsetY, 30f, DISPLAY_HEIGHT);
                offsetX += 30f;
                facings[facingFocus].rotationSpeed[0] = EditorGUI.FloatField(windowDisplay, facings[facingFocus].rotationSpeed[0]);
                windowDisplay = new Rect(offsetX, offsetY, 30f, DISPLAY_HEIGHT);
                offsetX = 535;
                offsetY += DISPLAY_DIF;
                EditorGUI.LabelField(windowDisplay, "secs");
                //lock time
                windowDisplay = new Rect(offsetX, offsetY, 125f, DISPLAY_HEIGHT);
                offsetX += 110f;
                EditorGUI.LabelField(windowDisplay, "Lock to target for");
                windowDisplay = new Rect(offsetX, offsetY, 30f, DISPLAY_HEIGHT);
                offsetX += 30f;
                facings[facingFocus].lockTimes[0] = EditorGUI.FloatField(windowDisplay, facings[facingFocus].lockTimes[0]);
                windowDisplay = new Rect(offsetX, offsetY, 30f, DISPLAY_HEIGHT);
                offsetX = 535;
                offsetY += DISPLAY_DIF;
                EditorGUI.LabelField(windowDisplay, "secs");
                //return time
                windowDisplay = new Rect(offsetX, offsetY, 125f, DISPLAY_HEIGHT);
                offsetX += 125f;
                EditorGUI.LabelField(windowDisplay, "Rotate to origin over");
                windowDisplay = new Rect(offsetX, offsetY, 30f, DISPLAY_HEIGHT);
                offsetX += 30f;
                facings[facingFocus].rotationSpeed[1] = EditorGUI.FloatField(windowDisplay, facings[facingFocus].rotationSpeed[1]);
                windowDisplay = new Rect(offsetX, offsetY, 30f, DISPLAY_HEIGHT);
                offsetX = 535;
                offsetY += DISPLAY_DIF;
                EditorGUI.LabelField(windowDisplay, "secs");
                windowDisplay = new Rect(offsetX, offsetY, 150f, DISPLAY_HEIGHT);
                offsetX += 150f;
                EditorGUI.LabelField(windowDisplay, "Rotate Camera Only");
                windowDisplay = new Rect(offsetX, offsetY, 25f, DISPLAY_HEIGHT);
                offsetX = 535;
                facings[facingFocus].cameraMoveOnly = EditorGUI.Toggle(windowDisplay, facings[facingFocus].cameraMoveOnly);
                offsetY = 140f;
                break;
            case FacingTypes.LOOKCHAIN:
                //amount of targets
                windowDisplay = new Rect(offsetX, offsetY, 150f, DISPLAY_HEIGHT);
                offsetX += 150f;
                EditorGUI.LabelField(windowDisplay, "Amount of Targets");
                windowDisplay = new Rect(offsetX, offsetY, 50f, DISPLAY_HEIGHT);
                offsetX = 535f;
                offsetY += DISPLAY_DIF;
                facings[facingFocus].targetSize = EditorGUI.IntField(windowDisplay, facings[facingFocus].targetSize);
                windowDisplay = new Rect(offsetX, offsetY, 150f, DISPLAY_HEIGHT);
                offsetX += 150f;
                EditorGUI.LabelField(windowDisplay, "Rotate Camera Only");
                windowDisplay = new Rect(offsetX, offsetY, 25f, DISPLAY_HEIGHT);
                offsetX = 535f;
                offsetY += DISPLAY_DIF;
                facings[facingFocus].cameraMoveOnly = EditorGUI.Toggle(windowDisplay, facings[facingFocus].cameraMoveOnly);
                if (facings[facingFocus].targets.Length != facings[facingFocus].targetSize)
                {
                    facings[facingFocus].targets = new GameObject[facings[facingFocus].targetSize];
                }
                if (facings[facingFocus].lockTimes.Length != facings[facingFocus].targetSize)
                {
                    facings[facingFocus].lockTimes = new float[facings[facingFocus].targetSize];
                }
                Debug.Log("target size " + facings[facingFocus].targetSize);
                Debug.Log("length before " + facings[facingFocus].rotationSpeed.Length);
                if (facings[facingFocus].rotationSpeed.Length != facings[facingFocus].targetSize + 1)
                {
                    facings[facingFocus].rotationSpeed = new float[facings[facingFocus].targetSize + 1];
                    Debug.Log("length after " + facings[facingFocus].rotationSpeed.Length);
                }
                //offsetX += 5f;
                //Vector2 lookChainPoint1 = new Vector2(437, 70);
                //Vector2 lookChainPoint2 = new Vector2(637, 70);
                //Drawing.DrawLine(lookChainPoint1, lookChainPoint2, Color.black, 1f, true);
                //lookChainPoint1 = new Vector2(537, 71);
                //lookChainPoint2 = new Vector2(537, 150);
                //Drawing.DrawLine(lookChainPoint1, lookChainPoint2, Color.black, 1f, true);
                //lookChainPoint1 = new Vector2(437, 147);
                //lookChainPoint2 = new Vector2(637, 147);
                //Drawing.DrawLine(lookChainPoint1, lookChainPoint2, Color.black, 1f, true);
                //lookChainPoint1 = new Vector2(737, 71);
                //lookChainPoint2 = new Vector2(737, 150);
                //Drawing.DrawLine(lookChainPoint1, lookChainPoint2, Color.black, 1f, true);
                //windowDisplay = new Rect(offsetX, offsetY, 100, DISPLAY_HEIGHT);
                //offsetX += 100f;
                //EditorGUI.LabelField(windowDisplay, "Look at Target");
                //windowDisplay = new Rect(offsetX, offsetY, 70, DISPLAY_HEIGHT);
                //offsetY += DISPLAY_DIF;
                //offsetX = 540f;

                windowDisplay = new Rect(offsetX, offsetY, ELEMENT_DISPLAY, DISPLAY_HEIGHT);
                if (GUI.Button(windowDisplay, "Edit Targets"))
                {
                    LookChainWindowEditor.Init(facingFocus);
                }
                offsetY = 140f;
                break;
            case FacingTypes.FREELOOK:
                windowDisplay = new Rect(offsetX, offsetY, 130f, DISPLAY_HEIGHT);
                offsetX += 130f;
                EditorGUI.LabelField(windowDisplay, "Time for freelook");
                windowDisplay = new Rect(offsetX, offsetY, 40f, DISPLAY_HEIGHT);
                offsetX += 40f;
                facings[facingFocus].facingTime = EditorGUI.FloatField(windowDisplay, facings[facingFocus].facingTime);
                windowDisplay = new Rect(offsetX, offsetY, 40f, DISPLAY_HEIGHT);
                EditorGUI.LabelField(windowDisplay, "secs");
                offsetY = 140f;
                break;
            case FacingTypes.WAIT:
                //time
                windowDisplay = new Rect(offsetX, offsetY, 130f, DISPLAY_HEIGHT);
                offsetX += 130f;
                EditorGUI.LabelField(windowDisplay, "Time until next facing");
                windowDisplay = new Rect(offsetX, offsetY, 40f, DISPLAY_HEIGHT);
                facings[facingFocus].facingTime = EditorGUI.FloatField(windowDisplay, facings[facingFocus].facingTime);
                offsetY = 140f;
                break;

        }
        //Facings Buttons Display
        offsetY = 160;
        offsetX = 570f;
        windowDisplay = new Rect(offsetX, offsetY, 40f, DISPLAY_HEIGHT);
        offsetX += 40f;
        if (GUI.Button(windowDisplay, "Prev", miniLeft))
        {
            if (facingFocus > 0)
            {
                facingFocus--;
            }
        }
        windowDisplay = new Rect(offsetX, offsetY, 40f, DISPLAY_HEIGHT);
        offsetX += 40f;
        if (GUI.Button(windowDisplay, "Add", miniMid))
        {
            facings.Insert(facingFocus + 1, new ScriptFacings());
            facingFocus++;
        }
        windowDisplay = new Rect(offsetX, offsetY, 40f, DISPLAY_HEIGHT);
        offsetX -= 75f;
        offsetY += 30f;
        if (GUI.Button(windowDisplay, "Next", miniRight))
        {
            if (facingFocus < facings.Count - 1)
            {
                facingFocus++;
            }
        }
        windowDisplay = new Rect(offsetX, offsetY, 110f, DISPLAY_HEIGHT);
        offsetX += 205f;
        offsetY = 10f;
        GUI.color = Color.red;
        if (GUI.Button(windowDisplay, "Delete Waypoint"))
        {
            if (facingFocus == facings.Count - 1 && facings.Count > 1)
            {
                facings.RemoveAt(facingFocus);
                facingFocus--;
            }
            else if (facings.Count > 1)
            {
                facings.RemoveAt(facingFocus);
            }
            else
            {
                Debug.Log("Cannot remove last element from list");
            }
        }
        GUI.color = Color.white;
    }

    void OnLostFocus()
    {
        RecordData();
    }

    void RecordData()
    {
        railEngine.movements = movements;
        railEngine.effects = effects;
        railEngine.facings = facings;
//		Debug.Log ("~~~LOST FOCUS MOVEMENT COUNT~~~\n" +
//			"\tENGINE: " + railEngine.movements.Count +
//		           "\t\tWINDOW: " + movements.Count);
    }

}
