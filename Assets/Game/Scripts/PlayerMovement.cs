using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D player;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private float speed;
    private Vector2 direction;
    private void Update()
    {
        direction = new Vector2(SimpleInput.GetAxis("Horizontal"), SimpleInput.GetAxis("Vertical"));
        playerAnimator.SetFloat("Speed", direction.magnitude);
        playerAnimator.SetFloat("Hor", direction.x);
        playerAnimator.SetFloat("Ver", direction.y);
    }
    private void FixedUpdate()
    {
        player.MovePosition(player.position + direction * speed * Time.fixedDeltaTime);
    }
}
