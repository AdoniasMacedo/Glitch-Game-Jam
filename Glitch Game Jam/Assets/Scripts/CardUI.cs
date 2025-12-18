using System;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    public event Action<CardData, bool> onCardSelected;
    private CardData _cardData;
    private bool _isSelected;

    public void SetCard(CardData cardData)
    {
        _cardData = cardData;
        // Update UI elements with card data
    }

    public void OnPointerClick()
    {
        _isSelected = !_isSelected;
        onCardSelected?.Invoke(_cardData, _isSelected);
        // Update UI to reflect selection
    }
}
