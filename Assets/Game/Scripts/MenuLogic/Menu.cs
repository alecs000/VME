using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Menu : UIState
{
    [SerializeField] private MenuDepartmentButton[] departmentsButtons;
    [SerializeField] private State[] departmentsStates;
    [SerializeField] private StateChanger stateChanger;
    [SerializeField] private Logo logo;
    private int _lastUnlocked;
    private int _lastOpened;
    private bool _isFirstTime = true;
    private const string lastOpenedHash = "_lastOpenedHash";
    private void Start()
    {
        for (int i = 0; i < departmentsButtons.Length; i++)
        {
            int id = i;
            departmentsButtons[i].MenuButton.onClick.AddListener(() => ChangeState(id));
        }
    }
    private void ChangeState(int i)
    {
        _lastOpened = i;
        stateChanger.EnterState(departmentsStates[i]);
    }
    public override async Task Enter()
    {
        logo.gameObject.SetActive(false);
        logo.CanvasGroup.alpha = 0;
        for (int i = 0; i < departmentsButtons.Length; i++)
        {
            departmentsButtons[i].Set(i);
        }
        await base.Enter();
        if(_isFirstTime)
        {
            _lastUnlocked = PlayerPrefs.GetInt(lastOpenedHash, -1);
        }
        if (_lastUnlocked != -1)
        {
            if (_lastOpened == _lastUnlocked)
                departmentsButtons[_lastUnlocked].Complete();
            if (!_isFirstTime)
            {
                if (_lastOpened == _lastUnlocked)
                    _lastUnlocked++;
            }
            if (_lastUnlocked == departmentsButtons.Length)
                return;
            PlayerPrefs.SetInt(lastOpenedHash, _lastUnlocked);
        }
        else
        {
            _lastUnlocked = 0;
        }
        _isFirstTime = false;

        departmentsButtons[_lastUnlocked].UnLockAnimated();

    }
}
