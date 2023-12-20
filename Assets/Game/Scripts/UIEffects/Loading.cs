using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using static UnityEngine.CullingGroup;

public class Loading : MonoBehaviour
{
    [SerializeField] private Logo logo;
    [SerializeField] private StateChanger stateChanger;
    [SerializeField] private State nextState;

    [Header("Loading options")]
    [SerializeField] private int rotationsAmount;
    [SerializeField] private float duration;

    [Header("Movement options")]
    [SerializeField] private BezierMovement bezierMovement;
    [SerializeField] private RectTransform[] controlPoints; // Контрольные точки кривой Безье
    [SerializeField] private float durationMove; 
    [SerializeField] private Vector2 averageSize; 
    [SerializeField] private Vector2 finishSize; 


    private void Start()
    {
        Sequence loadingSequence = DOTween.Sequence();
        loadingSequence.Append(logo.transform.DORotate(new Vector3(0, 0, -360), duration).SetRelative().SetLoops(rotationsAmount));
        loadingSequence.Join(logo.BackImage.DOFade(0.8f, duration / 2).SetLoops(rotationsAmount * 2, LoopType.Yoyo));
        loadingSequence.onKill += StartMovement;
        loadingSequence.Play();
    }
    

    private void StartMovement()
    {
        stateChanger.EnterState(nextState);
        Sequence movementSequence = DOTween.Sequence();
        Tween toAverageSize = logo.BackRectTransform.DOSizeDelta(averageSize, durationMove / 2);
        logo.transform.DORotate(new Vector3(0, 0,-360), durationMove+0.1f).SetRelative();
        Tween toFinishSize = logo.BackRectTransform.DOSizeDelta(finishSize, durationMove / 2);
        movementSequence.Append(toAverageSize); 
        movementSequence.Append(toFinishSize);
        bezierMovement.StartMovement(controlPoints, logo.BackRectTransform, durationMove);
    }
    
    
}
