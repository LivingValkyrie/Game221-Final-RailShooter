using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

// Author: Nathan Boehning
// Purpose: Gives players ability to shoot each other.

public class ScriptPlayerShoot : NetworkBehaviour
{
    // Access to the weapon the player will shoot
    public ScriptPlayerWeapon weapon;

    // Camera that the raycast will shoot from
    [SerializeField]
    private Camera camera;

    // Boolean to determine whether or not player can shoot again
    private bool canFire = true;

    void Start()
    {
        // Make sure the camera is set, if it's not disable shooting to avoid errors
        if (camera == null)
        {
            Debug.Log("ScriptPlayerShoot: No camera referenced");
            this.enabled = false;
        }
    }

    void Update()
    {
        // Make sure gun will only shoot on local player
        if (isLocalPlayer)
        {
            // Check if player has fired weapon
            if (Input.GetButtonDown("Fire1"))
            {
                // If the gun can fire
                if (canFire)
                {
                    // Call the shoot function
                    Shoot();

                    // Set can fire to false so player can't shoot again
                    canFire = false;

                    // Start the coroutine RecycleWeapon
                    StartCoroutine(RecycleWeapon());
                }
            }
        }
    }

    // Updating following the UNET tutorials by GTGD
    void Shoot()
    {
        // Define a raycast
        RaycastHit hit;

        // Shoot a raycast from the camera straight forward
        if (Physics.Raycast(camera.transform.TransformPoint(0, 0, 0.5f), camera.transform.forward, out hit, weapon.range))
        {
            // If the raycast hit a player
            if (hit.transform.tag == "Player")
            {
                string uIdentity = hit.transform.name;

                // Call function to update players health
                CmdTellServerWhoWasShot(uIdentity, weapon.damage);
            }
            
        }
    }

    [Command]
    void CmdTellServerWhoWasShot(string uniqueID, int dmg)
    {
        // Find the game object that was shot.
        GameObject go = GameObject.Find(uniqueID);

        // Apply the damage to the player.
        go.GetComponent<Script_PlayerHealth>().DeductHealth(dmg);
    }

    /*
    [Command]
    void CmdPlayerShot(string inputName)
    {
        // Show who was shot
        Debug.Log(inputName + " has been shot.");

        // Find the player that was shot, and remove health based on the weapons damage
        GameObject.Find(inputName).GetComponent<Script_PlayerHealth>().RemoveHealth(weapon.damage);
    }
    */

    // Enforces the rate of fire of the weapon
    IEnumerator RecycleWeapon()
    {
        // Waits for the rate of fire time to elapse (converting from ms to s)
        yield return new WaitForSeconds(TimeSpan.FromMilliseconds(weapon.rateOfFire).Seconds);

        // Sets canFire to true.
        canFire = true;
    }
}
