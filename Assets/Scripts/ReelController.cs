using System.Collections;
using UnityEngine;

public class ReelController : MonoBehaviour
{
    [SerializeField] private ReelData _data;
    private ReelView _view;
    private int _targetRoot;

    private void Awake()
    {
        _view = GetComponent<ReelView>();
        _view.SetData(_data);
    }

    public void SpinTo(int target)
    {
        _targetRoot = target;
        StopAllCoroutines();
        StartCoroutine(_view.Spin());
    }

    public IEnumerator Stop()
    {
        _view.StopSpinAt(_targetRoot);
        yield return new WaitWhile(() =>_view.IsSpinning);
    }
    
    public int[] GetResult()
    {
        return new[]
        {
            _data.SymbolStrip[(_targetRoot + 1).IntRepeat(_data.SymbolStrip.Length)].Id,
            _data.SymbolStrip[(_targetRoot).IntRepeat(_data.SymbolStrip.Length)].Id,
            _data.SymbolStrip[(_targetRoot - 1).IntRepeat(_data.SymbolStrip.Length)].Id
        };
    }
}