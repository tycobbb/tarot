using UnityEngine;

/// the score module
public class Score: MonoBehaviour {
    // -- module --
    /// get the module
    public static Score Get {
        get => FindObjectOfType<Score>();
    }

    // -- commands --
    /// start tracking players score
    public void AddPlayer(PlayerConfig cfg) {
    }
}