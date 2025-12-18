// Temporary comment to force file into patch
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card Data", menuName = "CardData")]
public class CardData : ScriptableObject
{
    public new string name;
    [TextArea(5,10)]
    public string description;

    public Sprite cardSprite;
    
    public CardCircle circle;
    public CardType type;
    public CardCost cost;
    public int costValue;

    [SerializeReference]
    public List<Skills> skills;
    
    [Range(0,1)]
    public float cardPower;
    
    [SerializeReference]
    public List<Challenge> challenges;

    public Reward reward;
}
