using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] public string sceneLeft;
    [SerializeField] public string sceneRight;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.name == "LeftTrigger")
            {
                PlayerPrefs.SetString("EntryPoint", "Left");
                Initiate.Fade(sceneLeft, Color.black, 5f);
            }
            else if (gameObject.name == "RightTrigger")
            {
                PlayerPrefs.SetString("EntryPoint", "Right");
                Initiate.Fade(sceneRight, Color.black, 5f);
            }
        }
    }
}
