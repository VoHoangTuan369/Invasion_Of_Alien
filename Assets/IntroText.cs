using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class IntroText : MonoBehaviour
{
    private Image textIntro;
    private void Start()
    {
        textIntro = GetComponent<Image>();
        // Thực hiện fade in trong 0.5 giây khi start
        textIntro.DOFade(1f, 1f).From(0f);

        // Đợi 2 giây trước khi thực hiện fade out
        StartCoroutine(FadeOutAfterDelay());
    }

    private IEnumerator FadeOutAfterDelay()
    {
        yield return new WaitForSeconds(4f);

        // Thực hiện fade out trong 0.5 giây
        textIntro.DOFade(0f, 0.5f);
    }
}
