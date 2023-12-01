using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private State welcomeState;
    [SerializeField] private StateChanger stateChanger;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(2);
        stateChanger.EnterState(welcomeState);
    }
}
