using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffIntro : MonoBehaviour
{
    public GameObject introPanel;
    public GameObject loadingPanel;
    void Start()
    {
        if (introPanel && loadingPanel)
        {
            loadingPanel.SetActive(false);
            introPanel.SetActive(true);
            StartCoroutine(OffIntroPanel());
        }     
    }
    private IEnumerator OffIntroPanel() 
    {
        yield return new WaitForSeconds(5.5f);
        introPanel.SetActive(false);
        loadingPanel.SetActive(true);
    }
}
