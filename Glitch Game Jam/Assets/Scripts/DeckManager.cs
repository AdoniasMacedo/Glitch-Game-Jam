using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Splines;

public class DeckManager : MonoBehaviour
{
    private static DeckManager _instance;
    public static DeckManager Instance => _instance;

    public CardInHand cardInHand;

    public List<CardData> deck = new List<CardData>();
    public List<CardData> hand = new List<CardData>();
    public List<CardData> discardPile = new List<CardData>();

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

    public void AddCard(CardData cardData)
    {
        deck.Add(cardData);
        Debug.Log("Card added to deck: " + cardData.name);
    }

    public CardData DrawCard()
    {
        if (deck.Count == 0)
        {
            // Reshuffle discard pile into deck
            deck.AddRange(discardPile);
            discardPile.Clear();
        }

        CardData card = deck[0];
        deck.RemoveAt(0);
        hand.Add(card);
        return card;
    }

    [Button]
    public void DrawInitialHand()
    {
        for (int i = 0; i < 7; i++)
        {
            cardInHand.DrawHand(DrawCard());
        }
    }

    public void Mulligan(List<CardData> cardsToReturn)
    {
        foreach (var card in cardsToReturn)
        {
            hand.Remove(card);
            deck.Add(card);
        }

        // Shuffle deck
        for (int i = 0; i < deck.Count; i++)
        {
            CardData temp = deck[i];
            int randomIndex = Random.Range(i, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }

        for (int i = 0; i < cardsToReturn.Count; i++)
        {
            DrawCard();
        }
    }
}
