using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource; 
    private float targetVolume = 0.5f;
    private float fadeDuration = 2f; 
    private float timer = 0f;

    void Start()
    {
        audioSource.volume = 0;
        audioSource.Play(); 
        StartCoroutine(FadeInMusic()); 
    }

    private IEnumerator FadeInMusic()
    {
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(0, targetVolume, timer / fadeDuration);
            yield return null; 
        }
        audioSource.volume = targetVolume;
    }
}
