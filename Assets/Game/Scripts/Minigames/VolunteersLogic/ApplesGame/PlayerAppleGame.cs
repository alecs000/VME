using Codice.CM.Common;
using log4net.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAppleGame : MonoBehaviour
{
    [SerializeField] private AppleMoveButton left;
    [SerializeField] private AppleMoveButton right;
    [SerializeField] private AppleGame appleGame;
    [SerializeField] private Rigidbody2D player;
    [SerializeField] private float speed;
    [SerializeField] private Vector2 borders;
    private Vector2 _direction;
    private void Start()
    {
        left.Clicked += Move;
        right.Clicked += Move;
    }
    public void AddApple(int amount)
    {
        appleGame.AddApple(amount);
    }
    private void Move(Vector2 direction)
    {
        _direction = direction;
    }
    private void FixedUpdate()
    {
        if (!left.IsClicked && !right.IsClicked)
            return;
        if (transform.position.x < borders.x && left.IsClicked)
            return;
        if (transform.position.x > borders.y && right.IsClicked)
            return;
        player.MovePosition(player.position + _direction * speed * Time.fixedDeltaTime);

    }
}