using System;
using UnityEngine;

/// a player's config
[Serializable]
public sealed class PlayerConfig {
    [Tooltip("the players index")]
    public int Index;

    [Tooltip("the player's musical key")]
    public Root Key;

    [Tooltip("the player's instrument")]
    public Instrument Instrument;
}