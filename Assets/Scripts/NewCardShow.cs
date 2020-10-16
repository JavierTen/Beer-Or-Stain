using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System.Data;
using UnityEngine.UI;



public class NewCardShow : MonoBehaviour
{

    private SpriteRenderer rend;
    private Sprite cardNew;
    // Update is called once per frame
    public float timeRemaining = 10;
    private bool gamerunning;

    string idJugador = "";
    int i = 0;
    private MySqlConnection conexion;
    private MySqlCommand consola;

    ArrayList cardspiramide = new ArrayList();

    /* void Awake()
     {
         try
         {

             string DataConecction = "Server=beerorstain20.mysql.database.azure.com; Port=3306; Database=bosdb; Uid=adminbos@beerorstain20; Pwd=*camaja20*; SslMode=Preferred;";
             string Query = "SELECT idJugador FROM bosdb.jugador WHERE idPartida = " + DatoUsuarios.idPartida + " AND nombre = '" + DatoUsuarios.Nick + "';";

             conexion = new MySqlConnection(DataConecction);
             consola = new MySqlCommand(Query, conexion);


             conexion.Open();
             MySqlDataReader reader = consola.ExecuteReader();
             while (reader.Read())
             {
                 idJugador = reader["idJugador"].ToString();

             }

             Debug.Log(idJugador);
             conexion.Close();

         }
         catch (MySqlException ex)
         {
             Debug.LogError("Error: " + ex);
         }
     }*/
    void Start()
    {
        try
        {

            string DataConecction = "Server=beerorstain20.mysql.database.azure.com; Port=3306; Database=bosdb; Uid=adminbos@beerorstain20; Pwd=*camaja20*; SslMode=Preferred;";
            string Query = "SELECT nombre FROM bosdb.cartajugador WHERE idPartida = 4044 AND idJugador = 73;";

            conexion = new MySqlConnection(DataConecction);
            consola = new MySqlCommand(Query, conexion);

            string carta = "";
            conexion.Open();
            MySqlDataReader reader = consola.ExecuteReader();
            while (reader.Read())
            {
                carta = reader["nombre"].ToString();
                cardspiramide.Add(carta);
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
                timeRemaining = 20;
                if (i < 5)
                {
                    DatosGlobales.CartaMostrada = cardspiramide[i].ToString();
                    rend = GetComponent<SpriteRenderer>();
                    cardNew = Resources.Load<Sprite>("Images/" + cardspiramide[i] + "");
                    rend.sprite = cardNew;
                    i = i+1;
                    transform.localScale = new Vector3(0.2156625f, 0.2178207f, 1f);
                }

            }
        }

    }

    void CartaMostrar()
    {

    }

    public void ChangeGameRunningState()
    {
        gamerunning = !gamerunning;
    }
}
