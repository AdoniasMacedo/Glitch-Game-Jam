using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.UI;

public class CardInHand:MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private SplineContainer splineContainer;
    private List<GameObject> cardsInHand = new();

    public void DrawHand(CardData cardData)
    {
        var c = Instantiate(prefab, spawnPoint);
        cardsInHand.Add(c);

        c.GetComponent<SpriteRenderer>().sprite = cardData.cardSprite;
        UpdateCardPositions();
    }
    
    private void UpdateCardPositions()
    {
        if (cardsInHand.Count == 0)
        {
            return;
        }

        float cardSpacing = 1f / 7;
        float firstCardPosition = 0.5f - (cardsInHand.Count - 1) * cardSpacing / 2;
        Spline spline = splineContainer.Spline;

        for (int i = 0; i < cardsInHand.Count; i++)
        {
            float p = firstCardPosition + i * cardSpacing;
            Vector3 splinePosition = spline.EvaluatePosition(p);
            Vector3 foward = spline.EvaluateTangent(p);
            Vector3 up = spline.EvaluateUpVector(p);
            Quaternion rotation = Quaternion.LookRotation(up, Vector3.Cross(up, foward).normalized);
            cardsInHand[i].transform.DOMove(new(splinePosition.x, splinePosition.y + 1.5f, splinePosition.z), 1f);
            cardsInHand[i].transform.DOLocalRotateQuaternion(rotation, 1f);
        }
    }
}