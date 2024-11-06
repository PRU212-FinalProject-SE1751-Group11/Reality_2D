using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueAutoManager : MonoBehaviour
{
    public GameObject dialogBox;
    public Text nameText;
    public Text dialogText;
    public int letterPerSecs = 40;
    private string nextScene;
    public static DialogueAutoManager Instance { get; private set; }

    private int currentLineIndex = 0;
    private List<string> dialogLines;
    private Coroutine typingCoroutine;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowDialog(Dialog dialog, string sceneChange, float showTime = 0f)
    {
        if (!dialogBox.activeInHierarchy)
        {
            dialogBox.SetActive(true);
            nameText.text = dialog.Name;
            dialogLines = dialog.Lines;
            currentLineIndex = 0;
            nextScene = sceneChange;
            StartCoroutine(DisplayLines(showTime));
        }
    }

    private IEnumerator DisplayLines(float showTime)
    {
        while (currentLineIndex < dialogLines.Count)
        {
            if (typingCoroutine != null)
                StopCoroutine(typingCoroutine);

            typingCoroutine = StartCoroutine(TypeDialog(dialogLines[currentLineIndex]));
            yield return new WaitForSeconds(showTime);
            currentLineIndex++;
        }

        dialogBox.SetActive(false);

        if (!string.IsNullOrEmpty(nextScene))
        {
            Initiate.Fade(nextScene, Color.white, 0.5f);
        }
    }

    private IEnumerator TypeDialog(string line)
    {
        dialogText.text = "";
        foreach (var letter in line.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / letterPerSecs);
        }
    }
}