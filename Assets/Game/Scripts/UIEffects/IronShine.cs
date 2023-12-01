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
        // Создаем последовательность анимаций
        Sequence sequence = DOTween.Sequence();

        // Добавляем tween для объекта
        sequence.Append(restTransform.DOAnchorPos(EndPoint, duration));

        // Повторяем анимацию через указанный интервал времени
        sequence.AppendInterval(repeatInterval).SetLoops(-1, LoopType.Restart);

        // Запускаем последовательность анимаций
        sequence.Play();
    }
}
