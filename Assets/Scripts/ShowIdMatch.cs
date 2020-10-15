﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using System.Data;




public class ShowIdMatch : MonoBehaviour
{
    private MySqlConnection conexion;
    private MySqlCommand consola;
    string r = "";
    public Text idPartida;
    public Text jugadores;


    ArrayList cardspiramide = new ArrayList();
    ArrayList cardsplayers = new ArrayList();


    void Start()
    {
        MostrarIdPartida();

        cardspiramide.Add("B0");
        cardspiramide.Add("B1");
        cardspiramide.Add("B2");
        cardspiramide.Add("B3");
        cardspiramide.Add("B4");
        cardspiramide.Add("B5");
        cardspiramide.Add("B6");
        cardspiramide.Add("B7");
        cardspiramide.Add("B8");
        cardspiramide.Add("B9");
        cardspiramide.Add("Y0");
        cardspiramide.Add("Y1");
        cardspiramide.Add("Y2");
        cardspiramide.Add("Y3");
        cardspiramide.Add("Y4");
        cardspiramide.Add("Y5");
        cardspiramide.Add("Y6");
        cardspiramide.Add("Y7");
        cardspiramide.Add("Y8");
        cardspiramide.Add("Y9");
        cardspiramide.Add("G0");
        cardspiramide.Add("G1");
        cardspiramide.Add("G2");
        cardspiramide.Add("G3");
        cardspiramide.Add("G4");
        cardspiramide.Add("G5");
        cardspiramide.Add("G6");
        cardspiramide.Add("G7");
        cardspiramide.Add("G8");
        cardspiramide.Add("G9");
        cardspiramide.Add("R0");
        cardspiramide.Add("R1");
        cardspiramide.Add("R2");
        cardspiramide.Add("R3");
        cardspiramide.Add("R4");
        cardspiramide.Add("R5");
        cardspiramide.Add("R6");
        cardspiramide.Add("R7");
        cardspiramide.Add("R8");
        cardspiramide.Add("R9");

        cardsplayers.Add("B0");
        cardsplayers.Add("B1");
        cardsplayers.Add("B2");
        cardsplayers.Add("B3");
        cardsplayers.Add("B4");
        cardsplayers.Add("B5");
        cardsplayers.Add("B6");
        cardsplayers.Add("B7");
        cardsplayers.Add("B8");
        cardsplayers.Add("B9");
        cardsplayers.Add("Y0");
        cardsplayers.Add("Y1");
        cardsplayers.Add("Y2");
        cardsplayers.Add("Y3");
        cardsplayers.Add("Y4");
        cardsplayers.Add("Y5");
        cardsplayers.Add("Y6");
        cardsplayers.Add("Y7");
        cardsplayers.Add("Y8");
        cardsplayers.Add("Y9");
        cardsplayers.Add("G0");
        cardsplayers.Add("G1");
        cardsplayers.Add("G2");
        cardsplayers.Add("G3");
        cardsplayers.Add("G4");
        cardsplayers.Add("G5");
        cardsplayers.Add("G6");
        cardsplayers.Add("G7");
        cardsplayers.Add("G8");
        cardsplayers.Add("G9");
        cardsplayers.Add("R0");
        cardsplayers.Add("R1");
        cardsplayers.Add("R2");
        cardsplayers.Add("R3");
        cardsplayers.Add("R4");
        cardsplayers.Add("R5");
        cardsplayers.Add("R6");
        cardsplayers.Add("R7");
        cardsplayers.Add("R8");
        cardsplayers.Add("R9");

        cardsplayers.Add("RegA0");
        cardsplayers.Add("RegA1");
        cardsplayers.Add("RegA2");
        cardsplayers.Add("RegC0");
        cardsplayers.Add("RegC1");
        cardsplayers.Add("RegC2");
        cardsplayers.Add("RegJ0");
        cardsplayers.Add("RegJ1");
        cardsplayers.Add("RegJ2");
        cardsplayers.Add("RegM0");
        cardsplayers.Add("RegM1");
        cardsplayers.Add("RegM2");
        cardsplayers.Add("RegP0");
        cardsplayers.Add("RegP1");
        cardsplayers.Add("RegP2");
        cardsplayers.Add("RegU0");
        cardsplayers.Add("RegU1");
        cardsplayers.Add("RegU2");
        cardsplayers.Add("RegK0");
        cardsplayers.Add("RegK1");
        cardsplayers.Add("RegK2");
        cardsplayers.Add("RegN0");
        cardsplayers.Add("RegN1");
        cardsplayers.Add("RegN2");
        cardsplayers.Add("RegR0");
        cardsplayers.Add("RegR1");
        cardsplayers.Add("RegR2");
        cardsplayers.Add("RegV0");
        cardsplayers.Add("RegV1");
        cardsplayers.Add("RegV2");
        
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

            //int r = Random.Range(0,3);

            conexion.Open();
            MySqlDataReader reader = consola.ExecuteReader();
            while (reader.Read())
            {
                r = reader["idPartida"].ToString();

            }
            idPartida.text = r;
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

    public void RepartirCartasPiramide()
    {
        try
        {

            for (int i = 0; i < 15; i++)
            {

                int mIndex = Random.Range(0, 39);

                string DataConecction = "Server=beerorstain20.mysql.database.azure.com; Port=3306; Database=bosdb; Uid=adminbos@beerorstain20; Pwd=*camaja20*; SslMode=Preferred;";
                string Query = "INSERT INTO bosdb.cartapiramide (nombreCarta, idPartida) VALUES ('" + cardspiramide[mIndex] + "'," + r + ");";
                cardspiramide.RemoveAt(mIndex);

                conexion = new MySqlConnection(DataConecction);
                consola = new MySqlCommand(Query, conexion);

                conexion.Open();
                consola.ExecuteReader();
                conexion.Close();
            }

            //-------------------------
            ActualizarEstado();

        }
        catch (MySqlException ex)
        {

            Debug.LogError("Error: " + ex);
        }
    }

    public void RepartirCartasJugador()
    {
        try
        {

            string DataConecction = "Server=beerorstain20.mysql.database.azure.com; Port=3306; Database=bosdb; Uid=adminbos@beerorstain20; Pwd=*camaja20*; SslMode=Preferred;";
            string Query = "SELECT idJugador FROM bosdb.jugador WHERE idPartida = "+r+";";

            conexion = new MySqlConnection(DataConecction);
            consola = new MySqlCommand(Query, conexion);



            string idJugadores = "";
            conexion.Open();
            MySqlDataReader reader = consola.ExecuteReader();
            while (reader.Read())
            {
                idJugadores = reader["idJugador"].ToString();

                try
                {
                    int mIndex = Random.Range(0, 69);
                    string DataConecction2 = "Server=beerorstain20.mysql.database.azure.com; Port=3306; Database=bosdb; Uid=adminbos@beerorstain20; Pwd=*camaja20*; SslMode=Preferred;";
                    string Query2 = "INSERT INTO bosdb.cartajugador (nombre, idPartida) VALUES ('B6',4018);";

                    conexion2 = new MySqlConnection(DataConecction2);
                    consola2 = new MySqlCommand(Query2, conexion2);

                    conexion2.Open();
                    consola2.ExecuteReader();
                    conexion2.Close();
                }
                catch (MySqlException exe)
                {

                    Debug.LogError("Error: " + exe);
                }
            }
            

            conexion.Close();

        }
        catch (MySqlException ex)
        {

            Debug.LogError("Error: " + ex);
        }
    }
}
