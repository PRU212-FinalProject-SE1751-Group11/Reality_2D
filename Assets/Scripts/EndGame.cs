using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public Text messageText;  // Tham chiếu tới Text UI trên màn hình
    private string message = "Let's Go Home, Anna"; // Thông điệp cần hiển thị
    private float typingSpeed = 0.1f;  // Thời gian giữa mỗi ký tự

    // Start is called before the first frame update
    void Start()
    {
        // Gọi coroutine để thực hiện hiệu ứng typing sau 1 giây
        Invoke("StartTypingEffect", 1f);
    }

    // Bắt đầu hiệu ứng typing sau 1 giây
    void StartTypingEffect()
    {
        StartCoroutine(TypeMessage());
    }

    // Coroutine thực hiện hiệu ứng typing
    IEnumerator TypeMessage()
    {
        messageText.text = "";  // Đảm bảo text ban đầu trống
        foreach (char letter in message)
        {
            messageText.text += letter;  // Thêm từng ký tự vào Text
            yield return new WaitForSeconds(typingSpeed);  // Chờ 1 khoảng thời gian trước khi thêm ký tự tiếp theo
        }

        // Khi typing hoàn tất, gọi lệnh Fade
        Initiate.Fade("Thanksplaying", Color.white, 0.4f);
    }
}
