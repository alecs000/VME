using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody player;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private float speed;
    [SerializeField] private float duration;
    private bool _isMoveInPortal;
    private Transform _portal;
    public void MoveInPortal(Transform portal)
    {
        _portal = portal;
        _isMoveInPortal = true;
        transform.DOMove(_portal.position, duration).OnKill(()=>Debug.Log("1"));
        transform.DOScale(0f, duration);
        transform.LookAt(_portal);
    }
    private void FixedUpdate()
    {
        if (_isMoveInPortal)
            return;
        Vector2 directionJoystick = new Vector2(SimpleInput.GetAxis("Vertical"), -SimpleInput.GetAxis("Horizontal"));
        Vector3 direction = new Vector3(directionJoystick.x, 0, directionJoystick.y);
        player.MovePosition(transform.position + direction * Time.fixedDeltaTime * speed);
        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 10f);
            playerAnimator.SetBool("Run", true);
        }
        else
        {
            playerAnimator.SetBool("Run", false);
        }
    }
}
