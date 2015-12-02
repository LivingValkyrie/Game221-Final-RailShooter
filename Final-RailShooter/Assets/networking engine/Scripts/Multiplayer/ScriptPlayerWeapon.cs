using UnityEngine;
using System.Collections;

// Author: Nathan Boehning
// Purpose: Gives the designer ability to change the values of what can be shot by player
[System.Serializable]
public class ScriptPlayerWeapon
{
    // Name of the weapon
    public string name = "Pistol";

    // How much damage the bullet will do
    public int damage = 10;

    // How far the "bullet" will go
    public float range = 50f;

    // Holds the rate of fire of the weapon
    [Tooltip("Rate of fire of the weapon (ms)")]
    public float rateOfFire = 500;
}
