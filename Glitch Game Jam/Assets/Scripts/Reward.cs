using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Reward", menuName = "Reward")]
public class Reward : ScriptableObject
{
    public List<Card> cardOptions;
    public List<Blessing> blessingOptions;
}
