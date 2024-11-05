using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SisterMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 2.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Right"))
        {

            Initiate.Fade("002", Color.black, 0.3f);
            Destroy(gameObject);
        }
    }

}
