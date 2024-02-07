using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PanelAnimation : MonoBehaviour
{
    public float startY;
    public float delay;
    public static bool isAnimation = false;
    private void Update()
    {
        if (gameObject.activeSelf == true && isAnimation == false) 
        {
            Show();
            isAnimation = true;
        }
    }
    public void Show() 
    {
        transform.DOMoveY(transform.position.y, 1).From(startY).SetEase(Ease.OutBack).SetDelay(delay);
    }
}
