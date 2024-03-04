using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AppleGame : MonoBehaviour
{
    public bool IsGameStarted;
    [SerializeField] private TMP_Text appleText;
    [SerializeField] private int goal;
    [SerializeField] private VisualNovel visualNovel;
    [SerializeField] private DialogSO startDialog;
    [SerializeField] private DialogSO dialogComplete;
    [SerializeField] private Vector2 appleDelay;
    [SerializeField] private Vector2 xRange;
    [SerializeField] private float yPosition;
    [SerializeField] private StateChanger stateChanger;
    [SerializeField] private State nextState;

    [SerializeField] private AppleSpawner ordinaryAppleSpawner;
    [SerializeField] private AppleSpawner badAppleSpawner;
    [SerializeField] private AppleSpawner goldAppleSpawner;


    private int _applesCollected;

    private void Start()
    {
        visualNovel.StartNovel(startDialog, StartGame, true);
    }
    private void StartGame()
    {
        IsGameStarted = true;
        StartCoroutine(Spawn());
    }
    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(appleDelay.x, appleDelay.y));
            int appleRandom = Random.Range(0, 10);
            Apple apple;
            if (appleRandom % 4 == 0)
            {
                apple = badAppleSpawner.GetApple();
            }
            else if(appleRandom == 9)
            {
                apple = goldAppleSpawner.GetApple();
            }
            else
            {
                apple = ordinaryAppleSpawner.GetApple();
            }
            apple.transform.position = new Vector2(Random.Range(xRange.x, xRange.y), yPosition);
        }
    }
    public void AddApple(int amount)
    {
        _applesCollected += amount;
        appleText.text = _applesCollected.ToString();
        if (_applesCollected >= goal)
        {
            CompleteAppleGame();
        }
    }
    private void CompleteAppleGame()
    {
        IsGameStarted = false;
        visualNovel.StartNovel(dialogComplete,()=> stateChanger.EnterState(nextState), true);
    }
}
