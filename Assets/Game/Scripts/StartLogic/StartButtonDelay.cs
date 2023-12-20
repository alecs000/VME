using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButtonDelay : MonoBehaviour
{
    [SerializeField] private State state;
    [SerializeField] private Button next;
    private void Start()
    {
        next.interactable = false;
        state.OnStateEnter += (int i) => next.interactable = true;
    }


}
