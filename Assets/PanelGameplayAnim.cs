using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PanelGameplayAnim : MonoBehaviour
{
    public float start;
    public float delay;
    public bool isHeight = false;
    void Start()
    {
        Show();
    }

    // Update is called once per frame
    public void Show()
    {
        if (isHeight == false)
        {
            transform.DOMoveX(transform.position.x, 1).From(start).SetDelay(delay);
        }
        else transform.DOMoveY(transform.position.y, 1).From(start).SetDelay(delay);
    }
}
