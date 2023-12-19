public class NetworkManager : MonoBehaviourPunCallbacks
{
    // Reference to the PhotonView component
    [Header("Components")]
    public PhotonView photonView;

    // Singleton instance of the NetworkManager
    public static NetworkManager instance;

    void Awake()
    {
        // Check for existing instances, deactivate duplicates, and set this as the instance
        if (instance != null && instance != this)
            gameObject.SetActive(false); // Deactivate the duplicate NetworkManager
        else
        {
            instance = this; // Set this as the instance
            DontDestroyOnLoad(gameObject); // Keep this object when loading new scenes
        }
    }

    void Start()
    {
        // Connect to the master server using Photon settings
        PhotonNetwork.ConnectUsingSettings();
    }

    // Attempts to CREATE a new room with the specified name
    public void CreateRoom(string roomName)
    {
        PhotonNetwork.CreateRoom(roomName); // Create a new Photon room
    }

    // Attempts to JOIN an existing room with the specified name
    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName); // Join an existing Photon room
    }

    // Changes the scene using Photon's networked scene loading
    [PunRPC]
    public void ChangeScene(string sceneName)
    {
        PhotonNetwork.LoadLevel(sceneName); // Load a new scene across the network
    }
}