using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/PrizeData")]
public class PrizeData : ScriptableObject
{
    [Serializable] public struct SymbolPrize
    {
        public int _5InARow;
        public int _4InARow;
        public int _3InARow;
        public int _2InARow;
    }

    [SerializeField] private SymbolPrize[] _prizes;
    
    public int GetPrize(int symbol, int sequence)
    {
        switch (sequence)
        {
            case 5: return _prizes[symbol]._5InARow;
            case 4: return _prizes[symbol]._4InARow;
            case 3: return _prizes[symbol]._3InARow;
            case 2: return _prizes[symbol]._2InARow;
            default: return 0;
        }
    }
}
