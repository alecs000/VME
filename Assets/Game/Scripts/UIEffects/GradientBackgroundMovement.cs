using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradientBackgroundMovement : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private Vector2 maxPosition;
    [SerializeField] private Vector2 minPosition;
    [SerializeField] private int duration;
    private void Start()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(rectTransform.DOAnchorPos(maxPosition, duration));
        sequence.Append(rectTransform.DOAnchorPos(minPosition, duration));
        sequence.SetLoops(duration - 1);
        sequence.SetEase(Ease.InBounce);
    }
}
