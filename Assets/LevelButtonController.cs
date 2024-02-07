using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonController : MonoBehaviour
{
    public Button[] levelButtons;
    public Material blackAndWhiteMaterial;

    void Start()
    {
        //PlayerPrefs.DeleteAll();
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (PlayerPrefs.GetInt("Level"+(i+2)+"Unlocked", 0) == 1) 
            {
                levelButtons[i].interactable = true;
            }
            else
            {
                levelButtons[i].interactable = false;
                if (!levelButtons[i].interactable && levelButtons[i])
                {
                    Image buttonImage = levelButtons[i].GetComponent<Image>();

                    // Kiểm tra xem có thể nhận diện được component Image hay không
                    if (buttonImage != null)
                    {
                        // Áp dụng vật liệu mới vào component Image
                        buttonImage.material = blackAndWhiteMaterial;
                    }
                }
            }
        }
    }
}
