using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ThisCard : MonoBehaviour
{

    public List<Card> thisCard = new List<Card>();
    public int thisId;

    public int id;
    public string cardName;
    public string cardDescription;

    public Text nameText;

    void Start()
    {
        thisCard[0] = CardData.cardList[thisId];
    }

   
    void Update()
    {
        id = thisCard[0].id;
        cardName = thisCard[0].cardName;
        cardDescription = thisCard[0].cardDescription;

        nameText.text = ""+nameText;
    }
}
