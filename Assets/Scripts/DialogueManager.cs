using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogBox;
    public Text nameText;      
    public Text dialogText;    
    public int letterPerSecs = 40;

    public static DialogueManager Instance { get; private set; }

    private int currentLineIndex = 0;
    private List<string> dialogLines;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowDialog(Dialog dialog)
    {
        if (!dialogBox.activeInHierarchy)
        {
            dialogBox.SetActive(true);
            nameText.text = dialog.Name;    
            dialogLines = dialog.Lines;   
            currentLineIndex = 0;         
            StartCoroutine(TypeDialog(dialogLines[currentLineIndex]));
        }
        else
        {
            currentLineIndex++;
            if (currentLineIndex < dialogLines.Count)
            {
                StartCoroutine(TypeDialog(dialogLines[currentLineIndex]));
            }
            else
            {
                dialogBox.SetActive(false);
            }
        }
    }

    public IEnumerator TypeDialog(string line)
    {
        dialogText.text = "";
        foreach (var letter in line.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / letterPerSecs);
        }
    }
}