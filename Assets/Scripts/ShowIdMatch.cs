using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using System.Data;
using System;


public class ShowIdMatch : MonoBehaviour
{
    private MySqlConnection conexion;
    private MySqlCommand consola;

    public Text idPartida;
    public Text jugadores;

    void Start()
    {
        MostrarIdPartida();
    }

    public float timeRemaining = 1;
    private bool gamerunning;

    //static var dPartida;

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
                timeRemaining = 10;
                try
                {
                    Debug.Log(idPartida);
                    string DataConecction = "Server=beerorstain20.mysql.database.azure.com; Port=3306; Database=bosdb; Uid=adminbos@beerorstain20; Pwd=*camaja20*; SslMode=Preferred;";
                    string Query = "SELECT nombre FROM bosdb.jugador where idPartida = 4018;";

                    conexion = new MySqlConnection(DataConecction);
                    consola = new MySqlCommand(Query, conexion);

                    conexion.Open();
                    object result = consola.ExecuteScalar();
                    if (result != null)
                    {


                        jugadores.text = result+"\n";
                        Debug.Log(jugadores);
                    }
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

            conexion.Open();
            object result = consola.ExecuteScalar();
            if (result != null)
            {
                int r = Convert.ToInt32(result);
                Debug.Log("ultima partida: " + r);
                idPartida.text = r.ToString();
                
            }
            conexion.Close();

        }
        catch (MySqlException ex)
        {

            Debug.LogError("Error: " + ex);
        }
    }
}
