using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Pepersonnel : UIState
{
    [SerializeField] private VisualNovel visualNovel; 
    [SerializeField] private DialogSO dialogSO; 
    [SerializeField] private ClickablePanel clickablePanel;
    [SerializeField] private ProgressBar progressBar;
    [SerializeField] private Button jobsButton;
    [SerializeField] private JobsView jobsView;
    [SerializeField] private int[] goals;
    private int _clicksAmount;
    private int _curentGoalNumber;
    public async override Task Enter()
    {
        clickablePanel.Deactivate();
        await base.Enter();
        visualNovel.StartNovel(dialogSO, OnCompleteStartDialog);
    }
    public void OnCompleteStartDialog()
    {
        clickablePanel.Click += OnClick;
        jobsButton.onClick.AddListener(jobsView.Activate);
        clickablePanel.Activate();
    }
    private void OnClick()
    {
        _clicksAmount++;
        if(_clicksAmount < goals[_curentGoalNumber])
        {
            progressBar.Move((float)_clicksAmount / goals[_curentGoalNumber]);
        }
        else if(_curentGoalNumber+1< goals.Length)
        {
            _curentGoalNumber++;
            progressBar.Move(0);
            _clicksAmount = 0;
        }
        else
        {

        }
    }
}
