using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextComand : MonoBehaviour
{
    public string content_text = "Alguien tiene la carta!!";
    public Text texto_cuadro;
    public GameObject cuadro;
    public GameObject btn;

    private int click = 0;

    // Start is called before the first frame update
    void Start()
    {
        cuadro.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Showtext()
    {
        if (click == 0)
        {
            texto_cuadro.text = content_text;
            cuadro.SetActive(true);
            click =+ 1;
        }
        else
        {
            cuadro.SetActive(false);
            click = 0;
        }              
    }


    
}
