using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickablePanel : MonoBehaviour, IPointerUpHandler
{
    public event UnityAction Click;
    [SerializeField] private RectTransform clickedImage;
    [SerializeField] private float maxScale;
    [SerializeField] private float duration;
    [SerializeField] private Button button;
    [SerializeField] private Personnel Personnel;
    private Sequence maximizeSequnce;
    public void Activate()
    {
        button.enabled = true;
    }
    public void Deactivate()
    {
        button.enabled = false;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (Personnel.IsFinished)
        {
            return;
        }
        ClickPanel();
    }
    public void ClickPanel()
    {
        Click?.Invoke();
        maximizeSequnce.Kill();
        maximizeSequnce = DOTween.Sequence();
        maximizeSequnce.Append(clickedImage.DOScale(maxScale, duration));
        maximizeSequnce.Append(clickedImage.DOScale(1, duration));
        maximizeSequnce.Play();
    }
}
