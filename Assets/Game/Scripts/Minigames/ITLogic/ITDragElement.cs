using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public delegate ITDropElement UpDragElement(ITDragElement DragElement, PointerEventData eventData);
public class ITDragElement : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public UpDragElement UpElement;
    [SerializeField] private Image imageToDrag;
    [SerializeField] private RectTransform element;
    [SerializeField] private float duration;

    private Vector2 _startPosition;
    private RectTransform _transformToDrag;
    private IT _it;
    private Canvas _canvas;
    private void Start()
    {
        _transformToDrag = imageToDrag.rectTransform;
        _startPosition = _transformToDrag.anchoredPosition;
    }
    public void Set(Sprite sprite, IT it, Canvas canvas)
    {
        imageToDrag.sprite = sprite;
        _it = it;
        _canvas = canvas;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        imageToDrag.raycastTarget = false;
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(element, eventData.position, eventData.pressEventCamera, out localPoint);
        _transformToDrag.anchoredPosition = localPoint;
        _transformToDrag.DOSizeDelta(_it.ITElements[this].RectTransform.sizeDelta, duration);
    }
    public void OnDrag(PointerEventData eventData)
    {
        _transformToDrag.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ITDropElement dropElement = UpElement(this, eventData);
        if (dropElement == null)
        {
            _transformToDrag.DOAnchorPos(_startPosition, duration);
            return;
        }
        _transformToDrag.SetParent(dropElement.transform);
        _transformToDrag.DOAnchorPos(Vector2.zero, duration);
    }
}
