using System.Collections;
using UnityEngine;
using UnityEngine.UI; // Để sử dụng UI Button

public class WaitingText : MonoBehaviour
{
    public Button yourButton;  // Tham chiếu đến Button mà bạn muốn hiển thị
    private bool isButtonVisible = false;

    // Start is called before the first frame update
    void Start()
    {
        // Ẩn button ngay từ đầu
        yourButton.gameObject.SetActive(false);

        // Gọi hàm để trì hoãn việc hiển thị button
        StartCoroutine(ShowButtonAfterDelay());
    }

    // Coroutine để trì hoãn và hiển thị button sau 2 giây
    IEnumerator ShowButtonAfterDelay()
    {
        // Đợi 2 giây
        yield return new WaitForSeconds(2f);

        // Sau 2 giây, hiện button
        yourButton.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // Cập nhật nếu cần
    }
}
