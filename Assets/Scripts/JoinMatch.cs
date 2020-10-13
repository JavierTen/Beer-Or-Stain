using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using System.Data;
using System;

public class JoinMatch : MonoBehaviour
{
    private MySqlConnection conexion;
    private MySqlCommand consola;

    public InputField nick;
    public InputField partida;

    public void UniserPartida()
    {
        try
        {
            //int idPartida = Int32.Parse(partida);
            string DataConecction = "Server=beerorstain20.mysql.database.azure.com; Port=3306; Database=bosdb; Uid=adminbos@beerorstain20; Pwd=*camaja20*; SslMode=Preferred;";
            string Query = "INSERT INTO bosdb.jugador VALUES (NULL, '"+ nick.text + "',"+ partida.text + ");";

            conexion = new MySqlConnection(DataConecction);
            consola = new MySqlCommand(Query, conexion);

            conexion.Open();
            consola.ExecuteReader();
            conexion.Close();

        }
        catch (MySqlException ex)
        {

            Debug.LogError("Error: " + ex);
        }
    }
}
