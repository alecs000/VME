using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleGame : MonoBehaviour
{
    [SerializeField] private int goal;
    [SerializeField] private VisualNovel visualNovel;
    [SerializeField] private DialogSO startDialog;
    [SerializeField] private DialogSO dialogComplete;
    [SerializeField] private Apple prefab;
    [SerializeField] private int count;
    [SerializeField] private Vector2 appleDelay;
    [SerializeField] private Vector2 xRange;
    [SerializeField] private float yPosition;

    private PoolMono<Apple> apples;
    private int _applesCollected;

    private void Start()
    {
        apples = new PoolMono<Apple> (prefab, count);
        visualNovel.StartNovel(startDialog, StartGame, true);
    }
    private void StartGame()
    {
        StartCoroutine(Spawn());
    }
    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Random.Range(appleDelay.x, appleDelay.y));
        Apple apple= apples.GetFreeElement();
        apple.transform.position = new Vector2(Random.Range(xRange.x, xRange.y), yPosition);
    }
    public void AddApple(int amount)
    {
        _applesCollected += amount;
        if (_applesCollected >= goal)
        {
            CompleteAppleGame();
        }
    }
    private void CompleteAppleGame()
    {

    }
}
