using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompletedPanel : MonoBehaviour
{
    [SerializeField] private Image panelWithText;
    [SerializeField] private Color completeColor;
    [SerializeField] private float duration;

    public void Show()
    {
        panelWithText.DOColor(completeColor, duration);
    }
}
