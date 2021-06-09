using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Script que al hacernos danio con un objeto hiriente como puede ser unos pinchos nos devolvera al principio del nivel
 */

public class ObjetoHiriente : MonoBehaviour
{

    //Metodo que nos devolvera al principio del nivel si colisionamos con un objeto hiriente
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            //Llamamos al metodo PlayerHerido de la clase Respawn
            collision.transform.GetComponent<Respawn>().PlayerHerido();
        }
    }
}
