using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Aniadimos la siguiente libreria para gestionar el paso de una escena a otra
using UnityEngine.SceneManagement;

/*
 * Script que nos permite movernos al primer nivel del juego
 */

public class MenuPrincipal : MonoBehaviour
{
    

    //Metodo para cargar las escenas del juego
    public void Escenas()
    {
        SceneManager.LoadScene("Nivel1");
    }

    //Metodo para salir
    public void SalirJuego()
    {
        Application.Quit();
    }

    //Metodo para volver a la escena de registro
    public void VolverRegistro()
    {
        SceneManager.LoadScene("Registro");
    }
}
