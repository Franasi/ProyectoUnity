using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Script que se encarga de gestionar el movimiento del enemigo Abeja
public class AbejaEnemigo : MonoBehaviour
{

    //Variables
    public Animator animacion;
    public SpriteRenderer spriteRenderer;
    public float velocidad = 0.5f;
    private float tiempoEspera;
    public float starWaitTime = 2;
    public Transform[] moveSpots;
    private int i = 0;
    private Vector2 posicionActual;


    void Start()
    {
        tiempoEspera = starWaitTime;
    }


    //Mueve a la abeja de un punto a otro
    void Update()
    {
        

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


   
}
