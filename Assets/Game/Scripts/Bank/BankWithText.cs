using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BankWithText : BankDefault
{
    [SerializeField] private TMP_Text text;
    public override void Add(int value)
    {
        base.Add(value);
        text.text = Value.ToString();
    }
    public override bool TryRemove(int value)
    {
        bool isRemoved = base.TryRemove(value);
        if (isRemoved)
        {
            text.text = Value.ToString();
        }
        return isRemoved;
    }
}
