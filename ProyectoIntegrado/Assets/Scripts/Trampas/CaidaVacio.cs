using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/*
 * Script para que cuando nos caigamos fuera del mapa o en los pinchos se reinicie el nivel  
 */

public class CaidaVacio : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Si el boxcolider entra en contacto con el jugador se reiniciara el nivel. 
        if (collision.transform.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
