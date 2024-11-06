using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogBox;
    public Text nameText;
    public Text dialogText;
    public int letterPerSecs = 40;

    public static DialogueManager Instance { get;  set; }

    private int currentLineIndex = 0;
    private List<string> dialogLines;
    private Coroutine typingCoroutine;
    private string sceneToLoadAfterDialog;
    private bool isTyping;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowDialog(Dialog dialog, string sceneToLoad = null)
    {
        if (!dialogBox.activeInHierarchy)
        {
            dialogBox.SetActive(true);
            nameText.text = dialog.Name;
            dialogLines = dialog.Lines;
            currentLineIndex = 0;
            sceneToLoadAfterDialog = sceneToLoad;
            StartCoroutine(DisplayLines());
        }
    }

    private IEnumerator DisplayLines()
    {
        while (currentLineIndex < dialogLines.Count)
        {
            if (typingCoroutine != null)
                StopCoroutine(typingCoroutine);

            typingCoroutine = StartCoroutine(TypeDialog(dialogLines[currentLineIndex]));

            // Wait until typing is finished, then wait for 'Z' key press to continue
            yield return new WaitUntil(() => !isTyping);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Z));

            currentLineIndex++;
        }

        dialogBox.SetActive(false);

        // Load the scene if specified
        if (!string.IsNullOrEmpty(sceneToLoadAfterDialog))
        {
            Initiate.Fade(sceneToLoadAfterDialog, Color.white, 0.5f);
        }
    }

    private IEnumerator TypeDialog(string line)
    {
        isTyping = true;
        dialogText.text = "";
        foreach (var letter in line.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / letterPerSecs);
        }
        isTyping = false;
    }
}
