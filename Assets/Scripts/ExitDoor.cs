using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    private bool isPlayerInTrigger = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        isPlayerInTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isPlayerInTrigger = false;
    }
    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.Z))
        {
            Initiate.Fade("MatureEnding",Color.white,0.5f);
        }
    }
}
