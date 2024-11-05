using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour, Interactable
{
   public void Interact()
    {
        if (!GameState.Instance.OpenMind)
        {
            GameState.Instance.OpenMind = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Interact();
    }
}