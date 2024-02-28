using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class AppleMoveButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public event UnityAction<Vector2> Clicked;
    [SerializeField] private Vector2 direction;
    private bool _isClicked;
    public bool IsClicked => _isClicked;
    public void OnPointerDown(PointerEventData eventData)
    {
        _isClicked = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isClicked = false;
    }
    private void Update()
    {
        if (_isClicked)
        {
            Clicked?.Invoke(direction);
        }
    }
}
