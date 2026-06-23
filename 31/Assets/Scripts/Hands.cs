using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;

public class Hands : MonoBehaviour
{
    //public Cards[] handCards;
    public List<Cards> handCards = new List<Cards>();
    public GameObject[] hands;
    public Discards discard;
    public Discards drawDiscard;
    public int pointsHand;
    public bool firstPlayer;
    public CardView cardPrefab;
    public bool isTurn;
    public bool hasDrawnCard = false;
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
        else
        {
            hasDrawnCard = false;
        }
    }

    //Aqui toca hacer lo de robar

    //Aqui toca hacer lo de instanciar las cartas en los objetos vacios
    public void InstantiateCards()
    {
        for (int i = 0; i < handCards.Count; i++)
        {
           CardView card = Instantiate(cardPrefab, hands[i].transform.position, Quaternion.identity, hands[i].transform);
           card.transform.localScale = new Vector3(2, 2, 2);        
           card.SetCardData(handCards[i]);
        }
    }

    public void DrawCard()
    {
        if (isTurn)
        {
             //QUiero que robe y cuando tenga 4 que no pueda hacer otra cosa que descartar(apagar botones de robar y encender boton de descartar)
            //Ver como hacer que haga pop de verdad del mazo
            if (!hasDrawnCard)
            {
                firstPlayer = false;
                GameObject deckScript = GameObject.Find("Deck");
                Cards drawnCard = deckScript.GetComponent<Deck>().DrawCard();
                handCards.Add(drawnCard);
                CardView card = Instantiate(cardPrefab, hands[3].transform.position, Quaternion.identity, hands[3].transform);
                card.transform.localScale = new Vector3(2, 2, 2);
                card.SetCardData(drawnCard); 
                hasDrawnCard = true;
            }
        }
    }

    public void DrawDiscard()
    {
        if(isTurn){
            if (firstPlayer)
            {
                if (!hasDrawnCard)
                {
                    GameObject discardScript = GameObject.Find("FirstDiscard");
                    Cards drawnCard = discardScript.GetComponent<Discards>().discardCards.Pop();
                    handCards.Add(drawnCard);
                    Debug.Log("Esto funciona #");
                    CardView card = Instantiate(cardPrefab, hands[3].transform.position, Quaternion.identity, hands[3].transform);
                    Debug.Log("Esto funciona ####");
                    card.transform.localScale = new Vector3(2, 2, 2);        
                    //card.SetCardData(handCards[4]);
                    card.SetCardData(drawnCard);
                    firstPlayer = false;
                    //Destruir el objeto hijo 
                    Destroy(discardScript.transform.GetChild(0).gameObject);
                    hasDrawnCard = true;
                }
               
            }
            else
            {
                if (!hasDrawnCard)
                {
                    firstPlayer = false;
                    Cards drawnCard = drawDiscard.discardCards.Pop();
                    handCards.Add(drawnCard);

                    CardView card = Instantiate(cardPrefab, hands[3].transform.position, Quaternion.identity, hands[3].transform);
                    card.transform.localScale = new Vector3(2, 2, 2);        
                    card.SetCardData(drawnCard);
                    hasDrawnCard = true;
                }
               
            }
        }
       
    }


}
