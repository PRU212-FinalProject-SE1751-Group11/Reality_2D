using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAspectRatio : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        AdjustBackgroundSize();
    }

    void AdjustBackgroundSize()
    {
        float screenHeight = Camera.main.orthographicSize * 2.0f;
        float screenWidth = screenHeight / Screen.height * Screen.width;

        transform.localScale = new Vector3(screenWidth / spriteRenderer.sprite.bounds.size.x, screenHeight / spriteRenderer.sprite.bounds.size.y, 1);
    }
    void Update()
    {
        AdjustBackgroundSize();
    }
}