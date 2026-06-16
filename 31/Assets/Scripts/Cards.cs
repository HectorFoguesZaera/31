using UnityEngine;

[CreateAssetMenu(fileName = "Cards", menuName = "Scriptable Objects/Cards")]
public class Cards : ScriptableObject
{
    public Sprite cardImage;
    public Sprite reverseImage;
    public int num;
    public int points;
    public enum CardType { Bastos, Oros, Copas, Espadas }
    public CardType cardType;   
}
