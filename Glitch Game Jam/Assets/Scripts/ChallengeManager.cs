using System.Collections.Generic;
using UnityEngine;

public class ChallengeManager : MonoBehaviour
{
    public List<Challenge> activeChallenges;

    private Dictionary<Challenge, bool> challengeStatus;

    void Start()
    {
        challengeStatus = new Dictionary<Challenge, bool>();
        foreach (var challenge in activeChallenges)
        {
            challengeStatus[challenge] = false;
        }
    }

    void Update()
    {
        foreach (var challenge in activeChallenges)
        {
            if (!challengeStatus[challenge] && challenge.IsCompleted(GameState.Instance))
            {
                challengeStatus[challenge] = true;
                Debug.Log($"Challenge completed: {challenge.description}");
            }
        }
    }
}
