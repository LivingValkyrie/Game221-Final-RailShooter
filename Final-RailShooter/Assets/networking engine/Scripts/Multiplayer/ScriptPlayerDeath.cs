using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

// Author: Nathan Boehning
// Purpose: Handles death of player
public class ScriptPlayerDeath : NetworkBehaviour
{
	// Completed following the GTGD tutorial

	private Script_PlayerHealth healthScript;
	private Image crossHairImage;

	// Use this for initialization
	void Start ()
	{
		crossHairImage = GameObject.Find("Crosshair Image").GetComponent<Image>();
		healthScript = GetComponent<Script_PlayerHealth>();
		healthScript.EventDie += DisablePlayer;

	}

	void OnDisable()
	{
		healthScript.EventDie -= DisablePlayer;
	}

	// Update is called once per frame
	void Update ()
	{
	
	}

	// Disable the character so player can't use him and other players can't see him.
	void DisablePlayer()
	{
		GetComponent<ScriptPlayerShoot>().enabled = false;
		GetComponent<CapsuleCollider>().enabled = false;

		Renderer[] renderers = GetComponentsInChildren<Renderer>();

		foreach (Renderer ren in renderers)
		{
			ren.enabled = false;
		}

		healthScript.isDead = true;

		if (isLocalPlayer)
		{
			GetComponent<FirstPersonController>().enabled = false;
			crossHairImage.enabled = false;
			// Respawn
		}
	}
}
