using System.Collections;
using System.Collections.Generic;
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

    public IEnumerator PresentRewardChoice(Reward reward, GameObject target)
    {
        Debug.Log("Choose your reward:");
        var choices = new List<object>();
        int choiceIndex = 1;

        if (reward.cardChoices != null)
        {
            foreach (var card in reward.cardChoices)
            {
                Debug.Log(choiceIndex + ": [Card] " + card.name);
                choices.Add(card);
                choiceIndex++;
            }
        }

        if (reward.blessingChoices != null)
        {
            foreach (var blessing in reward.blessingChoices)
            {
                Debug.Log(choiceIndex + ": [Blessing] " + blessing.name);
                choices.Add(blessing);
                choiceIndex++;
            }
        }

        bool choiceMade = false;
        while (!choiceMade)
        {
            for (int i = 0; i < choices.Count; i++)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1 + i))
                {
                    var selectedChoice = choices[i];
                    if (selectedChoice is Card card)
                    {
                        DeckManager.Instance.AddCard(card);
                        Debug.Log("Player selected card: " + card.name);
                    }
                    else if (selectedChoice is Blessing blessing)
                    {
                        BlessingManager.Instance.AddBlessing(blessing, target);
                        Debug.Log("Player selected blessing: " + blessing.name);
                    }
                    choiceMade = true;
                    break;
                }
            }
            yield return null;
        }
    }

    public void TriggerReward(Reward reward, GameObject target)
    {
        if (reward != null)
        {
            StartCoroutine(PresentRewardChoice(reward, target));
        }
    }
}
