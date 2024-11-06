using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTransition : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
            Initiate.Fade("SemiEndScene",Color.black,0.5f);
    }
}
