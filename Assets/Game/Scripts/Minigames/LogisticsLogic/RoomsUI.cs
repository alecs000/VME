using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomsUI : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private TMP_Text budget;
    [SerializeField] private TMP_Text roomCost;
    [SerializeField] private Button leftArrow;
    [SerializeField] private Button rightArrow;
    [SerializeField] private Button choose;
    public CanvasGroup RoomCanvasGroup => canvasGroup;
    public TMP_Text BudgetText => budget;
    public TMP_Text RoomCostText => roomCost;
    public Button LeftArrow => leftArrow;
    public Button RightArrow => rightArrow;
    public Button ChooseButton => choose;
}

