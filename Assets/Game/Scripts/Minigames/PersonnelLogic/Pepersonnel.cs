using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Pepersonnel : UIState
{
    [SerializeField] private VisualNovel visualNovel; 
    [SerializeField] private DialogSO dialogSO; 
    [SerializeField] private ClickablePanel clickablePanel;
    [SerializeField] private ProgressBar progressBar;
    [SerializeField] private int[] goals;
    private int _allClicksAmount;
    private int _curentGoalNumber;
    public async override Task Enter()
    {
        await base.Enter();
        visualNovel.StartNovel(dialogSO, OnCompleteStartDialog);
    }
    public void OnCompleteStartDialog()
    {
        clickablePanel.Click += OnClick;
    }
    private void OnClick()
    {
        _allClicksAmount++;
        if(_allClicksAmount< goals[_curentGoalNumber])
        {
            progressBar.Move(_allClicksAmount / goals[_curentGoalNumber]);
        }
    }
}
