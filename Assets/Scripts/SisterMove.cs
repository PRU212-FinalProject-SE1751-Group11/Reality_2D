using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SisterMove : MonoBehaviour
{
    public float moveSpeed = 3f;
    private bool movingRight = true;

    void Update()
    {
        if (movingRight)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Right"))
        {
            Initiate.Fade("002", Color.black, 0.3f);
            Destroy(gameObject);
        }
        else if (other.CompareTag("LeftTurn") || other.CompareTag("RightTurn"))
        {
            movingRight = !movingRight;

            Vector3 npcScale = transform.localScale;
            npcScale.x *= -1;
            transform.localScale = npcScale;
        }
    }
}