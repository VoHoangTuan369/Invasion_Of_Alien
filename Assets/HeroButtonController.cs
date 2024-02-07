using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroButtonController : MonoBehaviour
{
    public Button[] heroButtons;
    public Material blackAndWhiteMaterial;
    private Material[] originalMaterials; // Mảng chứa các vật liệu ban đầu

    private void Start()
    {
        originalMaterials = new Material[heroButtons.Length];
        for (int i = 0; i < heroButtons.Length; i++)
        {
            Image buttonImage = heroButtons[i].GetComponent<Image>();
            if (buttonImage != null)
            {
                originalMaterials[i] = buttonImage.material; // Lưu trữ vật liệu ban đầu vào mảng
            }
        }
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("FireUnlocked") == 1)
        {
            heroButtons[1].interactable = true;
        }
        else
        {
            heroButtons[1].interactable = false;            
        }
        if (PlayerPrefs.GetInt("IceUnlocked", 0) == 1)
        {
            heroButtons[2].interactable = true;
        }
        else
        {
            heroButtons[2].interactable = false;            
        }
        if (PlayerPrefs.GetInt("ThunderUnlocked", 0) == 1)
        {
            heroButtons[3].interactable = true;
        }
        else
        {
            heroButtons[3].interactable = false;            
        }
        if (PlayerPrefs.GetInt("PoisonUnlocked", 0) == 1)
        {
            heroButtons[4].interactable = true;
        }
        else
        {
            heroButtons[4].interactable = false;            
        }
        if (PlayerPrefs.GetInt("AKUnlocked", 0) == 1)
        {
            heroButtons[5].interactable = true;
        }
        else
        {
            heroButtons[5].interactable = false;            
        }
        for (int i = 0; i < heroButtons.Length; i++) 
        {
            if (heroButtons[i]) 
            {
                if (heroButtons[i].interactable)
                {
                    Image buttonImage = heroButtons[i].GetComponent<Image>();
                    if (buttonImage != null)
                    {
                        // Áp dụng vật liệu mới vào component Image
                        buttonImage.material = originalMaterials[i];
                    }
                }
                else 
                {
                    Image buttonImage = heroButtons[i].GetComponent<Image>();

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
