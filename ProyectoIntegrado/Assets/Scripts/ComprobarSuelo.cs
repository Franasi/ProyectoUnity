using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Script que nos permitira saber si nuestro personaje esta en contacto con alguna geometria como puede ser el suelo
 */

public class ComprobarSuelo : MonoBehaviour
{

    /*Variable booleana que sera false si nuestro personaje no esta en contacto con una geometria
    y sera true cuando este en contacto con una geometria */

    public static bool comprobarSuelo;


    //Cuando el boxCollider entre dentro de una geometrica(Como puede ser el suelo)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            comprobarSuelo = true;
        }
        
    }

    //Cuando el boxCollider entre salga de una geometrica (Como puede ser el suelo)
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            comprobarSuelo = false;
        }
    }

}
