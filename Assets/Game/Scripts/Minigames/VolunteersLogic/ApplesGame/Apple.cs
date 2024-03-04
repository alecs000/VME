using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class Apple : MonoBehaviour
{
    [SerializeField] private int amount;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D apple;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerAppleGame player))
        {
            player.AddApple(amount);
            gameObject.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        apple.MovePosition(new Vector2(transform.position.x, transform.position.y) + Vector2.down * Time.fixedDeltaTime * speed);
    }
}
