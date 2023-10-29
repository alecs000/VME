using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class UIState : State
{
    [SerializeField] private UISwitchService[] uISwitchServices;

    public override async Task Enter()
    {
        Task[] tasks = new Task[uISwitchServices.Length];
        for (int i = 0; i < uISwitchServices.Length; i++)
        {
            tasks[i] = uISwitchServices[i].Appear();
        }
        await Task.WhenAll(tasks);
    }

    public override void Exit()
    {
        foreach (var service in uISwitchServices)
        {
            service.Disappear();
        }
    }
}
