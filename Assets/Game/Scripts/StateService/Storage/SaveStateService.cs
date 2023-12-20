using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveStateService : MonoBehaviour
{
    [SerializeField] private State[] allStates;
    private void Start()
    {
        for (int i = 0; i < allStates.Length; i++)
        {
            allStates[i].Initialize(i);
            allStates[i].OnStateEnter += OnStateChanged;
        }
    }
    private void OnStateChanged(int stateID)
    {

    }
}
