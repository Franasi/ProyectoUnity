using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Script que se encarga de gestionar el movimiento de los enemigos mas basicos
public class IAEnemigo : MonoBehaviour
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

    //Se encarga de mover al enemigo de punto a punto
    void Update()
    {
        StartCoroutine(CheckEnemyMoving());

        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, velocidad * Time.deltaTime);

        if (Vector2.Distance(transform.position,moveSpots[i].transform.position)<0.1f)
        {
            if (tiempoEspera<=0)
            {
                if (moveSpots[i]!=moveSpots[moveSpots.Length-1])
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

    //Se encarga de gestionar las animaciones del enemigo y la posicion en la que mira a
    //la hora de moverse
    IEnumerator CheckEnemyMoving()
    {
        posicionActual = transform.position;


        yield return new WaitForSeconds(0.5f);


        if (transform.position.x>posicionActual.x)
        {
            spriteRenderer.flipX = true;
            animacion.SetBool("Idle", false);
        }
        else if(transform.position.x<posicionActual.x)
        {
            spriteRenderer.flipX = false;
            animacion.SetBool("Idle", false);
        }
        else if (transform.position.x == posicionActual.x)
        {
            animacion.SetBool("Idle", true);
        }
    }
}
