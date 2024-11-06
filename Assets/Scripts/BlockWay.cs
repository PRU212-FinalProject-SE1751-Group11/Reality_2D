using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockWay : MonoBehaviour
{
    public bool conditionMet = false;
    public GameObject dialogBox;
    public Dialog dialog;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (conditionMet)
            {
                GetComponent<BoxCollider2D>().isTrigger = true;
            }
            else
            {
                GetComponent<BoxCollider2D>().isTrigger = true;
                ShowDialog();
            }
        }
    }

    private void ShowDialog()
    {
        if (!dialogBox.activeInHierarchy)
        {
            DialogueAutoManager.Instance.ShowDialog(dialog,"");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        dialogBox.SetActive(false);
    }
}
