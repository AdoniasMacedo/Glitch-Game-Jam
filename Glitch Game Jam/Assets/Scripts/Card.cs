using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public new string name;
    public string description;

    public int attack;
    public int defense;

    public CardCategory category;

    public List<Consequence> consequences;
}
