using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D player;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private float speed;
    private Vector2 _direction;
    private Vector2 _startPosition;
    private void Start()
    {
        _startPosition = player.transform.position ;
    }
    public void ResetPlayer()
    {
        player.transform.position = _startPosition;
    }
    private void Update()
    {
        _direction = new Vector2(SimpleInput.GetAxis("Horizontal"), SimpleInput.GetAxis("Vertical"));
        playerAnimator.SetFloat("Speed", _direction.magnitude);
        playerAnimator.SetFloat("Hor", _direction.x);
        playerAnimator.SetFloat("Ver", _direction.y);
    }
    private void FixedUpdate()
    {
        player.MovePosition(player.position + _direction * speed * Time.fixedDeltaTime);
    }
}
