using UnityEngine;

[CreateAssetMenu(fileName = "New Offer Reward Consequence", menuName = "Consequences/Offer Reward")]
public class OfferRewardConsequence : Consequence
{
    public Reward rewardToOffer;

    public override void ApplyConsequence(GameObject target)
    {
        // Placeholder for the reward offering logic.
        // This would typically involve displaying a UI to the player
        // and letting them choose from the rewardToOffer.cardOptions or rewardToOffer.blessingOptions.
        Debug.Log("Offering reward: " + rewardToOffer.name);
    }
}
