using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    public void MainMenu()
    {
        Debug.Log("Main menu");
        Initiate.Fade("MenuUI", Color.black, 1f);
    }
}
