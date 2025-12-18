using DG.Tweening;
using UnityEngine;

public class FlipCardAnimation:MonoBehaviour
{
    public void FlipCard()
    {
        if (DeckManager.Instance.deck.Count >= 7) return;
        
        var t = GetComponent<RectTransform>();
        t.DOLocalRotate(new(0f, 0f, 0f), 0.25f);

        var cardData = GetComponent<Card>().Data;
        DeckManager.Instance.AddCard(cardData);
    }
}