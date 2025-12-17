using System;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    public event Action<Card, bool> onCardSelected;
    private Card _card;
    private bool _isSelected;

    public void SetCard(Card card)
    {
        _card = card;
        // Update UI elements with card data
    }

    public void OnPointerClick()
    {
        _isSelected = !_isSelected;
        onCardSelected?.Invoke(_card, _isSelected);
        // Update UI to reflect selection
    }
}
