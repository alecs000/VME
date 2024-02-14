using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenFire : MonoBehaviour
{
    [SerializeField] private ParticleSystem smokePS;
    [SerializeField] private SpriteRenderer fireCore;
    [SerializeField] private Animator fire;
    [SerializeField] private Sprite fireSticks;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);
        StartCoroutine(CollectSticks());

    }
    IEnumerator CollectSticks()
    {
        smokePS.Play();
        fireCore.sprite = fireSticks;
        yield return new WaitForSeconds(0.1f);
        fire.gameObject.SetActive(true);
    }
}
