using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingButton : MonoBehaviour
{
    public GameObject panel;
    public GameObject canvasPlay;
    public bool isPauseGame = true;
    void Start()
    {
        panel.SetActive(false);
    }
    public void OnClick()
    {
        if (panel.activeSelf)
        {
            if (isPauseGame == true)
            {
                PlayerPrefs.DeleteKey("PauseGame");
            }
            panel.SetActive(false);
            PanelAnimation.isAnimation = false;
            if (canvasPlay)
            {
                canvasPlay.SetActive(true);
            }
        }
        else
        {
            if (isPauseGame == true)
            {
                PlayerPrefs.SetInt("PauseGame", 1);
            }
            panel.SetActive(true);
            if (canvasPlay)
            {
                canvasPlay.SetActive(false);
            }            
        }
    }
}
