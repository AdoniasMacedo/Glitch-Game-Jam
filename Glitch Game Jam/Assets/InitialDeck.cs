using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InitialDeck : MonoBehaviour
{
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Transform cardsParent;
    [SerializeField] private List<CardData> initialCards;

    public void SetDeck()
    {
        StartCoroutine(ShowCards());
    }
    
    public IEnumerator ShowCards()
    {
        for (int i = 0; i < initialCards.Count; i++)
        {
            Card card = Instantiate(cardPrefab, cardsParent).GetComponent<Card>();
            card.SetCardData(initialCards[i]);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
