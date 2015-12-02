using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.UI;

public enum MenuStates {
    MENU_MAIN,
    MENU_CONNECT,
    MENU_SETUP,
    MENU_QUITTING,
    SETUP_STARTING_HOST,
    SETUP_STARTING_SERVER,
    CONNECT_CONNECTING_TO_SERVER
}

public enum MenuCommands {
    GOTO_CONNECT,
    GOTO_SETUP,
    GOTO_MAIN,
    QUIT_APPLICATION,
    SETUP_HOST,
    SETUP_SERVER,
    CONNECT_CLIENT
}

// @author: Tiffany Fischer
// @modified by: Nathan Boehning
// @summary: Creates the transitions between the different menus/scenes.

public class Script_MenuState : MonoBehaviour {

    Dictionary<MenuTransitions, MenuStates> allTransitions; //A  dictionary for all state transitions

    Dictionary<string, MenuCommands> enumParse;

    public MenuStates CurrentState { get; private set; } //A property to store the current state of the machine
    public MenuStates PreviousState { get; private set; } //A property to store the previous state of the machine

    public GameObject mainMenu; //A reference to the main menu game object for menu navigation
    public GameObject connectMenu; //A reference to the connect menu game object for menu navigation
    public GameObject setupMenu; //A reference to the setup menu game object for menu navigation
    public NetworkManager manager; //A reference to the network manager for managing connections

    [HideInInspector] public string playerName; // Variable to hold the player name until the player can fetch it.

    public Text numObstacles, minX, maxX, minY, maxY, minZ, maxZ; //References to the Text Boxes for server setup
    public Text defNumObstacles, defMinX, defMaxX, defMinY, defMaxY, defMinZ, defMaxZ; //References to the Text Boxes for server setup
    public Text hostName, clientName; //References to the Text Boxes for player name in the Host and Connection Screens

    // Use this for initialization
    void Start() {
        //Setup the current state to be main
        CurrentState = MenuStates.MENU_MAIN;

        //Setup the previous state to be connect
        PreviousState = MenuStates.MENU_CONNECT;

        //Create the dictionary 
        allTransitions = new Dictionary<MenuTransitions, MenuStates> {
            //Defines the state transitions where
            //{ new MenuTransition(actual state of the machine, transition state/command), final state of the machine) }
            {new MenuTransitions(MenuStates.MENU_MAIN, MenuCommands.GOTO_CONNECT), MenuStates.MENU_CONNECT},
            {new MenuTransitions(MenuStates.MENU_MAIN, MenuCommands.GOTO_SETUP), MenuStates.MENU_SETUP},
            {new MenuTransitions(MenuStates.MENU_MAIN, MenuCommands.QUIT_APPLICATION), MenuStates.MENU_QUITTING},
            {new MenuTransitions(MenuStates.MENU_CONNECT, MenuCommands.GOTO_MAIN), MenuStates.MENU_MAIN},
            {new MenuTransitions(MenuStates.MENU_CONNECT, MenuCommands.CONNECT_CLIENT), MenuStates.CONNECT_CONNECTING_TO_SERVER},
            {new MenuTransitions(MenuStates.MENU_SETUP, MenuCommands.GOTO_MAIN), MenuStates.MENU_MAIN},
            {new MenuTransitions(MenuStates.MENU_SETUP, MenuCommands.SETUP_HOST), MenuStates.SETUP_STARTING_HOST},
            {new MenuTransitions(MenuStates.MENU_SETUP, MenuCommands.SETUP_SERVER), MenuStates.SETUP_STARTING_SERVER}
        };

        //Create the dictionary where
        //{string that is passed by the button, command the string represets}
        enumParse = new Dictionary<string, MenuCommands> {
            {"goto connect menu", MenuCommands.GOTO_CONNECT},
            {"goto setup menu", MenuCommands.GOTO_SETUP},
            {"goto main menu", MenuCommands.GOTO_MAIN},
            {"quit application", MenuCommands.QUIT_APPLICATION},
            {"setup host", MenuCommands.SETUP_HOST},
            {"setup server", MenuCommands.SETUP_SERVER},
            {"connect to server", MenuCommands.CONNECT_CLIENT}
        };

        Debug.Log("Curr state = " + CurrentState);
    }

    /// <summary>
    /// Gets the next state if a given command/transition is run
    /// </summary>
    /// <param name="command">The command (or transition) to run</param>
    /// <returns></returns>
    MenuStates GetNext(MenuCommands command) {
        //Construct the new transition based on the machines current state, and the supplied transition/command
        MenuTransitions newTransition = new MenuTransitions(CurrentState, command);

        //Location to store the new state for the machine to go into
        MenuStates newState;

        //Make sure that the transition is valid, using the dictionary lookup
        if (!allTransitions.TryGetValue(newTransition, out newState)) {
            throw new UnityException("Invalid transition " + CurrentState + " -> " + command);
        }

        //If at this point we have not broken anything, return the new state
        return newState;
    }

    /// <summary>
    /// Moves the state machine into the next state given a specific command/transition and triggers the transition
    /// </summary>
    /// <param name="command">The command/transition to run the machine through</param>
    public void MoveNextAndTransition(string command) {
        //Record the previous state for transition purposes
        PreviousState = CurrentState;

        //Location for the new command
        MenuCommands newCommand;

        //Try to get the value
        if (!enumParse.TryGetValue(command, out newCommand)) {
            throw new UnityException("Invalid command " + command);
        }

        //Setup the next state 
        CurrentState = GetNext(newCommand);

        //Transition to the next state
        Transition();
    }

    /// <summary>
    /// Will run any neccessary code for the transition from one state to the next
    /// </summary>
    void Transition() {
        MenuDataHolder data = GameObject.Find("Network Manager").GetComponent<MenuDataHolder>();

        switch (PreviousState) {
            //If my previous state is MAIN
            case MenuStates.MENU_MAIN:

                //If my NEW state is CONNECT
                if (CurrentState == MenuStates.MENU_CONNECT) {
                    Debug.Log("Transition from Main to Connect");
                    mainMenu.SetActive(false);
                    connectMenu.SetActive(true);
                }

                //If my NEW state is SETUP
                else if (CurrentState == MenuStates.MENU_SETUP) {
                    Debug.Log("Transition from Main to Start");
                    mainMenu.SetActive(false);
                    setupMenu.SetActive(true);
                }

                //If my NEW state is QUIT
                else if (CurrentState == MenuStates.MENU_QUITTING) {
                    Debug.Log("Transition from Main to Quit");
                    Application.Quit();
                }

                break;

            //If my previous state is CONNECT
            case MenuStates.MENU_CONNECT:

                //If my NEW state is MAIN
                if (CurrentState == MenuStates.MENU_MAIN) {
                    Debug.Log("Transition from Connect to Main");
                    connectMenu.SetActive(false);
                    mainMenu.SetActive(true);
                } else if (CurrentState == MenuStates.CONNECT_CONNECTING_TO_SERVER) {
                    Debug.Log("Transition from Connect to Connecting to Server");
                    data.isServer = false;
                    playerName = clientName.text;
                    manager.StartClient();
                }

                break;

            //If my previous state is SETUP
            case MenuStates.MENU_SETUP:

                //If my NEW state is MAIN
                if (CurrentState == MenuStates.MENU_MAIN) {
                    Debug.Log("Transition from Start to Main");
                    setupMenu.SetActive(false);
                    mainMenu.SetActive(true);
                } else if (CurrentState == MenuStates.SETUP_STARTING_SERVER) {
                    Debug.Log("Transitioning from Start to Server Starting");
                    data.isServer = true;
                    // Updated by Nathan to have default values being set from placeholder if the user didn't input
                    // anything into the regular text field.
                    try {
                        if (minX.text == null || minX.text == "" || minY.text == null || minY.text == "" || minZ.text == null ||
                            minZ.text == "" || numObstacles.text == null || numObstacles.text == "") {
                            data.minX = System.Convert.ToSingle(defMinX.text);
                            data.maxX = System.Convert.ToSingle(defMaxX.text);
                            data.minY = System.Convert.ToSingle(defMinY.text);
                            data.maxY = System.Convert.ToSingle(defMaxY.text);
                            data.minZ = System.Convert.ToSingle(defMinZ.text);
                            data.maxZ = System.Convert.ToSingle(defMaxZ.text);
                            data.numObstacles = System.Convert.ToInt32(defNumObstacles.text);
                            playerName = GameObject.Find("Host Name Text").GetComponent<Text>().text;
                            manager.StartServer();
                        } else {
                            data.minX = System.Convert.ToSingle(minX.text);
                            data.maxX = System.Convert.ToSingle(maxX.text);
                            data.minY = System.Convert.ToSingle(minY.text);
                            data.maxY = System.Convert.ToSingle(maxY.text);
                            data.minZ = System.Convert.ToSingle(minZ.text);
                            data.maxZ = System.Convert.ToSingle(maxZ.text);
                            data.numObstacles = System.Convert.ToInt32(numObstacles.text);
                            playerName = GameObject.Find("Host Name Text").GetComponent<Text>().text;
                            manager.StartServer();
                        }
                    } catch {
                        Debug.Log("All Server parameters must be filled in with appropriate numeric values.");
                        CurrentState = PreviousState;
                    }
                } else if (CurrentState == MenuStates.SETUP_STARTING_HOST) {
                    Debug.Log("Transition from Start to Host Starting");
                    data.isServer = true;
                    try {
                        // Updated by Nathan to have default values being set from placeholder if the user didn't input
                        // anything into the regular text field.
                        if (minX.text == null || minX.text == "" || minY.text == null || minY.text == "" || minZ.text == null ||
                            minZ.text == "" || numObstacles.text == null || numObstacles.text == "") {
                            data.minX = System.Convert.ToSingle(defMinX.text);
                            data.maxX = System.Convert.ToSingle(defMaxX.text);
                            data.minY = System.Convert.ToSingle(defMinY.text);
                            data.maxY = System.Convert.ToSingle(defMaxY.text);
                            data.minZ = System.Convert.ToSingle(defMinZ.text);
                            data.maxZ = System.Convert.ToSingle(defMaxZ.text);
                            data.numObstacles = System.Convert.ToInt32(defNumObstacles.text);
                            playerName = hostName.text;
                            manager.StartHost();
                        } else {
                            data.minX = System.Convert.ToSingle(minX.text);
                            data.maxX = System.Convert.ToSingle(maxX.text);
                            data.minY = System.Convert.ToSingle(minY.text);
                            data.maxY = System.Convert.ToSingle(maxY.text);
                            data.minZ = System.Convert.ToSingle(minZ.text);
                            data.maxZ = System.Convert.ToSingle(maxZ.text);
                            data.numObstacles = System.Convert.ToInt32(numObstacles.text);
                            playerName = hostName.text;
                            manager.StartHost();
                        }
                    } catch {
                        Debug.Log("All Server parameters must be filled in with appropriate numeric values.");
                        CurrentState = PreviousState;
                    }
                }

                break;
        }
    }

    /// <summary>
    /// Updates the IP on the manager
    /// </summary>
    /// @author: Tiffany Fischer
    /// <param name="message">The IP to update to</param>
    public void UpdateIP(Object message) {
        Text textObj = ((GameObject) message).GetComponent<Text>();
        if (textObj.text == "") {
            manager.networkAddress = "localhost";
        } else {
            manager.networkAddress = textObj.text;
        }

        Debug.Log("Updating address to... " + textObj.text);
    }

    /// <summary>
    /// Updates the network port on the manager
    /// </summary>
    /// @author: Tiffany Fischer
    /// <param name="message">The network port to update to</param>
    public void UpdatePort(Object message) {
        Text textObj = ((GameObject) message).GetComponent<Text>();
        int newPort;

        if (int.TryParse(textObj.text, out newPort)) {
            manager.networkPort = newPort;
        } else {
            manager.networkPort = 7777;
        }
    }

    /// <summary>
    /// Updates the name on the player prefab
    /// </summary>
    /// @author: Nathan Boehning
    /// <param name="message">The name to update to</param>
    public void UpdateName(Object message) {
        Text textObj = ((GameObject) message).GetComponent<Text>();
        if (textObj.text == "") {
            manager.playerPrefab.GetComponent<Script_PlayerHealth>().playerName = "player";
        } else {
            manager.playerPrefab.GetComponent<Script_PlayerHealth>().playerName = textObj.text;
        }

        Debug.Log("Updating player name to... " + textObj.text);
    }
}