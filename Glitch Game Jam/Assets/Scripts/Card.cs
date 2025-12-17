using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public new string name;
    [TextArea(5,10)]
    public string description;
    
    public CardCircle circle;
    public CardType type;
    public CardCost cost;

    [SerializeReference]
    public List<Skills> skills;
    
    [Range(0,1)]
    public float cardPower;
    
    [SerializeReference]
    public List<Challenge> challenges;

}
