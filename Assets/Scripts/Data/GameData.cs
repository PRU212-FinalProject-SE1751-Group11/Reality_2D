using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{    
    public bool FirstMeeting;
    public bool GotKeyWest;
    public bool OnKeyWest;
    public bool DoneKeyWest;
    public bool DoneLighter;
    public bool OpenSecret;
    public bool OpenMind;
    public GameData() { }
    public GameData(GameState gameState)
    {
        FirstMeeting = gameState.FirstMeeting;
        GotKeyWest = gameState.GotKeyWest;
        OnKeyWest = gameState.OnKeyWest;
        DoneKeyWest = gameState.DoneKeyWest;
        DoneLighter = gameState.DoneLighter;
        OpenSecret = gameState.OpenSecret;
        OpenMind = gameState.OpenMind;
    }
}
