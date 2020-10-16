using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System.Data;
using UnityEngine.UI;
public class CardsPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private Image UIImagen;
    private MySqlConnection conexion;
    private MySqlCommand consola;

    public int item;
    public string boton;

    ArrayList cardsJugador= new ArrayList();


    void Start()
    {
        UIImagen = GameObject.Find(boton).GetComponent<Image>();
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
                cardsJugador.Add(carta);
            }

            UIImagen.sprite = Resources.Load<Sprite>("Images/" + cardsJugador[item] + "");
            

            conexion.Close();

        }
        catch (MySqlException ex)
        {
            Debug.LogError("Error: " + ex);
        }
        
    }

    public void LanzarCarta(){

        if (cardsJugador[item].ToString() == DatosGlobales.CartaMostrada)
        {
           GetComponent<Button>().interactable = false; 
        }
          
    }
}
