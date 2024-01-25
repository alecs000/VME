using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobsView : MonoBehaviour
{
    [SerializeField] private FadeAnimatedPanel view;
    private void Start()
    {
        
    } 
    public void Activate()
    {
        view.Appear();
    }
}
