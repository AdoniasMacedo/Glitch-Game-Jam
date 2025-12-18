using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MulliganUI : MonoBehaviour
{
    public GameObject mulliganPanel;
    public Button confirmButton;
    public List<CardUI> cardUIs; // Assuming a CardUI component exists

    private List<CardData> _cardsToReturn = new List<CardData>();

    void Start()
    {
        confirmButton.onClick.AddListener(ConfirmMulligan);
        DisplayInitialHand();
    }

    void DisplayInitialHand()
    {
        mulliganPanel.SetActive(true);
        for (int i = 0; i < DeckManager.Instance.hand.Count; i++)
        {
            //cardUIs[i].SetCard(DeckManager.Instance.hand[i]);
            cardUIs[i].onCardSelected += OnCardSelected;
        }
    }

    void OnCardSelected(CardData cardData, bool isSelected)
    {
        if (isSelected)
        {
            _cardsToReturn.Add(cardData);
        }
        else
        {
            _cardsToReturn.Remove(cardData);
        }
    }

    void ConfirmMulligan()
    {
        //DeckManager.Instance.Mulligan(_cardsToReturn);
        mulliganPanel.SetActive(false);
        CombatManager.Instance.state = CombatState.PLAYERTURN;
    }
}
