using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddedAnimation : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private float duration;
    [SerializeField] private float startPosition;
    [SerializeField] private float endPosition;

    public void Show(int amount)
    {
        gameObject.SetActive(true);
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, startPosition);

        string sign = amount > 0 ? "+" : "";
        text.text = $"{sign}{amount}";
        canvasGroup.DOFade(1, duration/2);
        rectTransform.DOAnchorPosY(endPosition, duration);
        canvasGroup.DOFade(0, duration / 2).SetDelay(duration);
    }
}
