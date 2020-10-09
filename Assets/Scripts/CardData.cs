using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardData : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

    void Cards()
    {
        cardList.Add(new Card(0,"CERO","Carta normal del juego"));
        cardList.Add(new Card(1, "UNO", "Carta normal del juego"));
        cardList.Add(new Card(2, "DOS", "Carta normal del juego"));
        cardList.Add(new Card(3, "TRES", "Carta normal del juego"));
        cardList.Add(new Card(4, "CUATRO", "Carta normal del juego"));
        cardList.Add(new Card(5, "CINCO", "Carta normal del juego"));
        cardList.Add(new Card(6, "SEIS", "Carta normal del juego"));
        cardList.Add(new Card(7, "SIETE", "Carta normal del juego"));
        cardList.Add(new Card(8, "OCHO", "Carta normal del juego"));
        cardList.Add(new Card(9, "NUEVE", "Carta normal del juego"));
    }
}
