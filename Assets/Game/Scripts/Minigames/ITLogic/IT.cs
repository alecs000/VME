using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IT : UIState
{
    [SerializeField] private ITDragElement[] dragElements;
    [SerializeField] private ITDropElement[] dropElements;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private Canvas canvas;
    private Dictionary<ITDragElement, ITDropElement> _itElements;
    public Dictionary<ITDragElement, ITDropElement> ITElements => _itElements;
    private int _completedItem;
    private void Start()
    {
        _itElements = new Dictionary<ITDragElement, ITDropElement>();
        for (int i = 0; i < dragElements.Length; i++)
        {
            _itElements.Add(dragElements[i], dropElements[i]);
            dragElements[i].UpElement = UpElement;
            dragElements[i].Set(sprites[i], this, canvas);
        }    
    }
    private ITDropElement UpElement(ITDragElement iTDragElement, PointerEventData eventData)
    {
        GameObject clickedObject = eventData.pointerCurrentRaycast.gameObject;
        if(clickedObject.TryGetComponent(out ITDropElement dropElement))
        {
            if(_itElements[iTDragElement]== dropElement)
            {
                _completedItem++;
                if (_completedItem == sprites.Length-1)
                {

                }

                return dropElement;
            }
        }
        return null;
    }
}
