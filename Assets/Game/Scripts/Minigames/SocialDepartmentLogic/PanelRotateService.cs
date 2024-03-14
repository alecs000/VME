using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Game.Scripts.Minigames.SocialDepartmentLogic
{
    public class PanelRotateService : MonoBehaviour
    {
        public event UnityAction<bool> OnEndRotation;
        [SerializeField] private Image underImageCansel;
        [SerializeField] private Image underImageOk;

        [SerializeField] private Transform rotatePoint;
        [SerializeField] private SwipeInput swipeInput;
        [SerializeField] private float speed;
        [SerializeField] private float swipeAngle;
        [SerializeField] private float maxAngle;
        [SerializeField] private float durationBack;


        private Tween _rotateBackTween;
        private bool _isGameStarted;
        private void Start()
        {
            swipeInput.OnDrag += Rotate;
            swipeInput.OnEnd += EndRotation;
        }
        public void InitializeNewDecision()
        {
            _rotateBackTween = rotatePoint.DORotate(Vector3.zero, durationBack / 2);
            _isGameStarted = true;
        }
        public void Stop()
        {
            _isGameStarted = false;
        }
        private void EndRotation()
        {
            if (!_isGameStarted)
                return;
            float currentRotationAngle = rotatePoint.eulerAngles.z > 180 ? rotatePoint.eulerAngles.z - 360 : rotatePoint.eulerAngles.z;
            if (Math.Abs(currentRotationAngle) < swipeAngle)
            {
                _rotateBackTween = rotatePoint.DORotate(Vector3.zero, durationBack);
            }
            else
            {
                OnEndRotation?.Invoke(currentRotationAngle > 0);
            }
        }

        private void Rotate(Vector2 direction)
        {
            if (!_isGameStarted)
                return;
            _rotateBackTween.Kill();
            float currentRotationAngle = rotatePoint.eulerAngles.z > 180 ? rotatePoint.eulerAngles.z - 360 : rotatePoint.eulerAngles.z;

            bool isMaxRotation = currentRotationAngle >= maxAngle && direction.x > 0;
            bool isMinRotation = currentRotationAngle <= -maxAngle && direction.x < 0;

            if (isMaxRotation)
            {
                rotatePoint.eulerAngles = new Vector3(0, 0, maxAngle);
                return;
            }
            else if (isMinRotation)
            {
                rotatePoint.eulerAngles = new Vector3(0, 0, -maxAngle);
                return;
            }
            bool isRightRotation = currentRotationAngle < 0;
            underImageOk.gameObject.SetActive(isRightRotation);
            underImageCansel.gameObject.SetActive(!isRightRotation);
            rotatePoint.Rotate(new Vector3(0, 0, direction.x * speed) * Time.deltaTime);
        }
    }
}