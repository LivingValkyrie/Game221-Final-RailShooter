using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;


// Author: Nathan Boehning
// Purpose respawns the player
// Gotten from GTGD tutorial
public class ScriptPlayerRespawn : NetworkBehaviour
{

	private Script_PlayerHealth healthScript;
	private Image crossHairImage;

	public Text respawnTimeText;     // Text field that displays respawn countdown.

	private GameObject respawnUI;    // Holds the respawn UI
	public int respawnTime = 10;     // How long until player respawns
	private int countdownTime;       // Variable to hold the current time the player has been dead

	// Use this for initialization
	void Start ()
	{
		// Get necessary components
		healthScript = GetComponent<Script_PlayerHealth>();
		healthScript.EventRespawn += EnablePlayer;

		crossHairImage = GameObject.Find("Crosshair Image").GetComponent<Image>();


		respawnUI = GameObject.Find("Canvas").transform.GetChild(3).gameObject;
		respawnTimeText = respawnUI.transform.GetChild(1).GetComponent<Text>();

		// Set initial time that counts down
		countdownTime = respawnTime;

		if (isLocalPlayer)
		{
			InvokeRepeating("CountdownTimer", 0f, 1.0f);
		}
	}

	// Decrements the time til player can respawn
	// Whenever it hits zero, it sets the position of the player to one of the spawn positions and resets all variables
	// To the state where player can play the game, and cancels the invoke on countdown so it doesn't
	// Continue to count down
	
	void CountdownTimer()
	{
		countdownTime -= 1;
		respawnTimeText.text = countdownTime.ToString();
		if (countdownTime <= 0)
		{
			gameObject.transform.position =
				GameObject.Find("Spawn Positions").transform.GetChild(Random.Range(0, 3)).transform.position;
			countdownTime = respawnTime;
			respawnUI.SetActive(false);
			CommenceRespawn();
			CancelInvoke("CountdownTimer");
		}
	}
	

	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnDisable()
	{
		healthScript.EventRespawn -= EnablePlayer;
	}

	void EnablePlayer()
	{
		GetComponent<ScriptPlayerShoot>().enabled = true;
		GetComponent<CapsuleCollider>().enabled = true;

		Renderer[] renderers = GetComponentsInChildren<Renderer>();

		foreach (Renderer ren in renderers)
		{
			ren.enabled = true;
		}

		healthScript.isDead = true;

		if (isLocalPlayer)
		{
			GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
			crossHairImage.enabled = true;
		}
	}

	void CommenceRespawn()
	{
		CmdRespawnOnServer();
	}

	[Command]
	void CmdRespawnOnServer()
	{
		healthScript.ResetHealth();
	}
}
