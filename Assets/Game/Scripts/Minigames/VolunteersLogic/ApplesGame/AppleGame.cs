using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleGame : MonoBehaviour
{
    [SerializeField] private int goal;
    [SerializeField] private VisualNovel visualNovel;
    [SerializeField] private DialogSO startDialog;
    [SerializeField] private DialogSO dialogComplete;

    private PoolMono<Apple> apples;
    private int _applesCollected;

    private void Start()
    {
        visualNovel.StartNovel(startDialog, StartGame, true);
    }
    private void StartGame()
    {

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
