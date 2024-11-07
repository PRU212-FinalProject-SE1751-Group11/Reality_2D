using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DialogCondition
{
    FirstMeeting,
    OnKeyWest,
    GotKeyWest,
    DoneKeyWest,    //got the lighter
    DoneLighter,
    OpenSecret,
    OpenMind,
    General
}

public class GameState : MonoBehaviour
{
    public static GameState Instance { get; private set; }

    public bool FirstMeeting;
    public bool GotKeyWest;
    public bool OnKeyWest;
    public bool DoneKeyWest;
    public bool DoneLighter;
    public bool OpenSecret;
    public bool OpenMind;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void SetState(DialogCondition condition, bool value)
    {
        switch (condition)
        {
            case DialogCondition.FirstMeeting:
                FirstMeeting = value;
                break;
            case DialogCondition.GotKeyWest:
                GotKeyWest = value;
                break;
            case DialogCondition.OnKeyWest:
                OnKeyWest = value;
                break;
            case DialogCondition.DoneKeyWest:
                DoneKeyWest = value;
                break;
            case DialogCondition.DoneLighter:
                DoneLighter = value;
                break;
            case DialogCondition.OpenSecret:
                OpenSecret = value;
                break;
            case DialogCondition.OpenMind:
                OpenMind = value;
                break;
            case DialogCondition.General:
                break;
        }
    }
    public bool GetState(DialogCondition condition)
    {
        return condition switch
        {
            DialogCondition.FirstMeeting => FirstMeeting,
            DialogCondition.OnKeyWest => OnKeyWest,
            DialogCondition.GotKeyWest => GotKeyWest,
            DialogCondition.DoneKeyWest => DoneKeyWest,
            DialogCondition.DoneLighter => DoneLighter,
            DialogCondition.OpenSecret => OpenSecret,
            DialogCondition.OpenMind => OpenMind,
            DialogCondition.General => false,
            _ => false,
        };
    }
}
