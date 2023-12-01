using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PopupEnterUIService : UISwitchService
{
    [SerializeField] private float duration;

    public override async Task Appear()
    {
        transform.localScale = new Vector3 (0f, 1f, 1f);
        Tween tween = transform.DOScaleX(1, duration);
        await tween.AsyncWaitForKill();
    }

    public override void Disappear()
    {
        gameObject.SetActive(false);
    }

}
