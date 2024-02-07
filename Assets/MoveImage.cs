using UnityEngine;
using UnityEngine.UI;

public class MoveImage : MonoBehaviour
{
    public RectTransform loadingBar;
    public Image imageToMove;
    //public float rotationSpeed;

    private void Start()
    {        
        // Đặt vị trí ban đầu của hình ảnh theo vị trí bên phải của loadingBar
        RectTransform imageTransform = imageToMove.GetComponent<RectTransform>();
        imageTransform.anchoredPosition = new Vector2(loadingBar.rect.width / 2, imageTransform.anchoredPosition.y);
    }

    private void Update()
    {
        // Lấy giá trị fillAmount của loadingBar
        float fillAmount = loadingBar.GetComponent<Image>().fillAmount;

        //imageToMove.rectTransform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);

        // Di chuyển hình ảnh theo điểm bên phải của loadingBar
        RectTransform imageTransform = imageToMove.GetComponent<RectTransform>();
        imageTransform.anchoredPosition = new Vector2(fillAmount * loadingBar.rect.width, imageTransform.anchoredPosition.y);
    }
}