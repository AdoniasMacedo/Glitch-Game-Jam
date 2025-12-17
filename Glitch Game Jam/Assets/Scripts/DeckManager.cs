using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    private static DeckManager _instance;
    public static DeckManager Instance => _instance;

    public List<Card> deck = new List<Card>();
    public List<Card> hand = new List<Card>();
    public List<Card> discardPile = new List<Card>();

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

    public void AddCard(Card card)
    {
        deck.Add(card);
        Debug.Log("Card added to deck: " + card.name);
    }

    public Card DrawCard()
    {
        if (deck.Count == 0)
        {
            // Reshuffle discard pile into deck
            deck.AddRange(discardPile);
            discardPile.Clear();
        }

        Card card = deck[0];
        deck.RemoveAt(0);
        hand.Add(card);
        return card;
    }

    public void DrawInitialHand()
    {
        for (int i = 0; i < 7; i++)
        {
            DrawCard();
        }
    }

    public void Mulligan(List<Card> cardsToReturn)
    {
        foreach (var card in cardsToReturn)
        {
            hand.Remove(card);
            deck.Add(card);
        }

        // Shuffle deck
        for (int i = 0; i < deck.Count; i++)
        {
            Card temp = deck[i];
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
