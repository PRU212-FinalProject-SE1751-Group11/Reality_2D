using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using System.Collections;

public class VideoAudioSync : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;
    public Text smoothText;
    public string nextSceneName;
    private float timer = 0f;

    private void Start()
    {
        videoPlayer.waitForFirstFrame = true;
        videoPlayer.Prepare();
        videoPlayer.prepareCompleted += OnPrepared;

        audioSource.volume = 0;
        videoPlayer.Play();
        audioSource.Play();
        smoothText.color = new Color(smoothText.color.r, smoothText.color.g, smoothText.color.b, 0);

        StartCoroutine(ShowTextSmoothly());
        StartCoroutine(FadeInMusic());
    }

    private void OnPrepared(VideoPlayer vp)
    {
        videoPlayer.Play();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= (float)videoPlayer.length - 50f)
        {
            StartCoroutine(FadeOutMusicAndSwitchScene());
        }
    }

    private IEnumerator ShowTextSmoothly()
    {
        yield return new WaitForSeconds(2f);

        float fadeDuration = 3f;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            smoothText.color = new Color(smoothText.color.r, smoothText.color.g, smoothText.color.b, alpha);
            yield return null;
        }
    }

    private IEnumerator FadeInMusic()
    {
        float fadeDuration = 2f;
        float targetVolume = 0.5f;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(0, targetVolume, elapsedTime / fadeDuration);
            yield return null;
        }
        audioSource.volume = targetVolume;
    }

    private IEnumerator FadeOutMusicAndSwitchScene()
    {
        float fadeDuration = 2f;
        float startVolume = audioSource.volume;
        float elapsedTime = 0f;

        float blackFadeDuration = 0.3f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, 0, elapsedTime / fadeDuration);
            yield return null;
        }
        audioSource.volume = 0;
        Initiate.Fade(nextSceneName, Color.black, blackFadeDuration);
        yield return new WaitForSeconds(blackFadeDuration);

    }
}