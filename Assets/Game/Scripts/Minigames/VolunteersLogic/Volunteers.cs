using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Volunteers : State
{
    [SerializeField] private DialogSO dialogStart;
    [SerializeField] private VisualNovel visualNovel;


    [SerializeField] private WoodenStick[] sticks;
    [SerializeField] private TMP_Text amountText;
    [SerializeField] private CanvasGroup stickAmount;
    [SerializeField] private GameObject ui;
    [SerializeField] private CameraMovement cameraMovement;
    [SerializeField] private int sticksToCollect = 3;
    [SerializeField] private WoodenFire woodenFire;
    [SerializeField] private GameObject invisibleWall;
    [SerializeField] private AppleGame appleGame;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private GameObject game;

    private int _collectedAmount;
    private bool _isTextAmountActivated;
    private bool _isGameStarted;
    public bool IsSticksCollected => _collectedAmount >= sticksToCollect;
    private void Start()
    {
        for (int i = 0; i < sticks.Length; i++)
        {
            sticks[i].CollectStick += OnCollected;
        }
        woodenFire.OnCompleted += CompleteFireQuest;
    }
    private void CompleteFireQuest()
    {
        invisibleWall.SetActive(false);
        stickAmount.DOFade(0, 1);
    }
    public override async Task Enter()
    {
        await base.Enter();
        for (int i = 0; i < sticks.Length; i++)
        {
            sticks[i].gameObject.SetActive(true);
        }
        gameObject.SetActive(true);
        ui.SetActive(true);
        cameraMovement.enabled = true;
        appleGame.gameObject.SetActive(false);
        _collectedAmount = 0;
        game.SetActive(true);
        _isTextAmountActivated = false;
        visualNovel.StartNovel(dialogStart, null, true);
        stickAmount.gameObject.SetActive(false);
        if (_isGameStarted)
        {
            playerMovement.ResetPlayer();
            woodenFire.ResetFire();
        }
        _isGameStarted = true;
    }
    public override void Exit()
    {
        gameObject.SetActive(false);
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
