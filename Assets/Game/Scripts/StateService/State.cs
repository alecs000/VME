using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public abstract class State : MonoBehaviour
{
    public event UnityAction<int> OnStateEnter;

    private int _stateID;
    public void Initialize(int id)
    {
        _stateID = id;
    }
    public async virtual Task Enter() {
        OnStateEnter?.Invoke(_stateID);
    }
    public abstract void Exit();
}
