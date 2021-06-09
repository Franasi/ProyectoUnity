using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script que nos devolvera al principio del mapa si entramos en contacto con el enemigo
 */

public class CuboPinchos : MonoBehaviour
{

    /*
     * Metodo que proporciona Unity. Si el jugador entra en contacto con el enemigo se nos devolvera al principio del mapa reiniciando el 
     * nivel
     */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            //Llamamos al método PlayerHerido de la clase Respawn
            collision.transform.GetComponent<Respawn>().PlayerHerido();
        }
    }
}
