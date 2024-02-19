using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D player;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private float speed;
    private Vector2 diraction;
    private void Update()
    {
        diraction = new Vector2(SimpleInput.GetAxis("Horizontal"), SimpleInput.GetAxis("Vertical"));
        playerAnimator.SetFloat("Speed", diraction.magnitude);
        playerAnimator.SetFloat("Hor", diraction.x);
        playerAnimator.SetFloat("Ver", diraction.y);
    }
    private void FixedUpdate()
    {
        player.MovePosition(player.position + diraction * speed * Time.fixedDeltaTime);
    }
}
