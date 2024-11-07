using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SisterHug : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 3f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D()
    {
        Debug.Log("Va chjam");
        Initiate.Fade("002", Color.white, 0.35f);
     
    }
}
