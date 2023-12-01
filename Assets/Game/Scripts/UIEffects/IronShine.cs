using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronShine : MonoBehaviour
{
    [SerializeField] private RectTransform restTransform;

    [Header("Options")]
    [SerializeField] private Vector2 EndPoint;
    [SerializeField] private float duration;
    [SerializeField] private int loop;
    [SerializeField] private float repeatInterval;

    private void Start()
    {
        // ������� ������������������ ��������
        Sequence sequence = DOTween.Sequence();

        // ��������� tween ��� �������
        sequence.Append(restTransform.DOAnchorPos(EndPoint, duration));

        // ��������� �������� ����� ��������� �������� �������
        sequence.AppendInterval(repeatInterval).SetLoops(-1, LoopType.Restart);

        // ��������� ������������������ ��������
        sequence.Play();
    }
}
