using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Tìm button và gán sự kiện click
        Button yourButton = GameObject.Find("Exit").GetComponent<Button>();
        yourButton.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        // Chuyển đổi scene
        SceneManager.LoadScene("MenuUI");
    }
}