using UnityEngine;

public class MatrixDisplay : MonoBehaviour
{
    public int columns = 3;
    public int rows = 3;

    [SerializeField]
    private int[] serializedArray;

    private void Awake()
    {
        InitializeMatrix();
    }

    private void InitializeMatrix()
    {
        serializedArray = new int[rows * columns];
        // Пример заполнения массива значениями по умолчанию
        for (int i = 0; i < rows * columns; i++)
        {
            serializedArray[i] = 0; // Индекс выбранного элемента в выпадающем списке
        }
    }

    public int GetElementValue(int row, int column)
    {
        return serializedArray[row * columns + column];
    }

    public void SetElementValue(int row, int column, int value)
    {
        if (row >= 0 && row < rows && column >= 0 && column < columns)
        {
            serializedArray[row * columns + column] = value;
        }
    }
}