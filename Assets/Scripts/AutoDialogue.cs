using System.Collections;
using UnityEngine;

public class AutoDialogue : MonoBehaviour
{
    public GameObject dialogBox;
    public Dialog dialog;
    public float showTime = 2f;
    public float startDelay = 2f;
    public string sceneChange;
    private void Start()
    {
        //PlayerPrefs.SetInt("DialogShown", 0);
        if (PlayerPrefs.GetInt("DialogShown", 0) == 0)
        {
            PlayerPrefs.SetInt("DialogShown", 1);
            StartCoroutine(ShowDialogAfterDelay());
        }
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