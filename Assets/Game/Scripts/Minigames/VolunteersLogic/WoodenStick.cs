using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WoodenStick : MonoBehaviour
{
    public event UnityAction CollectStick;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PlayerMovement playerMovement))
        {
            CollectStick?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
