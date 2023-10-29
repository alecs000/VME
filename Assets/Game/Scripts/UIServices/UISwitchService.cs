using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public abstract class UISwitchService : MonoBehaviour
{
    public abstract Task Appear();
    public abstract void Disappear();
}
