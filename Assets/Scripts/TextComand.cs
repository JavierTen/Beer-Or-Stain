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
        texto_cuadro.text = content_text;
        cuadro.SetActive(true);
        btn.SetActive(true);
        
    }
    public void CerrarText()
    {
        cuadro.SetActive(false);
        btn.SetActive(true);
    }

    
}
