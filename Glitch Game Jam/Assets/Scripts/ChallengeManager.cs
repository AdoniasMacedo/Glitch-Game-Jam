using UnityEngine;

public class ChallengeManager : MonoBehaviour
{
    public Challenge activeChallenge;

    private void Start()
    {
        if (activeChallenge != null)
        {
            activeChallenge.Setup();
        }
    }

    private void Update()
    {
        if (activeChallenge != null && activeChallenge.IsCompleted())
        {
            Debug.Log("Challenge Completed: " + activeChallenge.challengeName);
            activeChallenge.Teardown();
            activeChallenge = null;
        }
    }

    private void OnDestroy()
    {
        if (activeChallenge != null)
        {
            activeChallenge.Teardown();
        }
    }
}
