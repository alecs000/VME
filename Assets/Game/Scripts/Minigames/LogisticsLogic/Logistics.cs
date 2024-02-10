using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;

public class Logistics : State
{
    [SerializeField] private State nextState;
    [SerializeField] private StateChanger stateChanger;

    [Header("VisualNovel")]
    [SerializeField] private VisualNovel visualNovel;
    [SerializeField] private DialogSO dialog;
    [Header("UI")]
    [SerializeField] private RoomsUI roomsUI;
    [SerializeField] private float durarionUI;
    [SerializeField] private Logo logo;
    [Header("RoomsLogic")]
    [SerializeField] private Room[] rooms;
    [SerializeField] private float smoothSpeed;
    [SerializeField] private Vector3 cameraOffset;

    private int _currentRoomID;
    private Camera cameraMain;
    private bool _isCameraMoving;
    private Tween switchRoomTween;
    public override async Task Enter()
    {
        gameObject.SetActive(true);
        cameraMain = Camera.main;
        await base.Enter();
        visualNovel.StartNovel(dialog, OnDialogComplete);
        roomsUI.RightArrow.onClick.AddListener(OnRightArrowClick);
        roomsUI.LeftArrow.onClick.AddListener(OnLeftArrowClick);
        roomsUI.ChooseButton.onClick.AddListener(OnChooseButtonClick);
        _currentRoomID = 0;
    }
    private void OnChooseButtonClick()
    {
        SwitchRoomUI(false);
        visualNovel.StartNovel(rooms[_currentRoomID].RoomSo, () =>
        {
            if (rooms[_currentRoomID].RoomSo.IsRightAnswer)
            {
                stateChanger.EnterState(nextState);
            }
            else
            {
                logo.CanvasGroup.DOFade(0, durarionUI);
                SwitchRoomUI(true);
            }
        });
    }
    private void OnRightArrowClick()
    {
        if (_currentRoomID == rooms.Length - 1)
            return;
        _currentRoomID++;
        ChangeRoom();
    }
    private void OnLeftArrowClick()
    {
        if (_currentRoomID == 0)
            return;
        _currentRoomID--;
        ChangeRoom();
    }
    private void ChangeRoom()
    {
        SetCost(rooms[_currentRoomID].RoomSo);
        _isCameraMoving = true;
    }
    private void LateUpdate()
    {
        if (_isCameraMoving)
        {

            Vector3 targetPosition = cameraOffset + rooms[_currentRoomID].transform.position;
            Vector3 smoothedPosition = Vector3.Lerp(cameraMain.transform.position, targetPosition, smoothSpeed * Time.deltaTime);
            cameraMain.transform.position = smoothedPosition;
            float distanceToTarget = Vector3.Distance(cameraMain.transform.position, targetPosition);
            if (distanceToTarget <= 0.1)
            {
                _isCameraMoving =false;
            }
        }
     }
    private void OnDialogComplete()
    {
        SwitchRoomUI(true);
        SetCost(rooms[0].RoomSo);
        logo.CanvasGroup.DOFade(0, durarionUI);
    }
    private void SetCost(RoomSO room)
    {
        roomsUI.RoomCostText.text = $"Цена данного помещения: {room.Cost}";
    }
    private void SwitchRoomUI(bool isActive)
    {
        switchRoomTween?.Kill();
        switchRoomTween = roomsUI.RoomCanvasGroup.DOFade(isActive?1:0, durarionUI);
        print(isActive);
        if (isActive)
        {
            roomsUI.gameObject.SetActive(isActive);
            switchRoomTween.onKill += () => {
                roomsUI.RoomCanvasGroup.interactable = true;
            };
        }
        else
        {
            roomsUI.RoomCanvasGroup.interactable = false;
            switchRoomTween.onKill +=()=> { 
                roomsUI.gameObject.SetActive(isActive);
            };
        }
    }
    public override void Exit()
    {
        gameObject.SetActive(false);
    }

}
