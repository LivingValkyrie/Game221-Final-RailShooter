using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

/// <summary>
/// Author: Matt Gipson
/// Contact: Deadwynn@gmail.com
/// Domain: www.livingvalkyrie.com
/// 
/// Description: RailPlayer 
/// </summary>
public class RailPlayer : NetworkBehaviour {
    #region Fields

    public ScriptRailEngine railEngine;
    bool started;
    #endregion

    void Awake() {
        //set parent to first rail for now
        if (int.Parse(netId.ToString()) == 0) {
            transform.parent = GameObject.Find("rail follower 1").transform;
        } else {
            transform.parent = GameObject.Find( "rail follower 2" ).transform;
        }
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        railEngine = transform.parent.GetComponent<ScriptRailEngine>();
        railEngine.Awaken();
        started = false;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && !started) {
            railEngine.Starter();
            started = true;
        }
    }

    /*
        get cameras on object
        display canvas
        once weapon has been chosen, select what player you are. (auto if possible)
        once player is chosen set camera based on that. 
        once ready set flag
        have check for all players ready
        once all players are ready change game state to play    
    */

}