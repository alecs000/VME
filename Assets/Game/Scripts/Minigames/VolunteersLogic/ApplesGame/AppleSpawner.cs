using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    [SerializeField] private Apple applePrefab;
    [SerializeField] private int countApples;

    private PoolMono<Apple> applesOrdinary;

    private void Start()
    {
        applesOrdinary = new PoolMono<Apple>(applePrefab, countApples);
    }
    public Apple GetApple()
    {
        return applesOrdinary.GetFreeElement();
    }
}
