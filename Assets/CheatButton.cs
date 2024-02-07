using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheatButton : MonoBehaviour
{
    public Sprite unLockIM;
    private Sprite lockIM;
    private Image buttonImage;
    private void Start()
    {
        buttonImage = GetComponent<Image>();
        lockIM = buttonImage.sprite;
    }

    public void OnClick()
    {
        if (PlayerPrefs.GetInt("UnLockGame", 0) == 0)
        {
            PlayerPrefs.SetInt("UnLockGame", 1);
        }
        else 
        {
            PlayerPrefs.DeleteAll();
        }
    }
    private void Update()
    {
        if (PlayerPrefs.GetInt("UnLockGame", 0) == 1)
        {
            buttonImage.sprite = unLockIM;
            for (int i = 0; i < 10; i++)
            {
                PlayerPrefs.SetInt("Level" + (i + 1) + "Unlocked", 1);
            }
            PlayerPrefs.SetInt("FireUnlocked", 1);
            PlayerPrefs.SetInt("IceUnlocked", 1);
            PlayerPrefs.SetInt("ThunderUnlocked", 1);
            PlayerPrefs.SetInt("PoisonUnlocked", 1);
            PlayerPrefs.SetInt("AKUnlocked", 1);
        }
        else 
        {
            buttonImage.sprite = lockIM;
        }
    }
}
