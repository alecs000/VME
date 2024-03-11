#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SocialDepartmentDecisionSO))]
public class SocialDepartmentDecisionSOEditor : Editor
{
    SerializedProperty choiseProperty;
    SerializedProperty rewardsCancelProperty;

    void OnEnable()
    {
        choiseProperty = serializedObject.FindProperty("choise");
        rewardsCancelProperty = serializedObject.FindProperty("rewardsCansel");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(serializedObject.FindProperty("title"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("description"));
        EditorGUILayout.PropertyField(choiseProperty);
        Debug.Log(11);


        EditorGUILayout.PropertyField(serializedObject.FindProperty("rewardsOk"));
        if ((ChoiseType)choiseProperty.enumValueIndex == ChoiseType.Single)
        {
            rewardsCancelProperty.isExpanded = false;
        }
        else
        {
            EditorGUILayout.PropertyField(rewardsCancelProperty);
        }
        serializedObject.ApplyModifiedProperties();
    }
}
#endif