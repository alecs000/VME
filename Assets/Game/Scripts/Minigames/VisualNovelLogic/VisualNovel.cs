using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VisualNovel : MonoBehaviour
{
    [SerializeField] private Logo logo;
    [SerializeField] private float disappearDuration;
    [SerializeField] private Transform logoPosotion;
    [SerializeField] private DialogUI dialogUI;
    Sequence sequence;
    public void StartNovel(DialogSO dialog, UnityAction onComplete)
    {
        TeleportLogoToNpvelPoint();
        dialogUI.ShowMessage(dialog, 0, onComplete);

    }
    private void TeleportLogoToNpvelPoint()
    {
        sequence = DOTween.Sequence();
        sequence.Append(logo.CanvasGroup.DOFade(0, disappearDuration));
        sequence.Join(logo.BackRectTransform.transform.DORotate(new Vector3(0, 0, 90), disappearDuration));
        sequence.Join(logo.BackRectTransform.transform.DOScale(0, disappearDuration));
        sequence.SetAutoKill(false);
        if(logo.CanvasGroup.alpha ==0)
        {
            sequence.PlayBackwards();
            return;
        }
        sequence.onComplete += () =>
        {
            logo.transform.position = logoPosotion.position;
            sequence.PlayBackwards();
        };
    }
}
