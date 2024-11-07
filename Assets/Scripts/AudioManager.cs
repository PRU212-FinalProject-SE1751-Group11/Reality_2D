using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Slider volumeSlider; // Tham chiếu đến slider điều chỉnh âm lượng

    // Singleton pattern
    public static AudioManager Instance;  // Tham chiếu tới AudioManager duy nhất

    private void Awake()
    {
        // Nếu instance chưa được gán, gán nó với AudioManager hiện tại
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Giữ AudioManager khi chuyển scene
        }
        else
        {
            Destroy(gameObject); // Nếu đã có AudioManager, xóa nó đi
        }
    }

    // Start được gọi khi bắt đầu
    void Start()
    {
        // Đặt giá trị âm lượng ban đầu từ PlayerPrefs (hoặc mặc định là 0.5f)
        volumeSlider.value = PlayerPrefs.GetFloat("GameVolume", 0.5f);

        // Lắng nghe sự thay đổi âm lượng từ Slider
        volumeSlider.onValueChanged.AddListener(SetVolume);

        // Cập nhật âm lượng ngay khi bắt đầu
        AudioListener.volume = volumeSlider.value;
    }

    // Hàm điều chỉnh âm lượng game
    public void SetVolume(float volume)
    {
        // Thay đổi âm lượng của AudioListener (ảnh hưởng đến tất cả AudioSource)
        AudioListener.volume = volume;

        // Lưu âm lượng vào PlayerPrefs để giữ lại giữa các phiên chơi
        PlayerPrefs.SetFloat("GameVolume", volume);
    }
}
