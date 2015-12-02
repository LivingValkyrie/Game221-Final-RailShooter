using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

// @author: Nathan Boehning
// @summary: Displays the latency of the client

public class Script_Latency : NetworkBehaviour {

    NetworkClient client;           // Holds the client of the manager
    int latency;                    // Holds the latency of the client
    Text latencyText;               // Text field to display the latency

    // Use this for initialization
    void Start ()
    {
        // If its the local player
        if (isLocalPlayer)
        {
            // gets the client component of the network manager
            client = GameObject.Find("Network Manager").GetComponent<NetworkManager>().client;

            // Finds the text field for the latency variable
            latencyText = GameObject.Find("Latency_Text").GetComponent<Text>();
        }
        else
        {
            // Otherwise destroys this script component
            Destroy(this);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Call the update latency function
        UpdateLatency();
	}

    void UpdateLatency()
    {
        // Get the round trip time of the client, and set it equal to latency
        latency = client.GetRTT();

        // Set the color of the text field based on the latency
        if (latency < 200)
        {
            latencyText.color = Color.green;
        }
        else if (latency < 300)
        {
            latencyText.color = Color.yellow;
        }
        else
        {
            latencyText.color = Color.red;
        }

        // Set the text
        latencyText.text = latency + " ms";
    }
}
