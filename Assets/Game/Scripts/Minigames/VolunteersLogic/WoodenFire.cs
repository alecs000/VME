using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenFire : MonoBehaviour
{
    [SerializeField] private ParticleSystem smoke;
    [SerializeField] private SpriteRenderer fire;
    [SerializeField] private Sprite fireSticks;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(2);
        CollectSticks();
    }
    public void CollectSticks()
    {
        smoke.Play();
        fire.sprite = fireSticks;
    }
}
