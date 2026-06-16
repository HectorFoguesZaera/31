using UnityEngine;

public class CardView : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Cards cardData;

    public void SetCardData(Cards card)
    {
        cardData = card;
        spriteRenderer.sprite = card.cardImage;
    }
}
