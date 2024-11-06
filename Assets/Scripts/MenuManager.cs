using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Tìm button và gán sự kiện click
        Button instructionButton = GameObject.Find("Button Instruction").GetComponent<Button>();
        instructionButton.onClick.AddListener(OnInstructionButtonClick);
        Button aboutUsButton = GameObject.Find("Button Aboutus").GetComponent<Button>();
        aboutUsButton.onClick.AddListener(OnAboutUsButtonClick);
    }

    void OnInstructionButtonClick()
    {
        // Chuyển đổi scene
        SceneManager.LoadScene("Tutorial");
    }
    void OnAboutUsButtonClick()
    {
        // Chuyển đổi scene
        SceneManager.LoadScene("AboutUs");
    }
    void StartNewGame()
    {

    }
    void LoadGame()
    {

    }
}