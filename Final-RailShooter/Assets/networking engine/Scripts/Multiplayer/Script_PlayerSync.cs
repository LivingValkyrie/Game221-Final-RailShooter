using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Script_PlayerSync : NetworkBehaviour {

	[SyncVar]
	Vector3 syncedPosition;             // position variable that is synced with server
	[SyncVar]
	Quaternion syncedRotation;          // rotation variable that is synced with server

	#region variables
	[Header("\tReference Values")]
	public Transform myTransform;       // holds transform

	[Header("\tValues for Client Management")]
	[Header("Player")]
	public Rigidbody myRigidbody;       // holds rigid body
	public CapsuleCollider myCollider;  // holds collider
	public UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController myController;      // holds controller
	[Header("Camera")]
	public GameObject myCameraObject;   // holds the camera as game object
	public Camera myCamera;             // holds the camera as camera
	public AudioListener myListener;    // holds the audio listener

	[Header("\tSync Values")]
	[Header("Rotation")]
	public float rotationLerpRate = 15f;        // rotation lerp rate
	public float rotationThreshold = 5f;        // threshold before updating rotation
	[Header("Position")]
	public float positionLerpRate = 15f;        // position lerp rate
	public float positionThreshold = 0.3f;      // threshold before updating position

	Quaternion lastPlayerRotation;              // holds last rotation
	Vector3 lastPlayerPosition;                 // holds last position
	#endregion

	//@author: Tiffany Fischer
	//@modified by: Nathan Boehning
	//@summary: Updates the position and rotation of the clients player to the server
	//          and gives the other players smooth movement.
	void Start()
	{
		// If it's not the local player
		if (!isLocalPlayer)
		{
			// Destroy all the components that would all the local player to control your player.
			// Makes it so user can only control their player
			Destroy(myController);
			Destroy(myRigidbody);
			Destroy(myCameraObject);
			gameObject.layer = LayerMask.NameToLayer("RemotePlayer");

		}
	}

	void FixedUpdate()
	{
		// If it's the local player
		if (isLocalPlayer)
		{
			// Transmit the position and location to the server
			TransmitRotation();
			TransmitPosition();
		}
	}

	// Update is called once per frame
	void Update ()
	{
		// If it's not the local player
		if (!isLocalPlayer)
		{
			// Lerp the position and rotations for a smooth look
			LerpRotation();
			LerpPosition();
		}
	}

	#region rotation
	[Client]
	void TransmitRotation()
	{
		// Transmits the rotation of the player if the change in rotation is greater than the threshold.
		if (Quaternion.Angle(myTransform.rotation, lastPlayerRotation) > rotationThreshold)
		{
			CmdSendRotationToServer(myTransform.rotation);
			lastPlayerRotation = myTransform.rotation;
		}
	}

	[Command]
	void CmdSendRotationToServer(Quaternion rotationToSend)
	{
		// Sets the synced variable within server to updated rotation
		syncedRotation = rotationToSend;
	}


	void LerpRotation()
	{
		// Lerps the rotation for smooth look
		myTransform.rotation = Quaternion.Lerp(myTransform.rotation, syncedRotation, Time.deltaTime * rotationLerpRate);
	}
	#endregion

	#region position
	[Client]
	void TransmitPosition()
	{
		// Transmits the position of the player if the change in position is greater than the magnitude
		if (Mathf.Abs((myTransform.position - lastPlayerPosition).magnitude) > positionThreshold)
		{
			// calls command to update position
			CmdSendPositionToServer(myTransform.position);
			// updates the lastPlayerPosition
			lastPlayerPosition = myTransform.position;
		}
	}

	[Command]
	void CmdSendPositionToServer(Vector3 positionToSend)
	{
		// Sets the synced variable within the server to updated position
		syncedPosition = positionToSend;
	}

	void LerpPosition()
	{
		// Lerp the position for smooth look
		myTransform.position = Vector3.Lerp(myTransform.position, syncedPosition, Time.deltaTime * positionLerpRate);
	}
	#endregion
}
