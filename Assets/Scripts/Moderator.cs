using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System.Data;
using UnityEngine.UI;

public class Moderator : MonoBehaviour
{
    
    ArrayList cartasPiramide = new ArrayList();
    private MySqlConnection conexion;
    private MySqlCommand consola;
    public float timeRemaining;
    private bool gamerunning; 
    private SpriteRenderer rend;
    private Sprite cardNew;
    int i = 0;  
    void Start()
    {
        try
        {

            string DataConecction = "Server=beerorstain20.mysql.database.azure.com; Port=3306; Database=bosdb; Uid=adminbos@beerorstain20; Pwd=*camaja20*; SslMode=Preferred;";
            //string Query = "SELECT nombreCarta FROM bosdb.cartapiramide WHERE idPartida = "+DatosGlobales.IdPartida+";";
            string Query = "SELECT nombre FROM bosdb.cartajugador WHERE idPartida = 4044 AND idJugador = 73;";

            conexion = new MySqlConnection(DataConecction);
            consola = new MySqlCommand(Query, conexion);

            string carta = "";
            conexion.Open();
            MySqlDataReader reader = consola.ExecuteReader();
            while (reader.Read())
            {
                carta = reader["nombre"].ToString();
                cartasPiramide.Add(carta);
            }
            conexion.Close();

        }
        catch (MySqlException ex)
        {
            Debug.LogError("Error: " + ex);
        }
        
    }

    
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
                timeRemaining = 5;
                if (i < 5)
                {
                    rend = GetComponent<SpriteRenderer>();
                    cardNew = Resources.Load<Sprite>("Images/" + cartasPiramide[i]);
                    rend.sprite = cardNew;
                    i = i+1;
                    transform.localScale = new Vector3(0.2156625f, 0.2178207f, 1f);
                    //----------------------INSERT CARTA PARA JUGADORES-------------------------                 

                }

            }
        }


    }

    public void ChangeGameRunningState()
    {
        gamerunning = !gamerunning;
    }
}
