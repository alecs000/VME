using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Personnel : UIState
{
    [HideInInspector]
    public bool IsFinished;
    [SerializeField] private VisualNovel visualNovel; 
    [SerializeField] private DialogSO dialogSO; 
    [SerializeField] private ClickablePanel clickablePanel;
    [SerializeField] private ProgressBar progressBar;
    [SerializeField] private Button jobsButton;
    [SerializeField] private JobsView jobsView;
    [SerializeField] private PeopleAmount peopleAmount;
    [SerializeField] private StateChanger stateChanger; 
    [SerializeField] private State state;
    [SerializeField] private float[] goals;
    [SerializeField] private DialogSO endDialogSO;
    [SerializeField] private ClickerUpgrader clickerUpgrader;

    private float _clicksAmount;
    private int _curentGoalNumber;
    private float _amountToAdd = 1;
    private bool  _isFirstTime = true;
    public async override Task Enter()
    {
        transform.parent.gameObject.SetActive(true);
        clickablePanel.Deactivate();
        ResetPersonnelGame();
        visualNovel.StartNovel(dialogSO, OnCompleteStartDialog, true);
        await base.Enter();
    }
    public override void Exit()
    {
        base.Exit();
        transform.parent.gameObject.SetActive(false);
    }
    public void OnCompleteStartDialog()
    {
        if (_isFirstTime)
        {

            clickablePanel.Click += OnClick;
            jobsButton.onClick.AddListener(jobsView.Activate);
            _isFirstTime = false;
        }
        clickablePanel.Activate();
    }
    public void UpgradeAmountToAdd()
    {
        _amountToAdd = 1.2f;
    }
    public void UpgradeHundred()
    {

        _clicksAmount += 100;
        OnClick();
    }
    private void OnClick()
    {
        if (IsFinished)
        {
            return;
        }
        _clicksAmount += _amountToAdd;
        if(_clicksAmount < goals[_curentGoalNumber])
        {
            progressBar.Move((float)_clicksAmount / goals[_curentGoalNumber]);
        }
        else if(_curentGoalNumber+1< goals.Length)
        {
            _curentGoalNumber++;
            progressBar.Move(0);
            _clicksAmount = 0;
            peopleAmount.Add(1);
            // jobsView.Activate(); //Активирует jobsView, но случайныое нажатие прокачивает что-то
        }
        else
        {
            IsFinished = true;
            visualNovel.StartNovel(endDialogSO, ()=> stateChanger.EnterState(state), true);
        }
    }
    public void ResetPersonnelGame()
    {
        _amountToAdd = 1;
        _clicksAmount = 0;
        _curentGoalNumber = 0;
        progressBar.Move(0);
        IsFinished = false;
        clickerUpgrader.ResetUpgrades();
    }
}
