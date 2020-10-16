using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using System.Data;
using System;
using UnityEngine.SceneManagement;

public class JoinMatch : MonoBehaviour
{
    private MySqlConnection conexion;
    private MySqlCommand consola;

    public InputField nick;
    public InputField partida;

    public GameObject cuadro;
    public GameObject button;

    public float timeRemaining = 1;
    private bool gamerunning;

    public string nickJugador;
    public string idpartida = "0";

    public string variableA;

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
                    string Query = "SELECT estado FROM bosdb.partida WHERE idPartida = " + idpartida + " ;";

                    conexion = new MySqlConnection(DataConecction);
                    consola = new MySqlCommand(Query, conexion);

                    string estado = "";
                    conexion.Open();
                    MySqlDataReader reader = consola.ExecuteReader();
                    while (reader.Read())
                    {
                        estado = reader["estado"].ToString();
                                        
                        
                    }
                    if (estado == "1")
                    {
                        SceneManager.LoadScene("Player");
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

    public void UniserPartida()
    {
        try
        {
            
            string DataConecction = "Server=beerorstain20.mysql.database.azure.com; Port=3306; Database=bosdb; Uid=adminbos@beerorstain20; Pwd=*camaja20*; SslMode=Preferred;";
            string Query = "INSERT INTO bosdb.jugador VALUES (NULL, '"+ nick.text + "',"+ partida.text + ");";
            idpartida = partida.text;
            nickJugador = nick.text;
            DatoUsuarios.Nick = nickJugador;
            DatoUsuarios.idPartida = idpartida;
            cuadro.SetActive(true);
            GetComponent<Button>().interactable = false;          
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


