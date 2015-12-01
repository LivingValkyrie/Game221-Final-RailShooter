using UnityEngine;
using System.Collections;

/// <summary>
/// @Author Marshall Mason
/// </summary>
public enum WaypointType
{
    Movement,
    Facing,
    Effect
}

//@Mike
public enum MovementTypes
{
    WAIT,
    STRAIGHT,
    BEZIER
};

public enum FacingTypes
{
    LOOKAT,
    LOOKCHAIN,
    WAIT,
    FREELOOK
}

public enum EffectTypes
{
    SHAKE,
    SPLATTER,
    FADE,
    WAIT
}

public static class ScriptShooterNavEnums{

}
