using DG.Tweening;
using DG.Tweening.Plugins.Core.PathCore;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.CullingGroup;

public class BezierMovement : MonoBehaviour
{
    private RectTransform[] _controlPoints;
    private RectTransform _objectToMove;
    private float _duration;

    private bool _isMove;
    private float t = 0f;// Параметр t для интерполяции по кривой
    private UnityAction onEndMove;
    public void StartMovement(RectTransform[] controlPoints, RectTransform objectToMove, float duration, UnityAction onEndMove = null)
    {
        if (_isMove)
            throw new Exception($"{_objectToMove} already moving you cant move {objectToMove}");
        _controlPoints = controlPoints;
        _objectToMove = objectToMove;
        _duration = duration;
        _isMove = true;
        this.onEndMove = onEndMove;
    }

    private void Update()
    {
        if (_isMove&&_controlPoints.Length >= 2)
        {
            t += Time.deltaTime / _duration;
            if (t > 1f)
            {
                t = 1f;
            }

            Vector3 position = CalculateBezierPoint(_controlPoints, t);
            _objectToMove.position = position;

            if (t >= 1f)
            {
                onEndMove?.Invoke();
                // Достигнут конец кривой, можно выполнить действия по окончанию движения
                _isMove = false;
            }
        }
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
