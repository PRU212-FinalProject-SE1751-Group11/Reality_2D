using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
	public GameObject shakeFx;      // The object that will simulate the shake effect
	public float shakeDuration;     // How long the shake will last
	public float delayBeforeShake;  // Time in seconds before each shake happens (adjustable in the inspector)

	void Start()
	{
		shakeFx.SetActive(false);
		StartCoroutine(ShakeRepeatedly());  // Start the repeated shake coroutine
	}

	IEnumerator ShakeRepeatedly()
	{
		while (true)  // Infinite loop to shake repeatedly
		{
			yield return new WaitForSeconds(delayBeforeShake);  // Wait for the delay before shaking
			StartCoroutine(Shake(shakeDuration));  // Trigger the shake for the specified duration
		}
	}

	IEnumerator Shake(float t)
	{
		shakeFx.SetActive(true);   // Activate the shake effect
		yield return new WaitForSeconds(t); // Wait for the duration of the shake
		shakeFx.SetActive(false);  // Deactivate the shake effect
	}
}