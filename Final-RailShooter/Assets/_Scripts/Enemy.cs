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
    public float health;
    public int pointWorth;

    //used for setting enemies attack attributes
    public int attack;
    public float radius; //used for active range
    public float speed;
    public EnemyState state; //enemy state machine

    //dynamics
    Player playerOne;
    Player playerTwo;

    #endregion

    void Start() {
        //later replace this with a starter, and have an object find all enemies to have them start when needed
        playerOne = GameObject.Find("rail follower 1").transform.GetComponentInChildren<Player>();

        //playerTwo = GameObject.Find( "rail follower 2" ).transform.GetComponentInChildren<Player>();
    }

    void Update() {
        //passive ai is alwaus waiting
        //scared is always fleeing
        //aggressive is always waiting until in range of player
        if (health <= 0) {
            playerOne.score += pointWorth;
            Destroy(gameObject);
        }

        switch (state) {
            case EnemyState.Active:
                //used for aggressive enemies
                Vector3 newPos = transform.position;
                newPos = Vector3.Lerp(newPos, playerOne.transform.position, speed * Time.deltaTime);
                transform.position = newPos;
                break;
            case EnemyState.Flee:
                transform.position = -Vector3.MoveTowards( transform.position, playerOne.transform.position, speed * Time.deltaTime);
                break;
            case EnemyState.Wait:
                break;
        }
    }

    void FixedUpdate() {
        //change state based on ai and events
        switch (ai) {
            case AIType.Agressive:
                if (Vector3.Distance(transform.position, playerOne.transform.position) <= radius) {
                    state = EnemyState.Active;
                }
                break;
            case AIType.Passive:
                state = EnemyState.Wait;
                break;
            case AIType.Scared:
                if (Vector3.Distance(transform.position, playerOne.transform.position) <= radius) {
                    state = EnemyState.Flee;
                }
                break;
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.name == "rail follower 1") {
            playerOne.health -= attack;
            Destroy(gameObject);
        }
    }
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