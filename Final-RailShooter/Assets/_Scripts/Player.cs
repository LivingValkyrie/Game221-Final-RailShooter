using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Security.Policy;

/// <summary>
/// Author: Matt Gipson
/// Contact: Deadwynn@gmail.com
/// Domain: www.livingvalkyrie.com
/// 
/// Description: Player 
/// </summary>
public class Player : MonoBehaviour {
    #region Fields

    public Text healthText, scoreText;
    public int score, health;
    [SerializeField]
    public Weapon weapon;

    #endregion

    void Start() {
        score = 0;
        health = 100;
        weapon = new Weapon();
        weapon.damage = 5;
    }

    void Update() {
        scoreText.text = score.ToString();
        healthText.text = health.ToString();

        if (health <= 0) {
            Application.LoadLevel("game over");
        }
    }

}