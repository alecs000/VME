using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum DepartmentButtonState
{
    Lock,
    Open,
    Complete,
}
public class MenuDepartmentButton : MonoBehaviour
{
    [SerializeField] private Button button;
    public Button MenuButton => button;
    public DepartmentButtonState CurrentState;

    [SerializeField] private Image lockPanel;
    [SerializeField] private CompletedPanel completedPanel;
    [SerializeField] private UnlockAnimation unlockAnimation;

    private const string _hash= "MenuDepartmentButton";
    private int _id;
    private string _localHash => _hash+_id; 
    public void Set(int id)
    {
        _id = id;
        int state = PlayerPrefs.GetInt(_localHash, 0);
        CurrentState = (DepartmentButtonState)state;
        switch (state)
        {
            case (int)DepartmentButtonState.Lock:
                Lock();
                break;
            case (int)DepartmentButtonState.Open:
                UnLock();
                break;
            case (int)DepartmentButtonState.Complete:
                Complete();
                break;
        }
    }
    public void UnLockAnimated()
    {
        PlayerPrefs.SetInt(_localHash, 1);
        unlockAnimation.Unlock(() =>
        {
            button.interactable = true;
            lockPanel.gameObject.SetActive(false);
        });
    }
    public void Complete()
    {
        PlayerPrefs.SetInt(_localHash, 2);
        lockPanel.gameObject.SetActive(false);
        completedPanel.Show();
        button.interactable = true;
    }
    private void Lock()
    {
        lockPanel.gameObject.SetActive(true);
        button.interactable = false;
    }

    private void UnLock()
    {
            button.interactable = true;
            lockPanel.gameObject.SetActive(false);
    }

}
