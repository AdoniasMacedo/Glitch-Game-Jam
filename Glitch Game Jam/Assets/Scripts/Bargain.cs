using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bargain", menuName = "Bargain")]
public class Bargain : Blessing
{
    public List<Consequence> benefits;
    public List<Consequence> penalties;

    public override void ApplyConsequence(GameObject target)
    {
        foreach (var benefit in benefits)
        {
            benefit.ApplyConsequence(target);
        }

        foreach (var penalty in penalties)
        {
            penalty.ApplyConsequence(target);
        }
    }
}
