using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ClickablePanel : MonoBehaviour, IPointerUpHandler
{
    public event UnityAction Click;
    public void OnPointerUp(PointerEventData eventData)
    {
        Click?.Invoke();
    }
}
