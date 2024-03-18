using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChanger : MonoBehaviour
{
    private State _currentState;
    public async void EnterState(State newState)
    {
        _currentState?.Exit();
        await newState.Enter();
        _currentState = newState;
    }
}
