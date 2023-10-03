using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/SymbolData")]
public class SymbolData : ScriptableObject
{
    public int Id;
    public string Name;
    public Sprite Sprite;
}