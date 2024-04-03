using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

public class IT : UIState
{
    [SerializeField] private ITDragElement[] dragElements;
    [SerializeField] private ITDropElement[] dropElements;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private Canvas canvas;
    [SerializeField] private RectTransform content;
    [SerializeField] private VisualNovel visualNovel;
    [SerializeField] private DialogSO startDialog;
    [SerializeField] private DialogSO endDialog;
    [SerializeField] private StateChanger stateChanger;
    [SerializeField] private State nextState;
    private Dictionary<ITDragElement, ITDropElement> _itElements;
    public Dictionary<ITDragElement, ITDropElement> ITElements => _itElements;
    private int _completedItem;

    public override async Task Enter()
    {
        _completedItem = 0;
       await base.Enter();
        _itElements = new Dictionary<ITDragElement, ITDropElement>();
        for (int i = 0; i < dragElements.Length; i++)
        {
            _itElements.Add(dragElements[i], dropElements[i]);
            dragElements[i].UpElement = UpElement;
            dragElements[i].Set(sprites[i], this, canvas, content);
            dragElements[i].ResetItem();
        }
        visualNovel.StartNovel(startDialog, null, true);
    }
    private ITDropElement UpElement(ITDragElement iTDragElement, PointerEventData eventData)
    {
        GameObject clickedObject = eventData.pointerCurrentRaycast.gameObject;
        if(clickedObject == null)
            return null;
        if(clickedObject.TryGetComponent(out ITDropElement dropElement))
        {
            if(_itElements[iTDragElement]== dropElement)
            {
                _completedItem++;
                if (_completedItem == sprites.Length)
                {
                    visualNovel.StartNovel(endDialog, ()=> stateChanger.EnterState(nextState));
                }

                return dropElement;
            }
        }
        return null;
    }
}
