using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using System.Data;




public class ShowIdMatch : MonoBehaviour
{
    private MySqlConnection conexion;
    private MySqlCommand consola;
    int r;
    public Text idPartida;
    public Text jugadores;

    ArrayList cards = new ArrayList();


    void Start()
    {
        MostrarIdPartida();
        
        cards.Add("B0");
        cards.Add("B1");
        cards.Add("B2");
        cards.Add("B3");
        cards.Add("B4");
        cards.Add("B5");
        cards.Add("B6");
        cards.Add("B7");
        cards.Add("B8");
        cards.Add("B9");
        cards.Add("Y0");
        cards.Add("Y1");
        cards.Add("Y2");
        cards.Add("Y3");
        cards.Add("Y4");
        cards.Add("Y5");
        cards.Add("Y6");
        cards.Add("Y7");
        cards.Add("Y8");
        cards.Add("Y9");
        cards.Add("G0");
        cards.Add("G1");
        cards.Add("G2");
        cards.Add("G3");
        cards.Add("G4");
        cards.Add("G5");
        cards.Add("G6");
        cards.Add("G7");
        cards.Add("G8");
        cards.Add("G9");
        cards.Add("R0");
        cards.Add("R1");
        cards.Add("R2");
        cards.Add("R3");
        cards.Add("R4");
        cards.Add("R5");
        cards.Add("R6");
        cards.Add("R7");
        cards.Add("R8");
        cards.Add("R9");
    }



    public float timeRemaining = 1;
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
                timeRemaining = 1;
                try
                {
                    
                    string DataConecction = "Server=beerorstain20.mysql.database.azure.com; Port=3306; Database=bosdb; Uid=adminbos@beerorstain20; Pwd=*camaja20*; SslMode=Preferred;";
                    string Query = "SELECT nombre FROM bosdb.jugador where idPartida = "+r+";";

                    conexion = new MySqlConnection(DataConecction);
                    consola = new MySqlCommand(Query, conexion);



                    string nicks = "";
                    conexion.Open();
                    MySqlDataReader reader = consola.ExecuteReader();
                    while (reader.Read())
                    {
                        nicks = nicks + reader["nombre"]+"\n";
                        
                    }
                    jugadores.text = nicks.ToString();
                    
                    conexion.Close();

                }
                catch (MySqlException ex)
                {

                    Debug.LogError("Error: " + ex);
                }
            }
        }



    }

    void MostrarIdPartida()
    {
        try
        {
            
            string DataConecction = "Server=beerorstain20.mysql.database.azure.com; Port=3306; Database=bosdb; Uid=adminbos@beerorstain20; Pwd=*camaja20*; SslMode=Preferred;";
            string Query = "SELECT * FROM bosdb.partida ORDER BY  idPartida desc limit 1";

            conexion = new MySqlConnection(DataConecction);
            consola = new MySqlCommand(Query, conexion);

            int r = Random.Range(0,3);

            conexion.Open();
            object result = consola.ExecuteScalar();
            if (result != null)
            {
                
                idPartida.text = r.ToString();
                
            }
            conexion.Close();

        }
        catch (MySqlException ex)
        {

            Debug.LogError("Error: " + ex);
        }
    }

    public void ActualizarEstado()
    {
        try
        {

            string DataConecction = "Server=beerorstain20.mysql.database.azure.com; Port=3306; Database=bosdb; Uid=adminbos@beerorstain20; Pwd=*camaja20*; SslMode=Preferred;";
            string Query = "UPDATE bosdb.partida SET estado = 1 WHERE idPartida = "+r+";";

            conexion = new MySqlConnection(DataConecction);
            consola = new MySqlCommand(Query, conexion);

            conexion.Open();
            consola.ExecuteScalar();
            conexion.Close();

        }
        catch (MySqlException ex)
        {

            Debug.LogError("Error: " + ex);
        }
    }

    //public void RepartirCartas()
    //{
    //    try
    //    {

    //        for (int i = 0; i < 15; i++)
    //        {

    //            int mIndex = Random.Range(0,39);
                
    //            string DataConecction = "Server=beerorstain20.mysql.database.azure.com; Port=3306; Database=bosdb; Uid=adminbos@beerorstain20; Pwd=*camaja20*; SslMode=Preferred;";
    //            string Query = "INSERT INTO bosdb.cartapiramide (nombreCarta, idPartida) VALUES ('" + cards[mIndex] + "',"+r+");";
                

    //            conexion = new MySqlConnection(DataConecction);
    //            consola = new MySqlCommand(Query, conexion);

    //            conexion.Open();
    //            consola.ExecuteReader();
    //            conexion.Close();
    //        }

            
            

    //        conexion.Close();


    //    }
    //    catch (MySqlException ex)
    //    {

    //        Debug.LogError("Error: " + ex);
    //    }
    //}
}
