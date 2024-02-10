using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class VisualNovel : MonoBehaviour
{
    [SerializeField] private Logo logo;
    [SerializeField] private float disappearDuration;
    [SerializeField] private Transform logoPosotion;
    [SerializeField] private DialogUI dialogUI;
    [SerializeField] private Image background;
    Sequence sequence;
    public void StartNovel(DialogSO dialog, UnityAction onComplete, bool autoFadeLogo = false)
    {
        background.gameObject.SetActive(true);
        TeleportLogoToNpvelPoint();
        if (autoFadeLogo)
        {
            onComplete+= ()=> logo.CanvasGroup.DOFade(0, 0.5f);
        }
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
            logo.transform.position = logoPosotion.position;
            logo.CanvasGroup.DOFade(1, disappearDuration);
            logo.BackRectTransform.transform.DOScale(1, disappearDuration);
            logo.BackRectTransform.transform.DORotate(new Vector3(0, 0, 0), disappearDuration);
            return;
        }
        sequence.onComplete += () =>
        {
            logo.transform.position = logoPosotion.position;
            sequence.PlayBackwards();
        };
    }
}
