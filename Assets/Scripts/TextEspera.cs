using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEspera : MonoBehaviour
{
    public GameObject UserName;
    public GameObject btnjoin;
    public GameObject UserNamee;
    public Text texto_cuadro;
    public GameObject cuadro;

    private int click = 0;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    public void Showtext()
    {
        if (click == 0)
        {
            cuadro.SetActive(true);
            UserName.SetActive(false);
            UserNamee.SetActive(false);
            btnjoin.SetActive(false);
            click = +1;
        }
        else
        {
            cuadro.SetActive(false);
            UserName.SetActive(true);
            UserNamee.SetActive(true);
            btnjoin.SetActive(true);
            click = 0;
        }
    }
}
