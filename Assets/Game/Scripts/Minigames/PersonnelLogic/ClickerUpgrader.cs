using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ClickerUpgrader : MonoBehaviour
{
    [SerializeField] private Personnel personnel;
    [SerializeField] private ClickablePanel clickablePanel;
    [SerializeField] private PeopleAmount peopleAmount;
    [SerializeField] private Button[] upgradeButtons;
    private void Start()
    {
        upgradeButtons[0].onClick.AddListener(UpgradeAutoClick);
        upgradeButtons[1].onClick.AddListener(UpgradeOneClick);
        upgradeButtons[2].onClick.AddListener(UpgradeHundredClicks);
    }
    public void UpgradeAutoClick()
    {
        if (peopleAmount.TryRemove(1))
        {
            StartCoroutine(AutoClick());
            upgradeButtons[0].interactable = false;
        }
    }
    IEnumerator AutoClick()
    {
        while (!personnel.IsFinished)
        {
            yield return new WaitForSeconds(1);
            clickablePanel.ClickPanel();
        }
    }
    public void UpgradeOneClick()
    {
        if (peopleAmount.TryRemove(1))
        {
            personnel.UpgradeAmountToAdd();
            upgradeButtons[1].interactable = false;
        }
    }
    public void UpgradeHundredClicks()
    {
        if (peopleAmount.TryRemove(1))
        {
            personnel.UpgradeHundred();
            upgradeButtons[2].interactable = false;
        }
    }
}
