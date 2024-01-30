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
    private float _clicksAmount;
    private int _curentGoalNumber;
    private float _amountToAdd = 1;
    public async override Task Enter()
    {
        clickablePanel.Deactivate();
        visualNovel.StartNovel(dialogSO, OnCompleteStartDialog);
        await base.Enter();
    }
    public void OnCompleteStartDialog()
    {
        clickablePanel.Click += OnClick;
        jobsButton.onClick.AddListener(jobsView.Activate);
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
        _clicksAmount+= _amountToAdd;
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
            jobsView.Activate();
        }
        else
        {
            IsFinished = true;
            stateChanger.EnterState(state);
        }
    }

}
