using UnityEngine;
using UnityEngine.Events;

namespace Assets.Game.Scripts.Minigames.SocialDepartmentLogic
{
    public class SwipeInput : MonoBehaviour
    {
        public event UnityAction<Vector2> OnDrag;
        public event UnityAction OnEnd;

        private Vector2 _lastPosition;
        private void Update()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        _lastPosition = touch.position;
                        break;
                    case TouchPhase.Moved:
                        OnDrag?.Invoke(_lastPosition - touch.position);
                        _lastPosition = touch.position;
                        break;
                    case TouchPhase.Ended:
                        OnEnd?.Invoke();
                        break;

                }
            }
        }
    }
}