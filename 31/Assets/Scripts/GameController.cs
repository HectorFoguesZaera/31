using UnityEngine;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public List<Hands> players;
    public Deck deck;
    
    public Discards firstDiscards;
    public CardView cardPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       StartRound();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            NextPlayerTurn();
        }
    }

    public void NextPlayerTurn()
    {
        bool notFoundPlayer = false;
        bool foundCurrentPlayer = false;
        foreach (Hands player in players)
        {
            if (player.isTurn)
            {
                foundCurrentPlayer = true;
                player.isTurn = false;
            }else if (foundCurrentPlayer)
            {
                player.isTurn = true;
                foundCurrentPlayer = false;
                notFoundPlayer = true;
            }
        }
        if (!notFoundPlayer)
        {
            players[0].isTurn = true;
        }
    }

    public void StartRound()
    {
        foreach (Hands player in players)
        {
            player.handCards.Clear();
            for (int i = 0; i < 3; i++)
            {
                player.handCards.Add(deck.DrawCard());
            }
            player.InstantiateCards();
        }
        Cards startCard = deck.DrawCard();
        firstDiscards.discardCards.Push(startCard);
        CardView card = Instantiate(cardPrefab, firstDiscards.transform.position, Quaternion.identity, firstDiscards.transform);
        card.transform.localScale = new Vector3(1, 1, 1);
        card.SetCardData(startCard);

        /*
        firstDiscards.discardCards.Push(deck.cards[0]);
        deck.cards.RemoveAt(0);
        CardView card = Instantiate(cardPrefab, firstDiscards.transform.position, Quaternion.identity, firstDiscards.transform);
        card.transform.localScale = new Vector3(1, 1, 1);        
        card.SetCardData(firstDiscards.discardCards.Peek());
*/
        GetPoints();
    }

    public void GetPoints()
    {
       foreach (Hands player in players)
        {
            //Aqui se tiene que comprobar el palo, si coincide se suma
            Dictionary<Cards.CardType, int> pointsByType = new();

            foreach (Cards card in player.handCards)
            {
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
