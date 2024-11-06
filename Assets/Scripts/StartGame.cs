using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public Image fadeImage;         // Kéo Image từ Canvas vào đây
    public float waitTime = 4f;     // Thời gian chờ trước khi fade
    public float fadeDuration = 1f; // Thời gian để fade

    void Start()
    {
        StartCoroutine(WaitAndLoadScene());
    }

    private IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSeconds(waitTime);

        Initiate.Fade("001a", Color.black, 0.3f);
    }
}
