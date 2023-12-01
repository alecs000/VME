using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChanger : MonoBehaviour
{
    private State _currentState;
    public async void EnterState(State newState)
    {
        await newState.Enter();
        _currentState?.Exit();
        _currentState = newState;
    }
}
