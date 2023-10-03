using UnityEngine;
using UnityEngine.UI;

public class BonusCountView : MonoBehaviour
{
    private GameObject _content;
    private Text _messageTxt;
    private void Awake()
    {
        _messageTxt = GetComponentInChildren<Text>();
        _content = transform.GetChild(0).gameObject;
        _content.SetActive(false);
    }

    public void SetBonus(int count)
    {
        _messageTxt.text = $"Bonus FreeSpin Remaining: {count}";
        _content.SetActive(true);
    }

    public void TurnOff()
    {
        _content.SetActive(false);
    }
}
