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
                player.hand[i] = deck.cards[0];
                deck.cards.RemoveAt(0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
