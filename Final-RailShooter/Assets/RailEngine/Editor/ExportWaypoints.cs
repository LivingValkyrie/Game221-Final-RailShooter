using System;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEditor;

/// <summary>
/// Author: Matt Gipson
/// Contact: Deadwynn@gmail.com
/// Domain: www.livingvalkyrie.com
/// 
/// Description: ExportWaypoints 
/// </summary>
public class ExportWaypoints {
    #region Fields

    #endregion

    [MenuItem("Waypoint Engine/Export/From selected object")]
    public static void OpenWindow() {
        ExportWindow window = (ExportWindow)EditorWindow.GetWindow( typeof( ExportWindow ) );
        window.Show();
    }

    public static void Export(string author, string level) {
        //Debug.Log("export clicked");
        //Debug.Log("selected object: " + Selection.activeObject);

        if (Selection.activeObject is GameObject) {
            //Debug.Log("is game object");
            GameObject go = (GameObject) Selection.activeObject;
            if (go.GetComponent<ScriptEngine>() != null) {
                //Debug.Log("has engine component");
                
                ExportLists(go, author, level, Application.dataPath);
            } else {
                EditorUtility.DisplayDialog("Warning!", "This game object does not have an engine component!", "understood");
            }
        } else {
            EditorUtility.DisplayDialog("Warning!", "The selected object is not a game object!", "understood");
        }
    }

    static void ExportLists(GameObject go, string author, string level, string path ) {
        //get script
        ScriptEngine engine = go.GetComponent<ScriptEngine>();

        List<string> waypoints = new List<string>();

        foreach (ScriptMovements node in engine.movements) {
            string nodeString = "M_";

            //type
            switch (node.moveType) {
                case MovementTypes.STRAIGHT:

                    //MOVE takes a time and a destination separated by a space.
                    nodeString += string.Format("MOVE {0} {1},{2},{3}",
                                                node.movementTime,
                                                node.endWaypoint.transform.position.x,
                                                node.endWaypoint.transform.position.y,
                                                node.endWaypoint.transform.position.z);

                    break;
                case MovementTypes.BEZIER:

                    //BEZIER takes a time, a destination, and a curve control point.
                    nodeString += string.Format("BEZIER {0} {1},{2},{3} {4},{5},{6}",
                                                node.movementTime,
                                                node.endWaypoint.transform.position.x,
                                                node.endWaypoint.transform.position.y,
                                                node.endWaypoint.transform.position.z,
                                                node.curveWaypoint.transform.position.x,
                                                node.curveWaypoint.transform.position.y,
                                                node.curveWaypoint.transform.position.z);

                    break;
                case MovementTypes.WAIT:

                    //WAIT takes just a time.
                    nodeString += string.Format("WAIT {0}", node.movementTime);

                    break;
            }

            waypoints.Add(nodeString);
        }

        foreach (ScriptFacings node in engine.facings) {
            string nodeString = "F_";

            //Facings are FREELOOK, WAIT, LOOKAT, and LOOKCHAIN
            switch (node.facingType) {
                case FacingTypes.FREELOOK:

                    //FREELOOK takes a time.
                    nodeString += string.Format("WAIT {0}", node.facingTime);
                    break;
                case FacingTypes.LOOKAT:

                    //LOOKAT takes a look to time, a lock time, a look target, and a return time.
                    Debug.Log("");

                    nodeString += string.Format("LOOKAT {6} {0} {1} {2},{3},{4} {5}",
                                                node.rotationSpeed[0],
                                                node.lockTimes[0],
                                                node.targets[0].transform.position.x,
                                                node.targets[0].transform.position.y,
                                                node.targets[0].transform.position.z,
                                                node.rotationSpeed[1],
                                                node.cameraMoveOnly);

                    break;
                case FacingTypes.LOOKCHAIN:

                    //LOOKCHAIN takes two times per target, an unlimited number of targets, and a return time at the end.
                    nodeString += string.Format("LOOKCHAIN {0} {1}",node.cameraMoveOnly, node.rotationSpeed[0] );

                    int currTarget = 0;

                    foreach (GameObject target in node.targets) {
                        nodeString += string.Format(" {0} {1},{2},{3} {4}",
                                                    node.lockTimes[currTarget],
                                                    node.targets[currTarget].transform.position.x,
                                                    node.targets[currTarget].transform.position.y,
                                                    node.targets[currTarget].transform.position.z,
                                                    node.rotationSpeed[++currTarget]);
                    }

                    break;
                case FacingTypes.WAIT:

                    //WAIT takes just a time.
                    nodeString += string.Format("WAIT {0}", node.facingTime);
                    break;
            }

            waypoints.Add(nodeString);
        }

        foreach (ScriptEffects node in engine.effects) {
            string nodeString = "E_";

            //Effects are SHAKE, SPLATTER, WAIT, and FADE
            switch (node.effectType) {
                case EffectTypes.FADE:

                    //FADE takes a stay-blacked out time, a fade-to-black time, and a fade-back time
                    nodeString += string.Format("FADE {0} {1} {2}", node.effectTime, node.fadeOutTime, node.fadeInTime);
                    break;
                case EffectTypes.SHAKE:

                    //SHAKE takes an effect time and a magnitude.
                    nodeString += string.Format("SHAKE {0} {1}", node.effectTime, node.magnitude);
                    break;
                case EffectTypes.SPLATTER:

                    //SPLATTER takes a stay time, a fade-in time, a fade-out time, and an image scale
                    nodeString += string.Format("SPLATTER {0} {1} {2} {3}",
                                                node.effectTime,
                                                node.fadeInTime,
                                                node.fadeOutTime,
                                                node.imageScale);

                    break;
                case EffectTypes.WAIT:

                    //WAIT takes just a time.
                    nodeString += string.Format("WAIT {0}", node.effectTime);
                    break;
            }

            waypoints.Add(nodeString);
        }

        using (StreamWriter sw = new StreamWriter(path + "/"+ level + ".txt")) {
            sw.WriteLine(level);
            sw.WriteLine(DateTime.Now);
            sw.WriteLine(author);
            foreach (string s in waypoints) {
                sw.WriteLine(s);
            }
            
        }

        AssetDatabase.Refresh();
        EditorUtility.DisplayDialog("Success", "file build successful", "ok");
    }

}