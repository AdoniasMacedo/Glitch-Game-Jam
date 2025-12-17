using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState Instance { get; private set; }

    public int currentRound;
    public int destroyedCreatures;
    public int playedCards;
    public int creaturesOnBoard;
    public List<Card> destroyedCreaturesList = new List<Card>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void IncrementRounds()
    {
        currentRound++;
    }

    public void IncrementDestroyedCreatures()
    {
        destroyedCreatures++;
    }

    public void AddDestroyedCreature(Card creature)
    {
        if (!destroyedCreaturesList.Contains(creature))
        {
            destroyedCreaturesList.Add(creature);
        }
    }

    public void IncrementPlayedCards()
    {
        playedCards++;
    }

    public void SetCreaturesOnBoard(int count)
    {
        creaturesOnBoard = count;
    }
}
