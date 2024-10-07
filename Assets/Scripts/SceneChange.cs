using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.name == "LeftTrigger")
            {
                Initiate.Fade("11", Color.black, 5f);
            }
            else if (gameObject.name == "RightTrigger")
            {
                Initiate.Fade("11", Color.black, 5f);
            }
        }
    }
}
