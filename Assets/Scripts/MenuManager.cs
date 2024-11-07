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
    public void StartNewGame()
    {
        Initiate.Fade("00",Color.black,1f);
    }
    public void LoadGame()
    {
        GameData loadedData = FileDataHandler.Load();
        if (loadedData != null)
        {
            Debug.Log("Game Loaded Successfully");
            GameState.Instance.SetState(DialogCondition.FirstMeeting, loadedData.FirstMeeting); // FirstMeeting is set to true
            GameState.Instance.SetState(DialogCondition.GotKeyWest, loadedData.GotKeyWest); // GotKeyWest is set to true
            GameState.Instance.SetState(DialogCondition.OnKeyWest, loadedData.OnKeyWest); // OnKeyWest is set to false
            GameState.Instance.SetState(DialogCondition.DoneKeyWest, loadedData.DoneKeyWest); // DoneKeyWest is set to true
            GameState.Instance.SetState(DialogCondition.DoneLighter, loadedData.DoneLighter); // DoneLighter is set to false
            GameState.Instance.SetState(DialogCondition.OpenSecret, loadedData.OpenSecret); // OpenSecret is set to true
            GameState.Instance.SetState(DialogCondition.OpenMind, loadedData.OpenMind);

            Initiate.Fade("10", Color.black, 1f);
        }
        else
        {
            Debug.LogWarning("No saved game data to load");
        }
    }
}