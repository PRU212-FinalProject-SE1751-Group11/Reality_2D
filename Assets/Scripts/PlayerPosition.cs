using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPositionManager : MonoBehaviour
{
    public Transform leftSpawnPoint;
    public Transform rightSpawnPoint;
    public Transform defaultSpawn;
    private GameObject player;
    private Animator playerAnimator;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerAnimator = player.GetComponent<Animator>();

        if (SceneManager.GetActiveScene().name == "10")
        {
            bool hasVisitedScene = PlayerPrefs.GetInt("HasVisitedScene10", 0) == 1;

            if (!hasVisitedScene)
            {
                player.transform.position = defaultSpawn.position;
                playerAnimator.Play("idleRight");
                PlayerPrefs.SetInt("HasVisitedScene10", 1); 
                PlayerPrefs.SetString("EntryPoint", string.Empty);
            }
            else
            {
                player.transform.position = rightSpawnPoint.position;
                playerAnimator.Play("idleLeft");
            }
        }
        else
        {
            string entryPoint = PlayerPrefs.GetString("EntryPoint", string.Empty);

            if (string.IsNullOrEmpty(entryPoint))
            {
                player.transform.position = defaultSpawn.position;
                playerAnimator.Play("idleRight");
            }
            else
            {
                if (entryPoint == "Left")
                {
                    player.transform.position = rightSpawnPoint.position;
                    playerAnimator.Play("idleLeft");
                }
                else if (entryPoint == "Right")
                {
                    player.transform.position = leftSpawnPoint.position;
                    playerAnimator.Play("idleRight");
                }
            }
        }
    }
}