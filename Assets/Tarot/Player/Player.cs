using UnityEngine;
using UnityEngine.InputSystem;

/// a player
public class Player: MonoBehaviour {
    // -- deps --
    /// the score module
    Score m_Score;

    /// the message module
    Message m_Message;

    // -- tuning --
    [Tooltip("plays music")]
    [SerializeField] Musicker mMusic;

    [Tooltip("the input system input")]
    [SerializeField] PlayerInput mInput;

    // -- props --
    /// the player's config
    PlayerConfig m_Config;

    /// the musical key
    Key m_Key;

    /// the player's inputs
    PlayerActions m_Actions;

    // -- lifecycle --
    void Awake() {
        // set deps
        m_Score = Score.Get;
        m_Message = Message.Get;

        // set props
        m_Actions = new PlayerActions(mInput);

        // apply config
        Configure();
    }

    void Start() {
        Announce();
    }

    // -- commands --
    /// init this player on join
    public void Join(PlayerConfig cfg) {
        name = $"Player{cfg.Index}";
        Debug.Log($"{name} joined");

        // set props
        m_Config = cfg;
    }

    /// apply player config
    void Configure() {
        var cfg = m_Config;

        // apply config
        m_Key = new Key(cfg.Key);

        // show score
        m_Score.AddPlayer(cfg);
    }

    /// announce this player joining
    void Announce() {
        m_Message.Show(m_Config.Input.Wand.ToString());
    }
}