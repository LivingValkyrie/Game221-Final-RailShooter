using UnityEngine;
using System.Collections;

/// <summary>
/// Author: Matt Gipson
/// Contact: Deadwynn@gmail.com
/// Domain: www.livingvalkyrie.com
/// 
/// Description: RailPlayer 
/// </summary>
public class RailPlayer : MonoBehaviour {
    #region Fields

    static int players;
    public Camera firstCamera, secondCamera;

    #endregion

    void Start() {
        players++;
        if (players == 1) {
            firstCamera.gameObject.SetActive(true);
        } else {
            secondCamera.gameObject.SetActive(true);
        }
    }

    void Update() { }

}