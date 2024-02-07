using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryGame : MonoBehaviour
{
    public GameObject panelHome;
    void Start()
    {
        if (PlayerPrefs.GetInt("DisableStory", 0) == 1) 
        {
            gameObject.SetActive(false);
            panelHome.SetActive(true);
        }
        else StartCoroutine(Story());
    }

    IEnumerator Story() 
    {
        panelHome.SetActive(false);
        gameObject.SetActive(true);
        yield return new WaitForSeconds(10.5f);
        gameObject.SetActive(false);
        panelHome.SetActive(true);
        PlayerPrefs.SetInt("DisableStory", 1);
    }
}
