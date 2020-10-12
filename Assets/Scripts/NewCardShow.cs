using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCardShow : MonoBehaviour
{
    public Sprite cardNew;
    // Update is called once per frame
    float x, y, z;
    public float timeRemaining = 10;

    void Update()
    {

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        { 
            timeRemaining = 10;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = cardNew;
            transform.localScale = new Vector3(0.2156625f, 0.2178207f, 1f);
        }

    }
}
