using UnityEngine;
using System.Collections;

/// <summary>
/// @Author Marshall Mason
/// </summary>
[System.Serializable]
public class ScriptWaypoints
{
    public WaypointType waypointType;

    
    public FacingTypes facingType;
    public GameObject[] targets;
    public float[] facingTimes;
    public float[] holdTimes;
    
    public EffectTypes effectType;
    public float fadeInTime;
    public float fadeOutTime;
    public float effectDuration;

    public virtual void GetWaypointInfo()
    {
        Debug.Log("Something is wrong here. Check overrides for GetWaypointInfo()");
    }
}
