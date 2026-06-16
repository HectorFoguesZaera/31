using Unity.VisualScripting;
using UnityEngine;

public class Hands : MonoBehaviour
{

    public Cards[] handCards;
    public GameObject[] hands;
    public Discards discard;
    public Discards drawDiscard;
    public int pointsHand;
    public bool firstPlayer;
    public CardView cardPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Aqui toca hacer lo de robar

    //Aqui toca hacer lo de instanciar las cartas en los objetos vacios
    public void InstantiateCards()
    {
        for (int i = 0; i < handCards.Length; i++)
        {
           CardView card = Instantiate(cardPrefab, hands[i].transform.position, Quaternion.identity, hands[i].transform);
           card.transform.localScale = new Vector3(2, 2, 2);        
           card.SetCardData(handCards[i]);
        }
    }


}
