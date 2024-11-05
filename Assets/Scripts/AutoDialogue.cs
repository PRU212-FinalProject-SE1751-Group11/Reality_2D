using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDialogue : MonoBehaviour
{
    public GameObject dialogBox;
    public Dialog dialog;

    private void Start()
    {
        StartCoroutine(ShowDialog());
    }
    private IEnumerator ShowDialog()
    {
        yield return new WaitForSeconds(2f);

        if (!dialogBox.activeInHierarchy)
        {
            DialogueManager.Instance.ShowDialog(dialog);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        dialogBox.SetActive(false);
    }
}
