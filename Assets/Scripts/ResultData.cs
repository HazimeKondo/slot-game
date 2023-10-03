using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResultData
{
    private List<int> _symbols = new List<int>();

    public void Include(int[] resultToInclude)
    {
        _symbols.AddRange(resultToInclude);
    }

    public int GetResult(int index)
    {
        if (index >= 0 && index < _symbols.Count)
        {
            return _symbols[index];
        }

        return -1;
    }

    public int GetScatters()
    {
        return _symbols.Count(_ => _ == 10);
    }
}