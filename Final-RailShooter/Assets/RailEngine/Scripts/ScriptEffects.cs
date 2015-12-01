using UnityEngine;
using System.Collections;

/*
*   @author Mike Dobson
* */

[System.Serializable]
public class ScriptEffects
{
    public EffectTypes effectType;

    //common variables
    public float effectTime;

    //variables for fade & splatter
    public float fadeInTime;
    public float fadeOutTime;

    //variables for splatter   
    public float imageScale;

    //variables for camera shake
    public float magnitude;

    public bool showInEditor = false;
}
