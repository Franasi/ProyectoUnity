using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Script que se encarga de gestionar una plataforma de doble sentido.
public class PlataformaDobleSentido : MonoBehaviour
{


    //Variables
    private PlatformEffector2D effector;
    public float tiempoEspera;
    private float tiempoTranscurrido;

    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    void Update()
    {
        //Se encarga de comprobar en que posicion estamos para saber si podemos subirnos a la plataforma
        //o bajarnos de ella
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp("s"))
        {
            tiempoTranscurrido = tiempoEspera;
        }

        if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s"))
        {
            if (tiempoTranscurrido <= 0)
            {
                effector.rotationalOffset = 180f;
                tiempoTranscurrido = tiempoEspera;
            }
            else
            {
                tiempoTranscurrido -= Time.deltaTime;
            }
        }

        if (Input.GetKey("space"))
        {
            effector.rotationalOffset = 0;
        }
    }
}
