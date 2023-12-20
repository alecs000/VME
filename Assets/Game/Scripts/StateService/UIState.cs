using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class UIState : State
{
    [SerializeField] private UISwitchService[] uISwitchServices;
    [SerializeField] private int amountStaticsTransforms;
    private Task[] tasks;
    public override async Task Enter()
    {
        gameObject.SetActive(true);
        transform.SetSiblingIndex(transform.parent.childCount- amountStaticsTransforms);
        Task[] tasks = new Task[uISwitchServices.Length];
        for (int i = 0; i < uISwitchServices.Length; i++)
        {
            tasks[i] = uISwitchServices[i].Appear();
        }
        await Task.WhenAll(tasks);
        await base.Enter();

    }

    public override void Exit()
    {
        foreach (var service in uISwitchServices)
        {
            service.Disappear();
        }
        gameObject.SetActive(false);
    }
}
