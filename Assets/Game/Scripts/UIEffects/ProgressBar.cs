using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Vector2 startPosition;
    [SerializeField] private Vector2 finishPosition;
    [SerializeField] private RectTransform fill;
    [SerializeField] private float duration;

    public void Move(float value)
    {
        Vector2 moveToPosition = Vector2.Lerp(startPosition, finishPosition, value);
        fill.DOAnchorPos(moveToPosition, duration);
    }
}
