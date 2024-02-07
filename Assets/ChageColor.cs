using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChageColor : MonoBehaviour
{
    private Color originalColor;
    void Start()
    {
        originalColor = GetComponent<SpriteRenderer>().color;
    }

    public void ChangeColorIfTrigger()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red;
    }

    public void ChangeColorIfNoTrigger()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = originalColor;
    }
}
