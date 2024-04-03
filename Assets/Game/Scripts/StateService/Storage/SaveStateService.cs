using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveStateService
{
    private State[] _allStates;
    private const string StateHash = "SavedState";
    public SaveStateService(State[] allStates)
    {
        _allStates = allStates;
        for (int i = 0; i < allStates.Length; i++)
        {
            allStates[i].Initialize(i);
            allStates[i].OnStateEnter += OnStateChanged;
        }
    }
    public State GetSavedState()
    {
        return _allStates[PlayerPrefs.GetInt(StateHash, 0)];
    }
    private void OnStateChanged(int stateID)
    {
        PlayerPrefs.SetInt(StateHash, stateID);
    }
}
