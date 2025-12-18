using UnityEngine;
using UnityEngine.UI;

public class Card:MonoBehaviour
{
    [SerializeField] private Image cardFront;
    private CardData data;
    public CardData Data => data;

    public void SetCardData(CardData cardData)
    {
        data = Instantiate(cardData);
        cardFront.sprite = data.cardSprite;
    }
}