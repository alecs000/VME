using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UnlockAnimation : MonoBehaviour
{
    [SerializeField] private RectTransform lockUp;
    [SerializeField] private RectTransform lockDown;
    [SerializeField] private Vector2 uppPosition;
    [SerializeField] private Vector2 downPosition;
    [SerializeField] private CanvasGroup lockPanel;
    [SerializeField] private float duration;

    [SerializeField] private Image lockUpImage;
    [SerializeField] private Sprite lockUpSprite;

    public void Unlock(UnityAction onComplete)
    {
        lockUpImage.sprite = lockUpSprite;
        lockUp.DOAnchorPos(uppPosition, duration);
        lockDown.DOAnchorPos(downPosition, duration);
        lockPanel.DOFade(0, duration).SetDelay(duration).OnKill(()=>onComplete?.Invoke());
    }
}
