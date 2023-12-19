public class GameManager : MonoBehaviourPunCallbacks
{
    // ----- Stats Variables -----
    [Header("Stats")]
    [HideInInspector]
    public bool gameEnded = false;          // Indicates whether the game has ended.
    public float timeToWin;                 // Time a player needs to hold the hat to win.
    public float invincibleDuration;        // Duration of invincibility after getting the hat.

    // ----- Player Variables -----
    [Header("Players")]
    public string playerPrefabLocation;     // Player prefab path in the Resources folder.
    public Transform[] spawnPoints;         // Array of player spawn points.
    [HideInInspector]
    public PlayerController[] players;      // Array of all players.
    [HideInInspector]
    public int playerWithHat;               // ID of the player currently holding the hat.
    private int playersInGame;              // Number of players in the Game scene.

    // ----- Components -----
    [Header("Components")]
    public PhotonView photonView;           // PhotonView component for network synchronization.

    // Instance reference for singleton pattern
    public static GameManager instance;

    void Awake()
    {
        // Set the instance to this script, ensuring there's only one GameManager instance.
        instance = this;
    }

    void Start()
    {
        // Initialize the players array based on the number of players in the Photon network.
        players = new PlayerController[PhotonNetwork.PlayerList.Length];

        // Notify all players that a new player has loaded into the game.
        photonView.RPC("ImInGame", RpcTarget.AllBuffered);
    }

    // Called when a player loads into the game scene - tell everyone.
    [PunRPC]
    void ImInGame()
    {
        playersInGame++;

        // When all the players are in the scene, spawn the players.
        if (playersInGame == PhotonNetwork.PlayerList.Length)
            SpawnPlayer();
    }

    // Spawns a player and initializes it.
    void SpawnPlayer()
    {
        // Instantiate the player across the network at a random spawn point.
        GameObject playerObj = PhotonNetwork.Instantiate(playerPrefabLocation, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity, 0);

        // Get the player script.
        PlayerController playerScript = playerObj.GetComponent<PlayerController>();

        // Initialize the player.
        playerScript.photonView.RPC("Initialize", RpcTarget.All, PhotonNetwork.LocalPlayer);
    }

    // Returns the player who has the requested ID.
    public PlayerController GetPlayer(int playerId)
    {
        return players.First(x => x.id == playerId);
    }

    // Returns the player of the requested GameObject.
    public PlayerController GetPlayer(GameObject playerObject)
    {
        return players.First(x => x.gameObject == playerObject);
    }

    // Called when a player's held the hat for the winning amount of time.
    [PunRPC]
    void WinGame(int playerId)
    {
        gameEnded = true;
        PlayerController player = GetPlayer(playerId);
        GameUI.instance.SetWinText(player.photonPlayer.NickName);
        Invoke("GoBackToMenu", 3.0f);
    }

    // Called after the game has been won - navigates back to the Menu scene.
    void GoBackToMenu()
    {
        PhotonNetwork.LeaveRoom();
        NetworkManager.instance.ChangeScene("Menu");
    }
}

