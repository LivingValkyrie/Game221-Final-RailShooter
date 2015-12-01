using UnityEngine;
using System.Collections;
using UnityEditor;

/// <summary>
/// Author: Matt Gipson
/// Contact: Deadwynn@gmail.com
/// Domain: www.livingvalkyrie.com
/// 
/// Description: ExportWindow 
/// </summary>
public class ExportWindow : EditorWindow {
    #region Fields

    string name, author;
    #endregion

    void OnGUI() {
        EditorGUILayout.LabelField("Level Information");
        EditorGUILayout.LabelField("Level Name");
        name = EditorGUILayout.TextField(name);
        EditorGUILayout.LabelField( "Author Name" );
        author = EditorGUILayout.TextField(author);
        if (GUILayout.Button("Export")) {
            ExportWaypoints.Export(author, name);
        }
    }

}