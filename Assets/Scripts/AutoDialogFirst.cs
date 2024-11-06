using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDialogFirst : MonoBehaviour
{
    public GameObject dialogBox;
    public Dialog dialog;
    public float showTime = 2f;
    public float startDelay = 2f;
    public string sceneChange;
    private void Start()
    {
        StartCoroutine(ShowDialogAfterDelay());
    }

    private IEnumerator ShowDialogAfterDelay()
    {
        yield return new WaitForSeconds(startDelay);
        DialogueAutoManager.Instance.ShowDialog(dialog, sceneChange, showTime);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        dialogBox.SetActive(false);
    }
}
