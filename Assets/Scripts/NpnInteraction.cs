using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcInteraction : MonoBehaviour
{
    public GameObject interactionIcon;
    public Transform player;
    public float interactionDistance = 3f;

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        interactionIcon.SetActive(distance <= interactionDistance);
    }
}
