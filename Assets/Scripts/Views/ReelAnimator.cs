using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReelAnimator : MonoBehaviour
{
    private const float min = 276;
    private const float max = 0;
    
    [SerializeField] private RectTransform _rectTransform;

    public void SetNormalized(float normalized)
    {
        var pos = _rectTransform.localPosition;
        pos.y = Mathf.Lerp(min, max, normalized);
        _rectTransform.localPosition = pos;
    }
}
