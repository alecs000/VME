 using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Game.Scripts.Minigames.SocialDepartmentLogic
{
    public class SocialDepartment : UIState
    {
        [SerializeField] private PanelRotateService panelRotateService;
        [SerializeField] private SocialDepartmentDecisionSO[] decisions;
        [SerializeField] private TMP_Text titleText;
        [SerializeField] private TMP_Text descriptionText;
        [SerializeField] private Coins coins;
        [SerializeField] private Reputation reputation;
        [SerializeField] private People people;
        [SerializeField] private int startCoinsAmount;
        [SerializeField] private int startPeopleAmount;

        [SerializeField] private VisualNovel visualNovel;
        [SerializeField] private DialogSO startDialog;
        [SerializeField] private DialogSO loseMoneyDialog;
        [SerializeField] private DialogSO losePeopleDialog;
        [SerializeField] private DialogSO winDialog;

        [SerializeField] private StateChanger stateChanger;
        [SerializeField] private State nextState;
        [SerializeField] private AddedAnimation addedAnimation;

        private int _id;
        private void Start()
        {
            panelRotateService.OnEndRotation += DoDecision;
            coins.Add(startCoinsAmount);
            people.Add(startPeopleAmount);
        }
        private void DoDecision(bool result)
        {
            Reward reward = result ? decisions[_id].RewardsCancel : decisions[_id].RewardOk;
            AddReward(reward);
            panelRotateService.InitializeNewDecision();
            _id++;
            if (coins.Value < 0)
            {
                visualNovel.StartNovel(loseMoneyDialog, StartMiniGame, true);
                panelRotateService.Stop();
            }
            else if(people.Value < 0)
            {
                visualNovel.StartNovel(losePeopleDialog, StartMiniGame, true);
                panelRotateService.Stop();
            }
            else if(_id >= decisions.Length)
            {
                visualNovel.StartNovel(winDialog,()=> stateChanger.EnterState(nextState), true);
                panelRotateService.Stop();
                return;
            }
            ShowDecision(_id);

        }
        private void AddReward(Reward reward)
        {
            if (reward.Coins != 0)
            {

                coins.Add(reward.Coins);
            }
            reputation.Add(reward.Reputation);
            people.Add(reward.PeopleAmount);
        }
        public async override Task Enter()
        {
            StartMiniGame();
            await base.Enter();
        }
        private void StartMiniGame()
        {
            ShowDecision(0);
            panelRotateService.InitializeNewDecision();
        }
        private void ShowDecision(int decisionId)
        {
            titleText.text = decisions[decisionId].Title;
            descriptionText.text = decisions[decisionId].Description;
        }
        public override void Exit()
        {
            base.Exit();
        }
    }

}