using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WoodenFire : MonoBehaviour
{
    public event UnityAction OnCompleted;
    [SerializeField] private ParticleSystem smokePS;
    [SerializeField] private SpriteRenderer fireCore;
    [SerializeField] private Animator fire;
    [SerializeField] private Sprite fireSticks;
    [SerializeField] private Sprite destroyedSticks;
    [SerializeField] private VisualNovel visualNovel;
    [SerializeField] private DialogSO dialog;
    [SerializeField] private DialogSO goodJobDialog;
    [SerializeField] private Volunteers volunteers;
    [SerializeField] private GameObject joystick;
    private bool _isFireActivated;
    public IEnumerator CollectSticks()
    {
        smokePS.Play();
        fireCore.sprite = fireSticks;
        yield return new WaitForSeconds(0.1f);
        fire.gameObject.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isFireActivated)
        {
            return;
        }
        if (collision.TryGetComponent(out PlayerMovement player))
        {
            if (volunteers.IsSticksCollected)
            {
                StartCoroutine(CollectSticks());
                visualNovel.StartNovel(goodJobDialog, null, true);
                OnCompleted?.Invoke();
                _isFireActivated = true;
                return;
            }
            visualNovel.StartNovel(dialog, ()=> joystick.SetActive(true), true);
            joystick.SetActive(false);
        }
    }
    public void ResetFire()
    {
        _isFireActivated = false;
        fireCore.sprite = destroyedSticks;
        smokePS.Stop();
        fire.gameObject.SetActive(false);
    }
}
