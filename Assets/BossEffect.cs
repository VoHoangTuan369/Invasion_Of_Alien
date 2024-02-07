using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEffect : MonoBehaviour
{
    public GameObject effectPanel;
    void Start()
    {
        StartCoroutine(EffectOfBoss());
    }
    private IEnumerator EffectOfBoss()
    {
        if (effectPanel)
        {
            effectPanel.SetActive(true);
            PlayerPrefs.SetInt("PauseGame", 1);
            yield return new WaitForSeconds(3.2f);
            effectPanel.SetActive(false);
            PlayerPrefs.DeleteKey("PauseGame");
        }
    }
}
