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
        [SerializeField] private int startCoinsValue;
        [SerializeField] private int startPeopleValue;
        [SerializeField] private int startReputationValue;
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
        [SerializeField] private AddedAnimation addedCoinsAnimation;
        [SerializeField] private AddedAnimation addedPeopleAnimation;
        [SerializeField] private AddedAnimation addedReputationAnimation;


        private int _id;
        private void Start()
        {
            panelRotateService.OnEndRotation += DoDecision;
            coins.Add(startCoinsAmount);
            people.Add(startPeopleAmount);
            visualNovel.StartNovel(startDialog, StartMiniGame, true);
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
                visualNovel.StartNovel(winDialog,()=> stateChanger.EnterState(nextState));
                panelRotateService.Stop();
                return;
            }
            ShowDecision(_id);

        }
        private void AddReward(Reward reward)
        {
            if (reward.Coins != 0)
            {
                addedCoinsAnimation.Show(reward.Coins);
                coins.Add(reward.Coins);
            }
            if (reward.Reputation != 0)
            {
                addedReputationAnimation.Show(reward.Reputation);
                reputation.Add(reward.Reputation);
            }
            if (reward.PeopleAmount != 0)
            {
                addedPeopleAnimation.Show(reward.PeopleAmount);
                people.Add(reward.PeopleAmount);
            }
        }
        public async override Task Enter()
        {
            await base.Enter();
        }
        private void StartMiniGame()
        {
            _id = 0;           
            ShowDecision(0);
            panelRotateService.InitializeNewDecision();
            coins.SetValue(startCoinsValue);
            people.SetValue(startPeopleAmount);
            reputation.SetValue(startReputationValue);
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