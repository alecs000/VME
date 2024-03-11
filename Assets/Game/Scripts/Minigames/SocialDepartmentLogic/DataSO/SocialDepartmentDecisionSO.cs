using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public enum ChoiseType
{
    Single,
    Double,
}
[CreateAssetMenu(fileName = "SocialDepartmentDecisionSO", menuName = "ScriptableObjects/SocialDepartmentDecisionSO", order = 1)]
public class SocialDepartmentDecisionSO : ScriptableObject
{
    [SerializeField] private string title;
    [TextArea]
    [SerializeField] private string description;

    [SerializeField] private ChoiseType choise = ChoiseType.Double;

    [SerializeField] private Reward rewardsOk;
    [SerializeField] private Reward rewardsCansel;

    public string Title => title;
    public string Description => description;
    public ChoiseType Choise => choise;
    public Reward RewardOk => rewardsOk;
    public Reward RewardsCancel => rewardsCansel;
}
