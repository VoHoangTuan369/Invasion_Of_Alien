using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnOnHowToPlay : MonoBehaviour
{
    public GameObject homePanel;
    public GameObject howPanel;
    private Color originalHomeColor;
    private void Start()
    {
        if (homePanel) 
        {
            originalHomeColor = homePanel.GetComponent<Image>().color;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (howPanel && howPanel.activeSelf)
        {
            Image imageComponent = homePanel.GetComponent<Image>();
            Color tempColor = imageComponent.color;
            tempColor.a = 0.4f;
            imageComponent.color = tempColor;
        }
        else
        {
            Image imageComponent = homePanel.GetComponent<Image>();
            imageComponent.color = originalHomeColor;
        }
    }
}
