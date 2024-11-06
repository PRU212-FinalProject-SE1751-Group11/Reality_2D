using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour, Interactable
{
    public List<DialogCondition> triggerConditions; 
    public List<bool> desiredStates; 

    public void Interact()
    {
        for (int i = 0; i < triggerConditions.Count; i++)
        {
            if (i < desiredStates.Count)
            {
                GameState.Instance.SetState(triggerConditions[i], desiredStates[i]);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Interact();
    }
}