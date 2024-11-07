using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatureManage : MonoBehaviour
{
    // Start is called before the first frame update
    public float waitTime = 5f;     // Thời gian chờ trước khi fade
    public float fadeDuration = 1f; // Thời gian để fade

    void Start()
    {
        StartCoroutine(WaitAndLoadScene());
    }

    private IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSeconds(waitTime);

        Initiate.Fade("Thanksplaying", Color.black, 0.3f);
    }
}
