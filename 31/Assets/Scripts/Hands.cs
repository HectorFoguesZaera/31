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
    public bool isTurn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isTurn){
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DrawDiscard();
            }
        }
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

    public void DrawCard()
    {
        
    }

    public void DrawDiscard()
    {
        if (firstPlayer)
        {
            GameObject discardScript = GameObject.Find("FirstDiscard");
            Cards drawnCard = discardScript.GetComponent<Discards>().discardCards.Pop();
            handCards[4] = drawnCard;
            CardView card = Instantiate(cardPrefab, hands[4].transform.position, Quaternion.identity, hands[4].transform);
            card.transform.localScale = new Vector3(2, 2, 2);        
            card.SetCardData(handCards[4]);
            firstPlayer = false;
        }
        else
        {
            handCards[4] = drawDiscard.discardCards.Pop();
            CardView card = Instantiate(cardPrefab, hands[4].transform.position, Quaternion.identity, hands[4].transform);
            card.transform.localScale = new Vector3(2, 2, 2);        
            card.SetCardData(handCards[4]);
        }
    }


}
