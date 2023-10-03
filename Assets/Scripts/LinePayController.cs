using UnityEngine;

public class LinePayController : MonoBehaviour
{
    [SerializeField] private int[] _pattern;
    private LinePayView _view;

    private void Awake()
    {
        _view = GetComponent<LinePayView>();
    }

    public int CheckPrize(ResultData result, PrizeData prizeData)
    {
        var firstElement = result.GetResult(_pattern[0]);
        if (firstElement == 10)
            return 0;
        
        var sequenceCounter = 1;
        for (int i = 1; i < 5; i++)
        {
            var element = result.GetResult(_pattern[i]);
            if (element == 0 || element == firstElement)
                sequenceCounter++;
            else break;
        }

        var prize = prizeData.GetPrize(firstElement, sequenceCounter);

        if (firstElement == 0)
        {
            sequenceCounter = 2;
            for (int i = 2; i < 5; i++)
            {
                var element = result.GetResult(_pattern[i]);
                if (firstElement == 0) firstElement = element;
                if (element == 0 || element == firstElement)
                    sequenceCounter++;
                else break;
            }
            prize += prizeData.GetPrize(firstElement, sequenceCounter);
        }

        if(prize>0) _view.SetLine(true);
        return prize;
    }

    public void SetLineActive(bool value)
    {
        _view.SetToggle(value);
    }

    public void SetLineVisible(bool value)
    {
        _view.SetLine(value);
    }
}
