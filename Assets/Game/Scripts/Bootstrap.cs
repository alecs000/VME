using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private State welcomeState;
    [SerializeField] private StateChanger stateChanger;
    void Start()
    {
        stateChanger.EnterState(welcomeState);
    }
}
