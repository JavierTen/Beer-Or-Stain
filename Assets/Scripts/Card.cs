using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int id;
    public string cardName;
    public string cardDescription;

    public Card() { }

    public Card(int Id, string CardName, string CardDescription)
    {
        id = Id;
        cardName = CardName;
        cardDescription = CardDescription;
    }
}
