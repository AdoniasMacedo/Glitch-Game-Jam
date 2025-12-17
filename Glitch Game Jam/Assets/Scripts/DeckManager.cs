using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    private static DeckManager _instance;
    public static DeckManager Instance => _instance;

    public List<Card> deck = new List<Card>();

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
}
