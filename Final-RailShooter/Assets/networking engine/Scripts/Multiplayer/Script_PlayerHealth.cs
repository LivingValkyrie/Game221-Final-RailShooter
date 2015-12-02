using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Script_PlayerHealth : NetworkBehaviour
{
    [SyncVar(hook = "OnHealthChanged")]
    public int health;           // Synced variable to hold the players health
   
    public string playerName;        // Holds the player name
    private string iD;               // Holds the network ID name
    public int respawnHealth = 75;   // Holds the health the player will respawn with

    public Text playerNameText;      // Text field that displays the players name.
    public Text playerHealthText;    // Text field that displays the players health.

    private bool shouldDie = false;  // Boolean for if the player is dead
    public bool isDead = false;
    

    public delegate void DieDelegate();
    public event DieDelegate EventDie;

    public delegate void RespawnDelegate();
    public event RespawnDelegate EventRespawn;

    // @author: Nathan Boehning
    // @summary: Displays the player name and allows health to be changed.
    //           Keeps the players life synced inside of the server.
    void Start()
    {

        // Finds the various UI elements within the scene when its created
        playerNameText = GameObject.Find("TextPlayerName").GetComponent<Text>();
        playerHealthText = GameObject.Find("TextPlayerHealth").GetComponent<Text>();

        iD = "Player " + GetComponent<NetworkIdentity>().netId;
        gameObject.name = iD;

        // Sets the initial health text
        SetHealthText();

        // Sets the player name to the ID if it doesn't have a name
        if (string.IsNullOrEmpty(playerName))
        {
            playerName = iD;
        }

        // Sets the text of the text field to the player name
        playerNameText.text = playerName;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Update()
    {

        CheckCondition();

    }

    // Updating following the GTGD tutorials

    void CheckCondition()
    {
        if (health <= 0 && !shouldDie && !isDead)
        {
            shouldDie = true;
        }

        if (health <= 0 && shouldDie)
        {
            if (EventDie != null)
            {
                EventDie();
            }

            shouldDie = false;
        }

        if (health > 0 && isDead)
        {
            if (EventRespawn != null)
            {
                EventRespawn();
            }

            isDead = false;
        }

    }

    public void DeductHealth(int dmg)
    {
        health -= dmg;
    }

    void OnHealthChanged(int newHealth)
    {
        health = newHealth;
        SetHealthText();
    }

    public void ResetHealth()
    {
        health = 100;
    }

    void SetHealthText()
    {
        if (isLocalPlayer)
        {
            // Update the healths text
            playerHealthText.text = "Health: " + health;

            // Change the color of the player health text based on how much is left
            if (health > 60)
                playerHealthText.color = Color.green;
            else if (health > 25)
                playerHealthText.color = Color.yellow;
            else
                playerHealthText.color = Color.red;
        }
    }

    /*
    [Client]
    public void AddHealth(int healthToAdd)
    {
        // Adds health to the local player, and sends a command to update the players health 
        // within the server.

        playerHealth += healthToAdd;
        CmdSendHealthToServer(playerHealth);

    }

    [Client]
    public void RemoveHealth(int healthToRemove)
    {
        // Removes health from the local player, and sends a command to update the players heath
        // within the server

        playerHealth -= healthToRemove;
        CmdSendHealthToServer(playerHealth);
    }

    // Sets the synced variable to the updated player health
    [Command]
    private void CmdSendHealthToServer(int healthToSend)
    {
        syncHealth = healthToSend;
    }
    
    [Command]
    private void CmdUpdateRenderer(bool isRendered)
    {
        syncRenderer.enabled = isRendered;
    }
    */
}
