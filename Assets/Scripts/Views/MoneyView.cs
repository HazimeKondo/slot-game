using System;
using UnityEngine;
using UnityEngine.UI;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private Text _balanceTxt;
    [SerializeField] private Text _linesTxt;
    [SerializeField] private Text _coinsTxt;
    [SerializeField] private Text _wagerTxt;
    [SerializeField] private Text _prizeTxt;

    [SerializeField] private Button _addLineBtn;
    [SerializeField] private Button _subLineBtn;
    [SerializeField] private Button _addCoinBtn;
    [SerializeField] private Button _subCoinBtn;
    [SerializeField] private Button _betMaxBtn;
    [SerializeField] private Button _playBtn;
    [SerializeField] private Button _moreCoinsBtn;

    public void SetBalance(int value)
    {
        _balanceTxt.text = value.ToString();
    }
    public void SetLines(int value)
    {
        _linesTxt.text = value.ToString();
    }
    public void SetCoins(int value)
    {
        _coinsTxt.text = value.ToString();
    }
    public void SetWager(int value)
    {
        _wagerTxt.text = value.ToString();
    }
    public void SetPrize(int value)
    {
        _prizeTxt.text = value.ToString();
    }

    private void Awake()
    {
        _moreCoinsBtn.gameObject.SetActive(false);
    }

    public void AddBetListeners(Action addLineCallback, Action subLineCallback, Action addCoinCallback, Action subCoinCallback)
    {
        _addLineBtn.onClick.AddListener(addLineCallback.Invoke);
        _subLineBtn.onClick.AddListener(subLineCallback.Invoke);
        _addCoinBtn.onClick.AddListener(addCoinCallback.Invoke);
        _subCoinBtn.onClick.AddListener(subCoinCallback.Invoke);
    }

    public void AddPlayListeners(Action betMaxCallback, Action playCallback,Action moreCoinsCallback)
    {
        _betMaxBtn.onClick.AddListener(betMaxCallback.Invoke);
        _playBtn.onClick.AddListener(playCallback.Invoke);
        _moreCoinsBtn.onClick.AddListener(moreCoinsCallback.Invoke);
    }

    public void SetEnabled(bool value)
    {
        _addLineBtn.interactable = value;
        _subLineBtn.interactable = value;
        _addCoinBtn.interactable = value;
        _subCoinBtn.interactable = value;
        _betMaxBtn.interactable = value;
        _playBtn.interactable = value;
    }

    public void SetMoreCoinsActive(bool value)
    {
        _playBtn.interactable = !value;
        _betMaxBtn.interactable = !value;
        _moreCoinsBtn.gameObject.SetActive(value);
    }
}
