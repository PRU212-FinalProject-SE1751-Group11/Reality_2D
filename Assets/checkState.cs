using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class checkState : MonoBehaviour
{
    public TMP_Text text;

    private void Start()
    {
        if (GameState.Instance.OnKeyWest)
        {
            text.text = "Get Key at west entraince";
        }else if (GameState.Instance.GotKeyWest)
        {
            text.text = "Bring to maintainer";
        }
    }
}
