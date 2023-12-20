using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialog", menuName = "ScriptableObjects/Dialog")]
public class DialogSO : ScriptableObject
{
    [TextArea]
    [SerializeField] private string[] text;
    public string[] Text => text;
}
