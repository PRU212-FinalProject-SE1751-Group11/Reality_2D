using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionManager : MonoBehaviour
{
    public Transform leftSpawnPoint;
    public Transform rightSpawnPoint;
    private GameObject player;
    private Animator playerAnimator;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerAnimator = player.GetComponent<Animator>();

        string entryPoint = PlayerPrefs.GetString("EntryPoint", "Right");
        if (entryPoint == "Left")
        {
            player.transform.position = rightSpawnPoint.position;
            playerAnimator.Play("idleRight");
        }
        else if (entryPoint == "Right")
        {
            player.transform.position = leftSpawnPoint.position;
            playerAnimator.Play("idleLeft");
        }
    }
}