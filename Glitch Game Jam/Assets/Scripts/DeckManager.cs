using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Splines;

public class DeckManager : MonoBehaviour
{
    private static DeckManager _instance;
    public static DeckManager Instance => _instance;

    public SplineContainer splineContainer;

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

    public void AddCard(Card cardData)
    {
        deck.Add(cardData);
        Debug.Log("Card added to deck: " + cardData.name);
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

    private void UpdateCardPositions()
    {
        if (hand.Count == 0)
        {
            return;
        }

        float cardSpacing = 1f / 7;
        float firstCardPosition = 0.5f - (hand.Count - 1) * cardSpacing / 2;
        Spline spline = splineContainer.Spline;

        for (int i = 0; i < hand.Count; i++)
        {
            float p = firstCardPosition + i * cardSpacing;
            Vector3 splinePosition = spline.EvaluatePosition(p);
            Vector3 foward = spline.EvaluateTangent(p);
            Vector3 up = spline.EvaluateUpVector(p);
            Quaternion rotation = Quaternion.LookRotation(up, Vector3.Cross(up, foward).normalized);
            hand[i].transform.DOMove(splinePosition, 0.25f);
            hand[i].transform.DOLocalRotateQuaternion(rotation, 0.25f);
        }
    }

    [Button]
    public void DrawInitialHand()
    {
        for (int i = 0; i < 7; i++)
        {
            DrawCard();
            UpdateCardPositions();
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
