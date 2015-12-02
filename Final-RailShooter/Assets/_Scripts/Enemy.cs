using UnityEngine;
using System.Collections;
using System.Security.Policy;

/// <summary>
/// Author: Matt Gipson
/// Contact: Deadwynn@gmail.com
/// Domain: www.livingvalkyrie.com
/// 
/// Description: Enemy 
/// </summary>
public class Enemy : MonoBehaviour {
    #region Fields

    public AIType ai;
    public int health;
    public float resistance;
    //used for setting enemies attack attributes
    public Weapon attack;
    public float radius; //used for active range
    public EnemyState state; //enemy state machine
    
    #endregion
    
}

public enum AIType {
    Passive,
    Agressive,
    Scared
}

public enum EnemyState {
    Active,
    Wait,
    Flee
}