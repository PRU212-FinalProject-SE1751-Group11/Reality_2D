using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour, Interactable
{
   public void Interact()
    {
        if (!GameState.Instance.completedQuest1)
        {
            GameState.Instance.completedQuest1 = true;
            Debug.Log("Quest 1 completed!");
        }
        else
        {
            Debug.Log("Quest 1 has already been completed.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Interact();
    }
}