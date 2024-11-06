using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public Button backButton;
    void Start()
    {
        backButton.onClick.AddListener(OnBackButtonClicked);
    }
    void OnBackButtonClicked()
    {
        // Logic để quay lại màn hình trước đó
        // Ví dụ: SceneManager.LoadScene("PreviousScene");
    }
}