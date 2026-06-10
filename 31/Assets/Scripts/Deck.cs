using UnityEngine;

public class Deck : MonoBehaviour
{
    public Cards[] cards;
    void Awake()
    {
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       ShuffleDeck(); 
       Debug.Log(cards);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShuffleDeck()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            int randomIndex = Random.Range(0, cards.Length);
            Cards temp = cards[i];
            cards[i] = cards[randomIndex];
            cards[randomIndex] = temp;
        }
    }
    
}
