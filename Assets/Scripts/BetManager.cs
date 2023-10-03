using UnityEngine;

public class BetManager : MonoBehaviour
{
    [SerializeField] private PrizeData _prizeData;
    [SerializeField] private LinePayController[] _linePays;
    [SerializeField] private MoneyView _moneyView;
    private int _activePayLines = 20;
    private int _coinsPerLine = 5;
    private int _wager = 100;
    public int Wager => _wager;
    public int Coins => _coinsPerLine;

    private void Start()
    {
        _moneyView.AddBetListeners(AddPayLine,SubtractPayLine,AddCoins,SubtractCoins);
        _moneyView.SetLines(_activePayLines);
        _moneyView.SetCoins(_coinsPerLine);
        _moneyView.SetWager(_wager);
        SetLines(_activePayLines);
    }

    private int SetLines(int number)
    {
        _activePayLines = Mathf.Clamp(number,1,_linePays.Length);
        for (int i = 0; i < _linePays.Length; i++)
        {
            _linePays[i].SetLineActive(_activePayLines > i);
        }
        return _activePayLines;
    }

    private void AddPayLine()
    {
        SetLines(_activePayLines+1);
        _moneyView.SetLines(_activePayLines);
        UpdateWager();
    }

    private void SubtractPayLine()
    {
        SetLines(_activePayLines-1);
        _moneyView.SetLines(_activePayLines);
        UpdateWager();
    }
    
    private void AddCoins()
    {
        _coinsPerLine = Mathf.Clamp(_coinsPerLine + 1, 1, 5);
        _moneyView.SetCoins(_coinsPerLine);
        UpdateWager();
    }

    private void SubtractCoins()
    {
        _coinsPerLine = Mathf.Clamp(_coinsPerLine - 1, 1, 5);
        _moneyView.SetCoins(_coinsPerLine);
        UpdateWager();
    }

    private void UpdateWager()
    {
        _wager = _activePayLines * _coinsPerLine;
        _moneyView.SetWager(_wager);
    }

    public int CheckPrize(ResultData result)
    {
        var totalPrize = 0;
        for (int i = 0; i < _activePayLines; i++)
        {
            totalPrize+=_linePays[i].CheckPrize(result, _prizeData);
        }

        return totalPrize;
    }

    public int CheckBonus(ResultData result)
    {
        var scatters = result.GetScatters();
        return _prizeData.GetPrize(10,scatters);
    }

    public void TurnOffLines()
    {
        foreach (var linePay in _linePays)
        {
            linePay.SetLineVisible(false);
            linePay.enabled = false;
        }
    }

    public void TurnOnLines()
    {
        foreach (var linePay in _linePays)
            linePay.enabled = true;
    }

    public void SetToMax()
    {
        _moneyView.SetLines(SetLines(20));
        _moneyView.SetCoins(_coinsPerLine=5);
        UpdateWager();
    }
}