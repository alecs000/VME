using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Volunteers : State
{
    [SerializeField] private WoodenStick[] sticks;
    [SerializeField] private TMP_Text amountText;
    [SerializeField] private CanvasGroup stickAmount;
    [SerializeField] private GameObject ui;
    [SerializeField] private CameraMovement cameraMovement;
    [SerializeField] private int sticksToCollect = 3;

    private int _collectedAmount;
    private bool _isTextAmountActivated;
    public bool IsSticksCollected => _collectedAmount >= sticksToCollect;
    private void Start()
    {
        for (int i = 0; i < sticks.Length; i++)
        {
            sticks[i].CollectStick += OnCollected;
        }
    }
    public override async Task Enter()
    {
        await base.Enter();
        gameObject.SetActive(true);
        ui.SetActive(true);
        cameraMovement.enabled = true;
    }
    public override void Exit()
    {
    }
    private void OnCollected()
    {
        ActivateTextAmount();
        _collectedAmount++;
        amountText.text = $"{_collectedAmount}/{sticksToCollect}";
    }
    private void ActivateTextAmount()
    {
        if (_isTextAmountActivated) 
            return;
        _isTextAmountActivated = true;
        stickAmount.gameObject.SetActive(true);
        stickAmount.DOFade(1, 1);
    }
}
