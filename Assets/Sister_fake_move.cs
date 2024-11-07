using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sister_fake_move : MonoBehaviour
{
    public float moveSpeed = 3f;
    public bool movingRight = true;
    public static bool isHandel = false;
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