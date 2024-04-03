using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationState : UIState
{
    [SerializeField] private Button website;
    [SerializeField] private Button vk;
    [SerializeField] private string websiteUrl;
    [SerializeField] private string vkUrl;
    [SerializeField] private Logo logo;
    [SerializeField] private RectTransform logoPosition;
    [SerializeField] private float duration;


    private void Start()
    {
        website.onClick.AddListener(() => Application.OpenURL(websiteUrl));
        vk.onClick.AddListener(() => Application.OpenURL(vkUrl));
        logo.gameObject.SetActive(true);
        logo.CanvasGroup.alpha = 0f;
        logo.BackRectTransform.anchoredPosition = logoPosition.anchoredPosition;
        logo.CanvasGroup.DOFade(1, duration/2);
        logo.BackRectTransform.transform.DORotate(new Vector3(0, 0, 0), duration);
        logo.BackRectTransform.transform.DOScale(1, duration);
    }
}
