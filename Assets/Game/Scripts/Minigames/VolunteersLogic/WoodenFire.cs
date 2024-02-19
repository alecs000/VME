using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenFire : MonoBehaviour
{
    [SerializeField] private ParticleSystem smokePS;
    [SerializeField] private SpriteRenderer fireCore;
    [SerializeField] private Animator fire;
    [SerializeField] private Sprite fireSticks;
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
            _isFireActivated = true;
            return;
        }
        if (collision.TryGetComponent(out PlayerMovement player))
        {
            if (volunteers.IsSticksCollected)
            {
                StartCoroutine(CollectSticks());
                visualNovel.StartNovel(goodJobDialog, null, true);
                return;
            }
            visualNovel.StartNovel(dialog, ()=> joystick.SetActive(true), true);
            joystick.SetActive(false);
        }
    }
}
