using UnityEngine;
using System.Collections;

/// <summary>
/// Author: Matt Gipson
/// Contact: Deadwynn@gmail.com
/// Domain: www.livingvalkyrie.com
/// 
/// Description: Weapon 
/// </summary>
public class Weapon : MonoBehaviour {
    #region Fields

    public string name;
    public float damage;
    public float manaCost;
    public float rechargeSpeed;
    public float castingSpeed;
    public float range;

    //for percision weapons - idk if i will use these or not
    public bool percision;
    public float zoom;

    #endregion
}