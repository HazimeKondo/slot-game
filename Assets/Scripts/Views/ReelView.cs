using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ReelView : MonoBehaviour
{
    private ReelData _data;
    [SerializeField] private Image _symbol_off;
    [SerializeField] private Image _symbol_top;
    [SerializeField] private Image _symbol_mid;
    [SerializeField] private Image _symbol_bottom;

    [SerializeField] private ReelAnimator _reelAnimator;

    [SerializeField] private float _speed = 1;
    private int _stripLength;
    private int _actualPosition = 0;
    private int _targetPosition = -1;

    public bool IsSpinning = false;

    private void Start()
    {
        _stripLength = _data.SymbolStrip.Length;
        SetTo(0);
    }

    public void SetData(ReelData data)
    {
        _data = data;
    }
    
    public void StopSpinAt(int position)
    {
        _targetPosition = position.IntRepeat(_stripLength);
    }

    public IEnumerator Spin()
    {
        IsSpinning = true;
        var interpolation = 0f;

        while (_actualPosition!=_targetPosition)
        {
            SetTo(_actualPosition);
            while (interpolation<1)
            {
                yield return null;
                interpolation += Time.deltaTime * _speed;
                _reelAnimator.SetNormalized(interpolation);
            }

            _actualPosition= (_actualPosition+1).IntRepeat(_stripLength);
            interpolation -= 1f;
        }

        _targetPosition = -1;
        IsSpinning = false;
    }
    
    private void SetTo(int position)
    {
        _symbol_off.sprite = GetSprite(position + 2);
        _symbol_top.sprite = GetSprite(position + 1);
        _symbol_mid.sprite = GetSprite(position);
        _symbol_bottom.sprite = GetSprite(position - 1);
        _actualPosition = position;
    }

    private Sprite GetSprite(int position)
    {
        return _data.SymbolStrip[position.IntRepeat(_stripLength)].Sprite;
    }

    
}