using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steel : MonoBehaviour
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
            SisterMove.isHandel = true;
            Destroy(gameObject);
        }
    }
}