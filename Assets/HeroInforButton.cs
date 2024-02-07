using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroInforButton : MonoBehaviour
{
    public GameObject inforPanel;
    public GameObject collectionPanel;
    public static bool isPanelOpen = false;
    private void Start()
    {
        inforPanel.SetActive(false);
    }
    public void OnCLick() 
    {
        if (inforPanel && inforPanel.activeSelf == false && isPanelOpen == false)
        {
            inforPanel.SetActive(true);
            isPanelOpen = true;
            if (collectionPanel && collectionPanel.activeSelf)
            {
                collectionPanel.SetActive(false);
            }
        }
    }
}
