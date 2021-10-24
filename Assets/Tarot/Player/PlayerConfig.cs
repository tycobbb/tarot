using System;
using UnityEngine;

// -- types --
/// a wand player's input
[Serializable]
public enum WandInput {
    None,
    S,
    F,
    T,
    J,
    N,
}

/// a sword player's input
[Serializable]
public enum SwordInput {
    None,
    L,
    R
}

/// a player's input config (a union)
[Serializable]
public struct PlayerInputConfig {
    [Tooltip("the wand input, if any")]
    public WandInput Wand;

    [Tooltip("the sword input, if any")]
    public SwordInput Sword;
}

// -- impls --
/// a player's config
[Serializable]
public sealed class PlayerConfig {
    [Tooltip("the players index")]
    public int Index;

    [Tooltip("the player's input")]
    public PlayerInputConfig Input;

    [Tooltip("the player's musical key")]
    public Root Key;

    [Tooltip("the player's instrument")]
    public Instrument Instrument;
}