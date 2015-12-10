using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

/// <summary>
/// Author: Matt Gipson
/// Contact: Deadwynn@gmail.com
/// Domain: www.livingvalkyrie.com
/// 
/// Description: Portal 
/// </summary>
public class Portal : MonoBehaviour {
    #region Fields

    #endregion

    void Start() {
        FindObjectOfType<NetworkManagerHUD>().enabled = false;
    }

    void Update() { }

    void OnTriggerEnter(Collider other) {
        if (other.name == "rail follower 1") {
            Application.LoadLevel("game won");
        }
    }

}