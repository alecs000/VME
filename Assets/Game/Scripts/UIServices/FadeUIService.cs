using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class FadeUIService : UISwitchService
{
    [SerializeField] private CanvasGroup group; 
    [SerializeField] private float duration; 
    public async override Task Appear()
    {
        group.alpha = 0;
        group.gameObject.SetActive(true);
        Tween tween = group.DOFade(1, duration);
        await tween.AsyncWaitForKill();
    }

    public override void Disappear()
    {
        group.gameObject.SetActive(false);
    }

}
