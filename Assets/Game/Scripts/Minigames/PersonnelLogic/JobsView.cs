using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobsView : MonoBehaviour
{
    [SerializeField] private FadeAnimatedPanel view;
    [SerializeField] private ParticleSystem particleSystemLogo;
    [SerializeField] private Button close;
    private void Start()
    {
        close.onClick.AddListener(Deactivate);
    } 
    public void Activate()
    {
        view.Appear();
        particleSystemLogo.Play();
    }
    private void Deactivate()
    {
        view.Disappear();
    }
}
