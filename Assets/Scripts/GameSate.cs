using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DialogCondition
{
    FirstMeeting,
    OpenMind,
    General
}

public class GameState : MonoBehaviour
{
    public static GameState Instance { get; private set; }

    public bool hasMetNPC;
    public bool OpenMind;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
}
