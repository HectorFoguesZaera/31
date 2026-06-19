using UnityEngine;
using System.Collections.Generic;

public class Deck : MonoBehaviour
{
    public List<Cards> cardsList;

    private Stack<Cards> cards;
    void Awake()
    {
       ShuffleDeck(); 

       cards = new Stack<Cards>();

       foreach (Cards card in cardsList)
        {
            cards.Push(card);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Cards DrawCard()
    {
        if (cards.Count == 0)
        {
            return null;
        }
        return cards.Pop();
    }

    public void ShuffleDeck()
    {
        for (int i = 0; i < cardsList.Count; i++)
        {
            int randomIndex = Random.Range(i, cardsList.Count);
            Cards temp = cardsList[i];
            cardsList[i] = cardsList[randomIndex];
            cardsList[randomIndex] = temp;
        }
    }
    
}
