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
        [SerializeField] private SocialDepartmentDecisionSO[] desisions;
        [SerializeField] private TMP_Text titleText;
        [SerializeField] private TMP_Text descriptionText;
        private void Start()
        {
            panelRotateService.OnEndRotation += DoDecision;
        }
        private void DoDecision(bool result)
        {
            
        }
        public async override Task Enter()
        {
            titleText.text = desisions[0].Title;
            descriptionText.text = desisions[0].Description;
            panelRotateService.InitializeNewDicision(desisions[0]);
            await base.Enter();
        }
        public override void Exit()
        {
            base.Exit();
        }
    }

}