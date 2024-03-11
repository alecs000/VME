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
            coins.Add(reward.Coins);
            reputation.Add(reward.Reputation);
            people.Add(reward.PeopleAmount);
            panelRotateService.InitializeNewDecision();
            _id++;
            titleText.text = decisions[_id].Title;
            descriptionText.text = decisions[_id].Description;
        }
        public async override Task Enter()
        {
            titleText.text = decisions[0].Title;
            descriptionText.text = decisions[0].Description;
            panelRotateService.InitializeNewDecision();
            await base.Enter();
        }
        public override void Exit()
        {
            base.Exit();
        }
    }

}