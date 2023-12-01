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
    [SerializeField] private RectTransform[] controlPoints; // Контрольные точки кривой Безье
    [SerializeField] private float durationMove; 
    [SerializeField] private Vector2 averageSize; 
    [SerializeField] private Vector2 finishSize; 

    private float t = 0f; // Параметр t для интерполяции по кривой
    private bool _isMoveBezier;

    private void Start()
    {
        Sequence loadingSequence = DOTween.Sequence();
        loadingSequence.Append(logo.transform.DORotate(new Vector3(0, 0, -360), duration).SetRelative().SetLoops(rotationsAmount));
        loadingSequence.Join(logo.BackImage.DOFade(0.8f, duration / 2).SetLoops(rotationsAmount * 2, LoopType.Yoyo));
        loadingSequence.onKill += StartMovement;
        loadingSequence.Play();
    }
    void Update()
    {
        if (controlPoints.Length >= 2 && _isMoveBezier)
        {
            t += Time.deltaTime / durationMove;
            if (t > 1f)
            {
                t = 1f;
            }

            Vector3 position = CalculateBezierPoint(controlPoints, t);
            logo.BackImage.rectTransform.position = position;

            if (t >= 1f)
            {
                // Достигнут конец кривой, можно выполнить действия по окончанию движения
                _isMoveBezier = false;
            }
        }
    }

    private void StartMovement()
    {
        stateChanger.EnterState(nextState);
        _isMoveBezier = true;
        Sequence movementSequence = DOTween.Sequence();
        Tween toAverageSize = logo.BackRectTransform.DOSizeDelta(averageSize, durationMove / 2);
        logo.transform.DORotate(new Vector3(0, 0,-360), durationMove+0.1f).SetRelative();
        Tween toFinishSize = logo.BackRectTransform.DOSizeDelta(finishSize, durationMove / 2);

        movementSequence.Append(toAverageSize); 
        movementSequence.Append(toFinishSize); 
    }
    private Vector3 CalculateBezierPoint(RectTransform[] points, float t)
    {
        int order = points.Length - 1;
        Vector3 point = Vector3.zero;

        for (int i = 0; i < points.Length; i++)
        {
            float binomialCoeff = BinomialCoefficient(order, i);
            float term = binomialCoeff * Mathf.Pow(1 - t, order - i) * Mathf.Pow(t, i);
            point += term * points[i].position;
        }

        return point;
    }

    private float BinomialCoefficient(int n, int k)
    {
        float result = 1;
        for (int i = 1; i <= k; i++)
        {
            result *= (n - (k - i));
            result /= i;
        }
        return result;
    }
    
}
