using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITDropElement : MonoBehaviour
{
    private RectTransform _rectTransform;
    public RectTransform RectTransform=>_rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

}
