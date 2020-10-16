using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCardShow : MonoBehaviour
{
    
    public Sprite cardNew;
    // Update is called once per frame
    float x, y, z;
    public float timeRemaining = 10;
    private bool gamerunning;

    

    void Update()
    {
        if (!gamerunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
<<<<<<< Updated upstream
                timeRemaining = 10;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = cardNew;
                transform.localScale = new Vector3(0.2156625f, 0.2178207f, 1f);
=======
                timeRemaining = 20;
                if (i < 5)
                {
                    DatosGlobales.CartaMostrada = cardspiramide[i].ToString();
                    rend = GetComponent<SpriteRenderer>();
                    cardNew = Resources.Load<Sprite>("Images/" + cardspiramide[i]);
                    rend.sprite = cardNew;
                    i = i+1;
                    transform.localScale = new Vector3(0.2156625f, 0.2178207f, 1f);
                }

>>>>>>> Stashed changes
            }
        }
        
        

    }
<<<<<<< Updated upstream
=======


>>>>>>> Stashed changes
    public void ChangeGameRunningState()
    {
        
        gamerunning = !gamerunning;

        if (gamerunning)
        {
            Debug.Log("Game corriendo");
        }
        else
        {
            Debug.Log("game paused");
        }
    }
}
