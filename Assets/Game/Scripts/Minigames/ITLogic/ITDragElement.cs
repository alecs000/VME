using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public delegate Vector2 UpDragElement(ITDragElement DragElement);
public class ITDragElement : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public UpDragElement UpElement;
    [SerializeField] private Image imageToDrag;
    [SerializeField] private RectTransform element;
    [SerializeField] private Canvas canvas;

    private RectTransform _transformToDrag;
    private void Start()
    {
        _transformToDrag = imageToDrag.rectTransform;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        imageToDrag.raycastTarget = false;
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(element, eventData.position, eventData.pressEventCamera, out localPoint);
        _transformToDrag.anchoredPosition = localPoint;
    }
    public void OnDrag(PointerEventData eventData)
    {
        print(eventData.delta);
        print(eventData.delta / canvas.scaleFactor);
        _transformToDrag.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }
}
