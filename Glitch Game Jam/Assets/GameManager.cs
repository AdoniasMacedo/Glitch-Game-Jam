using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Transform cardsParent;
    [SerializeField] private List<Card> cardsData;

    public void StartCardDeck()
    {
        StartCoroutine(StartGame());
    }
    
    public IEnumerator StartGame()
    {
        yield return new WaitForSeconds(2);
        
        for (int i = 0; i < cardsData.Count; i++)
        {
            Instantiate(cardPrefab, cardsParent);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
