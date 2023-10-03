using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/ReelData")]
public class ReelData : ScriptableObject
{
    public SymbolData[] SymbolStrip;
}