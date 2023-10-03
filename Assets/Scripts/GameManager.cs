using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ReelController[] _reels;
    [SerializeField] private BetManager _betManager;
    [SerializeField] private MoneyView _moneyView;
    [SerializeField] private BonusCountView _bonusCountView;
    private ResultData _lastResult;

    private int _balance = 10000;

    private int bonusCount = 0;

    private int totalPrize;

    private void Start()
    {
        _moneyView.SetBalance(_balance);
        _moneyView.AddPlayListeners(BetMax, GeneratePlay, GetMoreCoins);
    }

    [ContextMenu("GeneratePlay")]
    private void GeneratePlay()
    {
        if (CheckBalance()) 
            StartCoroutine(Play());
    }

    private void BetMax()
    {
        _betManager.SetToMax();
        if (CheckBalance()) 
            StartCoroutine(Play());
    }
    private IEnumerator Play()
    {
        _moneyView.SetBalance(_balance -= _betManager.Wager);
        _moneyView.SetEnabled(false);
        _moneyView.SetPrize(totalPrize = 0);
        
        yield return RollLoop();

        if (bonusCount > 0)
        {
            do
            {
                _bonusCountView.SetBonus(bonusCount);
                yield return new WaitForSeconds(1f);
                _bonusCountView.SetBonus(--bonusCount);
                yield return RollLoop(3);
            } while (bonusCount > 0);
            _bonusCountView.TurnOff();
        }
        
        _moneyView.SetBalance(_balance += totalPrize);
        _moneyView.SetEnabled(true);
        _betManager.TurnOnLines();
        CheckBalance();
    }

    private IEnumerator RollLoop(int multiplier = 1)
    {
        _betManager.TurnOffLines();

        _lastResult = new ResultData();
        foreach (var reel in _reels)
        {
            reel.SpinTo(Random.Range(0,32));
            _lastResult.Include(reel.GetResult());
        }
        yield return new WaitForSeconds(1f);

        foreach (var reel in _reels)
        {
            yield return reel.Stop();
        }
        
        totalPrize += _betManager.CheckPrize(_lastResult)*_betManager.Coins*multiplier;
        var bonus = _betManager.CheckBonus(_lastResult)*_betManager.Wager;
        totalPrize += bonus;

        if (bonus > 0)
        {
            bonusCount += 10;
        }
        _moneyView.SetPrize(totalPrize);
    }

    private bool CheckBalance()
    {
        if (_balance == 0 || _balance < _betManager.Wager)
        {
            _moneyView.SetMoreCoinsActive(true);
            return false;
        }

        return true;
    }

    private void GetMoreCoins()
    {
        _moneyView.SetBalance(_balance = 10000);
        _moneyView.SetMoreCoinsActive(false);
    }
}