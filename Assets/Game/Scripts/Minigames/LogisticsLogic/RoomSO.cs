using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Room", menuName = "ScriptableObjects/Room")]
public class RoomSO : DialogSO
{
    [SerializeField] private int cost;
    [SerializeField] private bool isRightAnswer;
    public int Cost => cost;
    public bool IsRightAnswer => isRightAnswer;
}
