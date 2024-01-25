using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAnimatedPanel : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float duration;
    public void Appear()
    {
        canvasGroup.gameObject.SetActive(true);
        canvasGroup.DOFade(1, duration);
    }
    public void Disappear()
    {
        canvasGroup.DOFade(0, duration).OnKill(()=> canvasGroup.gameObject.SetActive(false));
    }
}
