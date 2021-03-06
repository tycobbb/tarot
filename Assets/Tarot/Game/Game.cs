using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

/// the game
public class Game: MonoBehaviour {
    // -- config --
    [Header("config")]
    [Tooltip("the configs for each player")]
    [SerializeField] PlayerConfig[] m_PlayerConfigs;

    // -- props --
    /// the current player count
    int m_NumPlayers = 0;

    /// the array of players
    Player[] m_Players = new Player[7];

    // -- lifecycle --
    void Update() {
        var k = Keyboard.current;

        var ctrl = k.ctrlKey;
        var r = k.rKey;
        var s = k.sKey;

        if (ctrl.isPressed && r.wasPressedThisFrame) {
            Reset();
        }

        if (ctrl.isPressed && s.wasPressedThisFrame) {
            Screenshot();
        }

        var man = GetComponent<PlayerInputManager>();

    }

    // -- commands --
    /// add a new player to the game
    void AddPlayer(Player player) {
        var i = m_NumPlayers;

        // prepare player
        player.Join(m_PlayerConfigs[i]);

        // add to game
        m_Players[i] = player;
        m_NumPlayers++;
    }

    /// reset the current scene
    void Reset() {
        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    /// take a screenshot of the scene
    void Screenshot() {
        var app = Application.productName.ToLower();
        ScreenCapture.CaptureScreenshot($"{app}.png");
    }

    // -- events --
    /// catch the player joined event
    public void OnPlayerJoined(Object obj) {
        // ignore call on startup where obj is the game (b/c it has an input?)
        var input = obj as PlayerInput;
        if (input == null) {
            return;
        }

        // make sure we have a player
        var player = input.GetComponent<Player>();
        if (player == null) {
            return;
        }

        AddPlayer(player);
    }
}
