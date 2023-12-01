using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MatrixDisplay))]
public class MatrixDisplayEditor : Editor
{
    private SerializedProperty columns;
    private SerializedProperty rows;
    private SerializedProperty serializedArray;

    private int[][] dropdownIndex;

    private void OnEnable()
    {
        columns = serializedObject.FindProperty("columns");
        rows = serializedObject.FindProperty("rows");
        serializedArray = serializedObject.FindProperty("serializedArray");

        UpdateDropdownIndex();
    }

    private void UpdateDropdownIndex()
    {
        int rowCount = rows.intValue;
        int colCount = columns.intValue;

        dropdownIndex = new int[rowCount * colCount][];

        for (int i = 0; i < rowCount * colCount; i++)
        {
            dropdownIndex[i] = new int[1];
            dropdownIndex[i][0] = serializedArray.GetArrayElementAtIndex(i).intValue;
        }
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(columns);
        EditorGUILayout.PropertyField(rows);

        int rowCount = rows.intValue;
        int colCount = columns.intValue;

        if (rowCount <= 0 || colCount <= 0)
        {
            EditorGUILayout.HelpBox("Rows and columns should be greater than zero.", MessageType.Error);
            serializedObject.ApplyModifiedProperties();
            return;
        }

        if (dropdownIndex.Length != rowCount * colCount)
        {
            UpdateDropdownIndex();
        }

        int index = 0;
        for (int i = 0; i < rowCount; i++)
        {
            EditorGUILayout.BeginHorizontal();
            for (int j = 0; j < colCount; j++)
            {
                int selectedIndexValue = EditorGUILayout.IntPopup(dropdownIndex[index][0], new string[] { "Option 1", "Option 2", "Option 3" }, new int[] { 0, 1, 2 });
                dropdownIndex[index][0] = selectedIndexValue;
                serializedArray.GetArrayElementAtIndex(index).intValue = selectedIndexValue;

                index++;
            }
            EditorGUILayout.EndHorizontal();
        }

        serializedObject.ApplyModifiedProperties();
    }
}