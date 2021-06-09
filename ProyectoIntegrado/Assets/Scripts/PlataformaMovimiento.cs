using System.Collections;
using System.Collections.Generic;
using UnityEngine;





/*
* Script que se encarga del movimiento de las plataformas horizontales y verticales
*/
public class PlataformaMovimiento : MonoBehaviour
{



    //Variables
    public float velocidad = 0.5f;

    private float tiempoEspera;
    public float starWaitTime = 2;

    public Transform[] moveSpots;


    private int i = 0;




    void Start()
    {
        tiempoEspera = starWaitTime;
    }


    void Update()
    {


        //Para que la plataforma se este moviendo de un punto a otro continuamente
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, velocidad * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[i].transform.position) < 0.1f)
        {
            if (tiempoEspera <= 0)
            {
                if (moveSpots[i] != moveSpots[moveSpots.Length - 1])
                {
                    i++;
                }
                else
                {
                    i = 0;
                }

                tiempoEspera = starWaitTime;

            }
            else
            {
                tiempoEspera -= Time.deltaTime;
            }

        }

    }

    //Le asignamos la plataforma como padre de nuestro personaje para que se pueda mover 
    //con la plataforma
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.collider.transform.SetParent(transform);
    }

    //Quitamos como padre a la plataforma al salir nuestro personaje de ella
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.collider.transform.SetParent(null);
    }
}