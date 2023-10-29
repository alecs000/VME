using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public abstract class State : MonoBehaviour
{
    public abstract Task Enter();
    public abstract void Exit();
}
