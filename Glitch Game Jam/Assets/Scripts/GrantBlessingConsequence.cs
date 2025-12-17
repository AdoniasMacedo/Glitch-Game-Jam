using UnityEngine;

[CreateAssetMenu(fileName = "New Grant Blessing Consequence", menuName = "Consequences/Grant Blessing")]
public class GrantBlessingConsequence : Consequence
{
    public Blessing blessingToGrant;

    public override void ApplyConsequence(GameObject target)
    {
        if (blessingToGrant != null)
        {
            foreach (var effect in blessingToGrant.effects)
            {
                effect.ApplyConsequence(target);
            }
        }
    }
}
