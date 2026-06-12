using UnityEngine;
using System.Collections.Generic;

public class Deck : MonoBehaviour
{
    public List<Cards> cards;
    void Awake()
    {
       ShuffleDeck(); 
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShuffleDeck()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            int randomIndex = Random.Range(0, cards.Count);
            Cards temp = cards[i];
            cards[i] = cards[randomIndex];
            cards[randomIndex] = temp;
        }
    }
    
}
