﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System.Data;

public class CPJugador : MonoBehaviour
{
    private MySqlConnection conexion;
    private MySqlCommand consola;
    private SpriteRenderer rend;
    private Sprite cartaC;
    public float timeRemaining = 3;
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
                    string Query = "SELECT carta FROM bosdb.cartaspiramidejugador WHERE idPartida = " + DatosGlobales.IdPartida + ";";

                    conexion = new MySqlConnection(DataConecction);
                    consola = new MySqlCommand(Query, conexion);

                    string carta = "";

                    conexion.Open();
                    MySqlDataReader reader = consola.ExecuteReader();
                    while (reader.Read())
                    {
                        carta = reader["carta"].ToString();
                    }
                    if (carta != "")
                    {
                        rend = GetComponent<SpriteRenderer>();
                        cartaC = Resources.Load<Sprite>("Images/" + carta);
                        rend.sprite = cartaC;
                        transform.localScale = new Vector3(0.2156625f, 0.2178207f, 1f);
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
}
