using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class FadeUIService : UISwitchService
{
    [SerializeField] private Image image; 
    [SerializeField] private float duration; 
    public async override Task Appear()
    {
        image.gameObject.SetActive(true);
        Tween tween = image.DOFade(1, duration);
        await tween.AsyncWaitForKill();
    }

    public override void Disappear()
    {
        image.gameObject.SetActive(false);
        image.color = new Color(image.color.r, image.color.g, image.color.b,0);
    }

}
