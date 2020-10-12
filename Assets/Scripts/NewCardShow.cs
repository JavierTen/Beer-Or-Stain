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
            Debug.Log("Time has run out!");
            timeRemaining = 10;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = cardNew;
            x = 0.2156625f;
            y = 0.2178207f;
            z = 1f;
            transform.localScale = new Vector3(x, y, z);
        }
        //x = 0.2135238;
        //y = 0.2194251;
        //z = 1;
        //this.gameObject.GetComponent<SpriteRenderer>().sprite = cardNew;
        //transform.localScale = new Vector3 (x,y,z);
    }
}
