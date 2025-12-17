using UnityEngine;

public class RewardManager : MonoBehaviour
{
    private static RewardManager _instance;
    public static RewardManager Instance => _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ProcessReward(Reward reward, GameObject target)
    {
        if (reward.blessingChoices != null && reward.blessingChoices.Count > 0)
        {
            // For simplicity, we'll just add the first blessing in the list.
            // A real implementation would involve player choice.
            var blessing = reward.blessingChoices[0];
            BlessingManager.Instance.AddBlessing(blessing, target);
        }
    }
}
