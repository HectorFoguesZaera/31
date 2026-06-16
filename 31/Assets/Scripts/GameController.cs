using UnityEngine;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public List<Hands> players;
    public Deck deck;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (Hands player in players)
        {
            for (int i = 0; i < 3; i++)
            {
                player.handCards[i] = deck.cards[0];
                deck.cards.RemoveAt(0);
            }
            player.InstantiateCards();
        }

        GetPoints();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetPoints()
    {
       foreach (Hands player in players)
        {
            //Aqui se tiene que comprobar el palo, si coincide se suma
            Dictionary<Cards.CardType, int> pointsByType = new();

            for (int i = 0; i < player.handCards.Length; i++)
            {
                Cards card = player.handCards[i];

                if (!pointsByType.ContainsKey(card.cardType))
                {
                    pointsByType[card.cardType] = 0;
                }
                pointsByType[card.cardType] += card.points;
            }

            int totalPoints = 0;

            foreach (var pointsValue in pointsByType)
            {
                if (pointsValue.Value > totalPoints)
                {
                    totalPoints = pointsValue.Value;
                }
            }

            player.pointsHand = totalPoints;
        } 
    }
}
