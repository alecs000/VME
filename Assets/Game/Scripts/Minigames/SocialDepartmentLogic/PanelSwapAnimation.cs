using Assets.Game.Scripts.Minigames.SocialDepartmentLogic;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelSwapAnimation : MonoBehaviour
{
    [SerializeField] private Image panel;
    [SerializeField] private Color colorAgree;
    [SerializeField] private Color colorCancel;
    [SerializeField] private PanelRotateService panelRotateService;

    [SerializeField] private float duration;
    [SerializeField] private float maxScale;

    private void Start()
    {
        panelRotateService.OnEndRotation += ShowEndEffect;
    }
    private void ShowEndEffect(bool isLeft)
    {
        panel.transform.localScale = Vector2.one;
        panel.transform.DOScale(maxScale, duration);
        panel.color = isLeft ? colorCancel : colorAgree;
        panel.DOFade(0, duration);
    }
}
