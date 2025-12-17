using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bargain", menuName = "Bargain")]
public class Bargain : Blessing
{
    public List<Consequence> penalties;
}
