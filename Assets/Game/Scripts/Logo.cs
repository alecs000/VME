using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Logo : MonoBehaviour
{
    [SerializeField] private Image backImage;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private RectTransform backRectTransform;
    public Image BackImage=>backImage;
    public CanvasGroup CanvasGroup => canvasGroup;
    public RectTransform BackRectTransform =>backRectTransform;
}
